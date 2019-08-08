import React from "react";
import renderer from "react-test-renderer";
import { Home } from "./Home";

test("render Home with isLoading prop", () => {
  const component = renderer.create(
    <Home isLoading={true} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});

test("render Home with hasError prop", () => {
  const component = renderer.create(
    <Home isLoading={false} hasError={true} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});

test("render Home with data prop", () => {
  const data = [{ titulo: "Teste", ano: 2019 }];
  const component = renderer.create(
    <Home isLoading={false} hasError={false} data={data} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});
import React from "react";
import renderer from "react-test-renderer";
import { Classification } from "./Classification";

test("render Classification with isLoading prop", () => {
  const component = renderer.create(
    <Classification isLoading={true} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});

test("render Classification with hasError prop", () => {
  const component = renderer.create(
    <Classification isLoading={false} hasError={true} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});

test("render Classification with data prop", () => {
  const data = {
    campeao: { titulo: "Campeao"},
    vice: { titulo: "Vice" }
  };

  const component = renderer.create(
    <Classification isLoading={false} hasError={false} data={data} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});
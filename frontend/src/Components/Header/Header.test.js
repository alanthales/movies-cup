import React from "react";
import Header from "./Header";
import renderer from "react-test-renderer";

test("render Header from given props", () => {
  const component = renderer.create(
    <Header title="Title Test" subtitle="Testing header" />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});
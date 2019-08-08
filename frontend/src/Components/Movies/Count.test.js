import React from "react";
import MoviesCount from "./Count";
import renderer from "react-test-renderer";

test("render Movies Count from given props", () => {
  const component = renderer.create(
    <MoviesCount value={4} onGenerate={() => {}} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});
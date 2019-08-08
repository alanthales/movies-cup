import React from "react";
import NotFound from "./NotFound";
import renderer from "react-test-renderer";

test("render NotFound without errors", () => {
  const component = renderer.create(
    <NotFound />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})
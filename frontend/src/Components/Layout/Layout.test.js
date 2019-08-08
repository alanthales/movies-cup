import React from "react";
import Layout from "./Layout";
import renderer from "react-test-renderer";

test("render Layout from given props", () => {
  const component = renderer.create(
    <Layout title="Test" subtitle="Testing layout" />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})
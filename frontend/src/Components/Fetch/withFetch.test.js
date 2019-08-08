import React from "react";
import renderer from "react-test-renderer";
import withFetch from "./withFetch";
import http from "../../Helpers/http";

test("withFetch should return a new component with props", () => {
  http.get = jest.fn();

  const MockC = (props) => (<div {...props} />);
  const HocTest = withFetch("/")(MockC);
  const component = renderer.create(<HocTest />);

  let tree = component.toJSON();
  
  expect(tree.props.isLoading).toBeTruthy();
  expect(tree.props.hasError).toBeFalsy();
  expect(tree.props.data).toHaveLength(0);
});
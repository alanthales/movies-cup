import React from "react";
import Rank from "./Rank";
import renderer from "react-test-renderer";

test("render Rank from given props", () => {
  const champion = { titulo: "Filme vencedor" },
    vice = { titulo: "Filme vice-campeão" };
    
  const component = renderer.create(
    <Rank champion={champion} vice={vice} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});
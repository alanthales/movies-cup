import React from "react";
import MoviesList from "./List";
import renderer from "react-test-renderer";

const movies = [
  { id: "tt3606756", titulo: "Os Incríveis 2", ano: 2018, nota: 8.5 },
  { id: "tt4881806", titulo: "Jurassic World: Reino Ameaçado", ano: 2018, nota: 6.7 },
  { id: "tt5164214", titulo: "Oito Mulheres e um Segredo", ano: 2018, nota: 6.3 },
  { id: "tt5463162", titulo: "Deadpool 2", ano: 2018, nota: 8.1 }
];

test("render Movies List from given props", () => {
  const component = renderer.create(
    <MoviesList movies={movies} onSelect={() => {}} />
  );

  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});
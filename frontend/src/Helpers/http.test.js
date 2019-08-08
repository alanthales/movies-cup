import http from "./http";

beforeEach(() => {
  window.fetch = jest.fn().mockImplementation(url => {
    return Promise.resolve({ ok: true, json: () => [] });
  });  
});

test("'get' should return data", async () => {
  let data = await http.get("/");
  expect(data).not.toBeNull();
  expect(data).toHaveLength(0);
});

test("'post' should return data", async () => {
  let data = await http.post("/", {});
  expect(data).not.toBeNull();
  expect(data).toHaveLength(0);
});
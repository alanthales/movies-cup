function errorHandle(response) {
  if (response.ok) {
    return response.json();
  }
  throw Error(response.statusText);
}

export default {
  get(url) {
    return fetch(url).then(errorHandle);
  },

  post(url, data) {
    return fetch(url, {
      method: "post",
      body: JSON.stringify(data),
      headers: { "Content-Type": "application/json" }
    }).then(errorHandle);
  }
};
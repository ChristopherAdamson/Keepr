import Axios from "axios";

let baseUrl = window.location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

export const api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 5000,
  withCredentials: true
});

// export const setBearer = function (bearer) {
//   api.defaults.headers.authorization = bearer;
//   console.log(bearer);
// };

// export const resetBearer = function () {
//   api.defaults.headers.authorization = "";
// };

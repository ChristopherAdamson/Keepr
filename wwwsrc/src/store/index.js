import Vue from "vue";
import Vuex from "vuex";
import { api } from "./AxiosService"
import router from "../router";
import keepsModule from "./KeepsModule.js"

Vue.use(Vuex);

// let baseUrl = window.location.host.includes("localhost")
//   ? "https://localhost:5001/"
//   : "/";

// let api = Axios.create({
//   baseURL: baseUrl + "api/",
//   timeout: 3000,
//   withCredentials: true
// });

export default new Vuex.Store({
  state: {
    publicKeeps: []
  },
  mutations: {
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    }
  },
  modules: {
    keepsModule,
  }
});

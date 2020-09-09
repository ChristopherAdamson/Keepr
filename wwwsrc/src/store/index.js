import Vue from "vue";
import Vuex from "vuex";
import { api } from "./AxiosService"
import router from "../router";
import keepsModule from "./KeepsModule.js"
import vaultsModules from "./VaultsModule.js"
import vaultKeep from "./VaultKeepModule.js"
Vue.use(Vuex);


export default new Vuex.Store({
  state: {
    publicKeeps: [],
    activeKeep: {},
    vaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setActiveVault(state, data) {
      state.activeVault = data;
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data;
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
    vaultsModules,
    vaultKeep
  }
});

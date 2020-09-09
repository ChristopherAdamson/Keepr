import { api } from "./AxiosService"
export default {
  actions: {
    async createVault({ commit, dispatch }, newVault) {
      try {

        let res = await api.post("vaults", newVault)
        console.log(res.data);
        dispatch("getVaults")
      } catch (error) { console.error(error); }
    },
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults")
        console.log(res.data);
        commit("setVaults", res.data)
      } catch (error) { console.error(error); }
    },
    async getVaultById({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId)
        console.log(res.data);
        commit("setActiveVault", res.data)
      } catch (error) { console.error(error); }
    },
    async addKeepToVault({ commit, dispatch }, payload) {
      try {

      } catch (error) { console.error(error); }
    }
  }
}
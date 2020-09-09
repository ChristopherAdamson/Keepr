import { api } from "./AxiosService"
export default {
  actions: {
    async deleteKeepFromVault({ commit, dispatch }, payload) {
      try {
        debugger
        let res = await api.delete("vaultkeeps/" + payload.Id + "/keeps/" + payload.keepId)
        console.log(res.data);
        dispatch("getKeepsByVaultId", payload.vaultId)
      } catch (error) { console.error(error); }
    },
    async getKeepsByVaultId({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId + "/keeps")
        console.log(res.data);
        commit("setVaultKeeps", res.data)
      } catch (error) { console.error(error); }
    },
    async addKeepToVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post("vaultkeeps", payload)
        console.log(res.data);
      } catch (error) { console.error(error); }
    }
  }
}
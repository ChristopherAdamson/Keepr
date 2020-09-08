import { api } from "./AxiosService"
export default {
  actions: {
    async deleteKeepFromVault({ commit, dispatch }, newVault) {
      try {
        // TODO
      } catch (error) { console.error(error); }
    },
    async getKeepsByVaultId({ commit, dispatch }) {
      try {
        // TODO
      } catch (error) { console.error(error); }
    },
    async addKeepToVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post("relationships", payload)
        console.log(res.data);
      } catch (error) { console.error(error); }
    }
  }
}
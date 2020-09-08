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
        dispatch("getVaults")
      } catch (error) { console.error(error); }
    },

  }
}
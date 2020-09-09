import { api } from "./AxiosService"
export default {
  actions: {
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("/keeps")
        console.log(res.data);
        commit("setPublicKeeps", res.data)
      } catch (error) { console.error(error); }
    },
    async getKeepById({ commit, dispatch }, keepId) {
      try {
        let res = await api.get("/keeps/" + keepId)
        console.log(res.data);
        commit("setActiveKeep", res.data)
      } catch (error) { }
    },

    async createKeep({ commit, dispatch }, newKeep) {
      try {

        let res = await api.post("keeps", newKeep)
        console.log(res.data);
        // TODO should probably create a method to get the ones ive made. 
        // dispatch("getMyKeeps")
      } catch (error) { console.error(error); }
    },
    async getMyKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user")
        console.log(res.data);
        commit("setUserKeeps", res.data)
      } catch (error) { console.error(error); }
    },

    // TODO EDIT AND DELETE KEEPS


  }
}
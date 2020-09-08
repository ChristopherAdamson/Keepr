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
        let res = await api.put("/keeps" + keepId)
        console.log(res.data);
        commit("setActiveKeep", res.data)
      } catch (error) { console.error(error); }
    },


    async createKeep({ commit, dispatch }, newKeep) {
      try {

        let res = await api.post("keeps", newKeep)
        console.log(res.data);
        // TODO should probably create a method to get the ones ive made. 
        // dispatch("getMyKeeps")
      } catch (error) { console.error(error); }

    }
  }
}
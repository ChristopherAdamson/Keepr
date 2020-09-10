<template>
  <div class="Keeps col-3 border border-dark mx-2 text-center">
    <h5>{{keepData.name}}</h5>
    <p>{{keepData.description}}</p>
    <div class="text-danger" v-if="keepData.isPrivate">PRIVATE</div>
    <img class="img-fluid height" :src="keepData.img" />
    <div
      class="text-center"
    >Views: {{keepData.views}} | Shares: {{keepData.shares}} | Keeps: {{keepData.keeps}}</div>
    <button @click="activeKeep" class="btn btn-sm btn-outline-success">View Keep</button>
    <button
      @click="makePublic"
      v-if="keepData.isPrivate"
      class="btn btn-outline-primary btn-sm"
    >Make Public</button>
    <button
      @click="deletePrivateKeep"
      v-if="keepData.isPrivate"
      class="btn btn-outline-danger btn-sm"
    >Delete</button>
    <button
      @click="removeVaultKeep(keepData.vaultKeepId)"
      class="btn btn-outline-danger btn-sm float-right"
      v-if="keepData.vaultKeepId"
    >Remove From Vault</button>
  </div>
</template>


<script>
import swal from "../components/SwalComponenet.js";
export default {
  name: "Keeps",
  data() {
    return {};
  },
  props: ["keepData", "vault"],
  computed: {},
  methods: {
    activeKeep() {
      this.$router.push({ name: "keep", params: { id: this.keepData.id } });
    },
    removeVaultKeep(vaultKeepId) {
      let payload = {
        Id: vaultKeepId,
        keepId: this.keepData.id,
        vaultId: this.vault,
      };
      this.$store.dispatch("deleteKeepFromVault", payload);
    },
    async makePublic() {
      if (
        await swal.confirmAction(
          "Are you sure? \nOnce Public this cannot be deleted"
        )
      ) {
        this.$store.dispatch("setAsPublic", this.keepData.id);
      }
    },
    async deletePrivateKeep() {
      if (
        await swal.confirmAction(
          "Are you sure? \nOnce deleted it will be gone forever"
        )
      ) {
        this.$store.dispatch("deletePrivateKeep", this.keepData.id);
      }
    },
  },
  components: {
    swal,
  },
};
</script>


<style scoped>
.height {
  max-height: 10rem;
  min-height: 10rem;
  width: auto;
}
</style>
<template>
  <div class="Keeps col-3 border border-dark mx-2 text-center">
    <h5>{{keepData.name}}</h5>
    <p>{{keepData.description}}</p>
    <img class="img-fluid height" :src="keepData.img" />
    <div
      class="text-center"
    >Views: {{keepData.views}} | Shares: {{keepData.shares}} | Keeps: {{keepData.keeps}}</div>
    <button @click="activeKeep" class="btn btn-sm btn-outline-success">View Keep</button>
    <button
      @click="removeVaultKeep(keepData.vaultKeepId)"
      class="btn btn-outline-danger btn-sm float-right"
      v-if="keepData.vaultKeepId"
    >Remove From Vault</button>
  </div>
</template>


<script>
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
  },
  components: {},
};
</script>


<style scoped>
.height {
  max-height: 10rem;
  min-height: 10rem;
  width: auto;
}
</style>
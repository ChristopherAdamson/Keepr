<template>
  <div class="activeVault container">
    <div class="row">
      <div v-if="vault" class="col-8">
        <h1>{{vault.name}}</h1>
        <h4>{{vault.description}}</h4>
      </div>
      <div v-else>Loading...</div>
      <div class="col-12 background-primary">
        <keepscomponent v-for="keep in publicKeeps" :keepData="keep" :key="keep.id" />
      </div>
    </div>
  </div>
</template>


<script>
import keepscomponent from "../components/Keeps";
export default {
  name: "activeVault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaultById", this.$route.params.id);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
  },
  computed: {
    keeps() {
      this.$store.state.vaultKeeps;
    },
    vault() {
      this.$store.state.activeVault;
    },
  },
  methods: {},
  components: {
    keepscomponent,
  },
};
</script>


<style scoped>
</style>
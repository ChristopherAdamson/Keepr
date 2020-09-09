<template>
  <div class="activeVault container">
    <div class="row text-center">
      <div v-if="vault" class="col-12">
        <h1>{{vault.name}}</h1>
        <h4>{{vault.description}}</h4>
      </div>
      <div v-else>Loading...</div>
      <div class="col-12 box bg-secondary">
        <div class="row justify-content-between m-3">
          <keepscomponent v-for="keep in keeps" :vault="vault.id" :keepData="keep" :key="keep.id" />
        </div>
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
  computed: {
    keeps() {
      return this.$store.state.vaultKeeps;
    },
    vault() {
      return this.$store.state.activeVault;
    },
  },
  mounted() {
    this.$store.dispatch("getVaultById", this.$route.params.id);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
  },
  methods: {},
  components: {
    keepscomponent,
  },
};
</script>


<style scoped>
.box {
  height: 35rem;
  width: 15rem;
  overflow: auto;
}
</style>
<template>
  <div class="activeVault container height">
    <div class="row text-center">
      <div v-if="vault" class="col-12">
        <h1>{{vault.name}}</h1>
        <h4>{{vault.description}}</h4>
      </div>
      <div v-else>Loading...</div>
      <div class="col-12 box bg-secondary bg-white rounded">
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
  height: 50rem;
  width: 15rem;
  background-color: white;
  overflow: auto;
}
.height {
  min-height: 93.5vh;
}
</style>
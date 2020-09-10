<template>
  <div class="activeKeep container-fluid">
    <div class="row justify-content-center">
      <div class="col-8 text-center">
        <h5>{{activeKeep.name}}</h5>
        <p>{{activeKeep.description}}</p>
        <img class="img-size" :src="activeKeep.img" />
        <div class="row justify-content-center">
          <div class="col-2">Views: {{activeKeep.views}}</div>
          <div class="col-2">Shares: {{activeKeep.shares}}</div>
          <div class="col-2">Keeps: {{activeKeep.keeps}}</div>
        </div>
        <div v-if="$auth.isAuthenticated" class="row justify-content-center m-2">
          <button @click="share" class="btn btn-primary btn-sm m-2">Share</button>
          <button
            data-toggle="modal"
            data-target="#one"
            class="btn btn-sm btn-success m-2"
          >Add To Vault</button>
        </div>
      </div>
    </div>
    <QuickModal id="one" :key="1">
      <div slot="title">Which Vault would you like?</div>
      <div slot="body">
        <div v-for="vault in vaults" :key="vault.id">
          <div class="border m-2 text-center">
            <h5 class="m-0">{{vault.name}}</h5>
            <p class="m-0">{{vault.description}}</p>
            <button @click="addToVault(vault.id)" class="btn btn-secondary m-0">Add</button>
          </div>
        </div>
      </div>
    </QuickModal>
  </div>
</template>


<script>
import QuickModal from "../components/QuickModal";
export default {
  name: "activeKeep",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.id);
    this.$store.dispatch("getVaults");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    addToVault(vaultId) {
      let payload = {
        vaultId: vaultId,
        keepId: this.activeKeep.id,
      };

      this.$store.dispatch("addKeepToVault", payload);
      $("#one").modal("hide");
    },
    deleteKeep() {
      // TODO check if it is there keep before showing them the button
    },
    share() {
      this.$store.dispatch("shareKeep", this.activeKeep.id);
    },
  },
  components: {
    QuickModal,
  },
};
</script>


<style scoped>
.img-size {
  height: 10rem;
  width: auto;
}
</style>
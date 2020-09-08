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
          <div @click="addToVault" class="col-2">Keeps: {{activeKeep.keeps}}</div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "activeKeep",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.id);
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {
    addToVault() {
      // TODO
    },
    deleteKeep() {
      // TODO check if it is there keep before showing them the button
    },
  },
  components: {},
};
</script>


<style scoped>
.img-size {
  height: 10rem;
  width: auto;
}
</style>
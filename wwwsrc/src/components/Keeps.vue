<template>
  <div class="Keeps col-3 border border-dark mx-2">
    <h5>{{keepData.name}}</h5>
    <p>{{keepData.description}}</p>
    <img class="img-fluid" :src="keepData.img" />
    <div
      class="text-center"
    >Views: {{keepData.views}} | Shares: {{keepData.shares}} | Keeps: {{keepData.keeps}}</div>
    <button @click="activeKeep" class="btn btn-sm btn-outline-success">View Keep</button>
  </div>
</template>


<script>
export default {
  name: "Keeps",
  data() {
    return {};
  },
  props: ["keepData"],
  computed: {},
  methods: {
    activeKeep() {
      this.$router.push({ name: "keep", params: { id: this.keepData.id } });
    },
  },
  components: {},
};
</script>


<style scoped>
</style>
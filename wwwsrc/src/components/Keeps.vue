<template>
  <div class="Keeps col-3">
    <h5>{{keepData.name}}</h5>
    <p>{{keepData.description}}</p>
    <img class="img-fluid" :src="keepData.img" />
    <div>Views: 0</div>
    <div>Shares: 0</div>
    <div>Keeps: 0</div>
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
  methods: {},
  components: {},
};
</script>


<style scoped>
</style>
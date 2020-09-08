<template>
  <div class="activeKeep"></div>
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
  computed: {},
  methods: {},
  components: {},
};
</script>


<style scoped>
</style>
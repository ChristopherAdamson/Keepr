<template>
  <div class="home container-fluid">
    <h1>Welcome Home</h1>
    <div class="row justify-content-center">
      <keepscomponent v-for="keep in publicKeeps" :keepData="keep" :key="keep.id" />
    </div>
  </div>
</template>

<script>
import keepscomponent from "../components/Keeps";
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
    keepscomponent,
  },
};
</script>

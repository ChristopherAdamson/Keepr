<template>
  <div class="dashboard container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <!-- <div class="col-12">public {{ publicKeeps }} user {{ userKeeps }}</div> -->
      <button
        v-if="!createKeep"
        @click="createKeep = true"
        class="btn btn-sm btn-outline-success"
      >Create a Keep</button>
      <form class="col-8" v-show="createKeep ">
        <div class="form-group">
          <input type="text" v-model="name" class="form-control" placeholder="Name of keep" />
          <input
            type="text"
            v-model="description"
            class="form-control"
            placeholder="input a description."
          />
          <input type="text" v-model="img" class="form-control" placeholder="Add an Image Url?" />
          <input type="checkbox" v-model="isPrivate" class="form-control w-25" placeholder />
          <button @click="submitKeep" class="btn btn-sm btn-primary">Submit</button>
          <button @click="createKeep = false" class="btn btn-sm btn-danger">Cancle</button>
        </div>
      </form>
    </div>
  </div>
</template>


<script>
export default {
  data() {
    return {
      createKeep: false,
      name: "",
      description: "",
      img: "",
      isPrivate: false,
    };
  },
  props: [""],
  mounted() {},
  computed: {},
  methods: {
    submitKeep() {
      this.createKeep = false;
      let newKeep = {
        Name: this.name,
        Description: this.description,
        Img: this.img,
        IsPrivate: !this.isPrivate,
      };
      debugger;
      this.$store.dispatch("createKeep", newKeep);
    },
  },
  components: {},
};
</script>

<style></style>

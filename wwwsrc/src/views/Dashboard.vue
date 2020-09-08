<template>
  <div class="dashboard container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <!-- <div class="col-12">public {{ publicKeeps }} user {{ userKeeps }}</div> -->
      <div class="row justify-content-around">
        <div class="col-6"></div>
        <div class="col-6"></div>
        <button
          data-toggle="modal"
          data-target="#one"
          class="btn btn-sm btn-outline-success"
        >Create a Keep</button>
        <button
          data-toggle="modal"
          data-target="#two"
          class="btn btn-sm btn-outline-success"
        >Create a Vault</button>
      </div>
    </div>
    <QuickModal id="one" :key="1">
      <div slot="title">Create a Keep</div>
      <form slot="body">
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
          <button data-dismiss="modal" class="btn btn-sm btn-danger">Cancle</button>
        </div>
      </form>
    </QuickModal>
    <QuickModal id="two" :key="2">
      <div slot="title">Create a Vault</div>
      <form slot="body">
        <div class="form-group">
          <input type="text" v-model="name" class="form-control" placeholder="Name of keep" />
          <input
            type="text"
            v-model="description"
            class="form-control"
            placeholder="input a description."
          />
          <button @click="submitKeep" class="btn btn-sm btn-primary">Submit</button>
          <button data-dismiss="modal" class="btn btn-sm btn-danger">Cancle</button>
        </div>
      </form>
    </QuickModal>
  </div>
</template>


<script>
import QuickModal from "../components/QuickModal";
export default {
  data() {
    return {
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

      this.$store.dispatch("createKeep", newKeep);
      (this.name = ""),
        (this.description = ""),
        (this.img = ""),
        (this.isPrivate = false);
    },
  },
  components: { QuickModal },
};
</script>

<style></style>

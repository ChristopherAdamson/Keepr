<template>
  <div class="dashboard container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <!-- <div class="col-12">public {{ publicKeeps }} user {{ userKeeps }}</div> -->
      <div class="row justify-content-around">
        <div class="col-4">
          <button
            data-toggle="modal"
            data-target="#one"
            class="btn btn-sm btn-outline-success"
          >Create a Keep</button>
        </div>
        <div class="col-4">
          <button
            data-toggle="modal"
            data-target="#two"
            class="btn btn-sm btn-outline-success"
          >Create a Vault</button>
        </div>
      </div>
    </div>
    <div class="row mt-5 justify-content-center">
      <div class="col-8 box">
        <div class="row">
          <div class="col-6">
            <button
              :disabled="keep == true"
              @click="toggle"
              class="btn btn-block btn-secondary"
            >Your Keeps</button>
          </div>
          <div class="col-6">
            <button
              :disabled="vault == true"
              @click="toggle"
              class="btn btn-block btn-secondary"
            >Your Vaults</button>
          </div>
        </div>
        <div v-if="vault" class="col-12">
          <div class="row">
            <div v-for="vault in vaults" :key="vault.id" class="col-3 m-2 border">
              <h5>{{vault.name}}</h5>
              <p>{{vault.description}}</p>
              <button
                @click="goToVault(vault.id)"
                class="btn btn-primary btn-block"
              >View keeps in vault</button>
            </div>
          </div>
        </div>
        <div v-if="keep" class="col-12"></div>
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
          <button @click.prevent="createKeep" class="btn btn-sm btn-primary">Submit</button>
          <button data-dismiss="modal" class="btn btn-sm btn-danger">Cancle</button>
        </div>
      </form>
    </QuickModal>
    <QuickModal id="two" :key="2">
      <div slot="title">Create a Vault</div>
      <form slot="body">
        <div class="form-group">
          <input type="text" v-model="name" class="form-control" placeholder="Name of vault" />
          <input
            type="text"
            v-model="description"
            class="form-control"
            placeholder="input a description."
          />
          <button @click.prevent="createVault" class="btn btn-sm btn-primary">Submit</button>
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
      vault: true,
      keep: false,
    };
  },
  props: [""],
  mounted() {
    this.$store.dispatch("getVaults");
    // this.$store.dispatch("getMyKeeps")
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    toggle() {
      this.vault = !this.vault;
      this.keep = !this.keep;
    },
    createKeep() {
      $("#one").modal("hide");
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
    createVault() {
      $("#two").modal("hide");

      let newVault = {
        Name: this.name,
        Description: this.description,
      };
      this.$store.dispatch("createVault", newVault);
      (this.name = ""), (this.description = "");
    },
    goToVault(vaultId) {
      this.$router.push({ name: "vault", params: { id: vaultId } });
    },
  },
  components: { QuickModal },
};
</script>

<style>
.box {
  height: 30rem;
  width: 15rem;
  background-color: rgba(0, 0, 0, 0.075);
  overflow: auto;
}
</style>

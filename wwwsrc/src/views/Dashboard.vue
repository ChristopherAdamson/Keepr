<template>
  <div class="dashboard container-fluid height">
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
        <div class="row bg-white rounded">
          <div class="col-6 mt-2">
            <button
              :disabled="keep == true"
              @click="toggle"
              class="btn btn-block btn-secondary"
            >Your Keeps</button>
          </div>
          <div class="col-6 mt-2">
            <button
              :disabled="vault == true"
              @click="toggle"
              class="btn btn-block btn-secondary"
            >Your Vaults</button>
          </div>
        </div>
        <div v-if="vault" class="col-12">
          <div class="row justify-content-around">
            <div
              v-for="vault in vaults"
              :key="vault.id"
              class="col-2 shadow-lg mx-1 my-3 rounded border"
            >
              <button @click="deleteVault(vault.id)" class="btn float-right">
                <i class="fa fa-trash-o text-danger"></i>
              </button>
              <h5 class="mt-2">{{vault.name}}</h5>
              <p>{{vault.description}}</p>
              <button
                @click="goToVault(vault.id)"
                class="btn btn-primary btn-block"
              >View keeps in vault</button>
            </div>
          </div>
        </div>
        <div v-if="keep" class="col-12">
          <div class="row justify-content-between m-3">
            <keepscomponent
              v-for="keep in keeps"
              :vault="vault.id"
              :keepData="keep"
              :key="keep.id"
            />
          </div>
        </div>
      </div>
    </div>
    <QuickModal id="one" :key="1">
      <div slot="title">Create a Keep</div>
      <form slot="body">
        <div class="form-group">
          <input type="text" v-model="name" class="form-control mb-1" placeholder="Name of keep" />
          <input
            type="text"
            v-model="description"
            class="form-control mb-1"
            placeholder="input a description."
          />
          <input
            type="text"
            v-model="img"
            class="form-control mb-1"
            placeholder="Add an Image Url?"
          />
          <div class="row align-items-center">
            <h5 class="ml-5 mt-1">Make this keep private?</h5>

            <input type="checkbox" v-model="isPrivate" class="form-control w-25 mt-1" placeholder />
          </div>
          <button @click.prevent="createKeep" class="btn btn-sm btn-primary ml-5 mt-2">Submit</button>
          <button data-dismiss="modal" class="btn btn-sm btn-danger float-right mr-5 mt-2">Cancle</button>
        </div>
      </form>
    </QuickModal>
    <QuickModal id="two" :key="2">
      <div slot="title">Create a Vault</div>
      <form slot="body">
        <div class="form-group">
          <input type="text" v-model="name" class="form-control mb-1" placeholder="Name of vault" />
          <input
            type="text"
            v-model="description"
            class="form-control mb-1"
            placeholder="input a description."
          />
          <button @click.prevent="createVault" class="btn btn-sm btn-primary ml-5 mt-2">Submit</button>
          <button data-dismiss="modal" class="btn btn-sm btn-danger float-right mr-5 mt-2">Cancle</button>
        </div>
      </form>
    </QuickModal>
  </div>
</template>


<script>
import swal from "../components/SwalComponenet.js";
import keepscomponent from "../components/Keeps";
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
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.userKeeps;
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
    async deleteVault(id) {
      if (
        await swal.confirmAction(
          "Are you sure? \nOnce deleted it will be gone forever"
        )
      ) {
        this.$store.dispatch("deleteVault", id);
      }
    },
  },
  components: { QuickModal, keepscomponent, swal },
};
</script>

<style>
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

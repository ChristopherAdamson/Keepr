<template>
  <div class="quickModal">
    <div
      class="modal fade"
      :id="id"
      tabindex="-1"
      role="dialog"
      aria-labelledby="modelTitleId"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <slot name="title">Title</slot>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <slot></slot>
            <slot name="body"></slot>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "quickModal",
  data() {
    return {};
  },
  props: ["id"],
  computed: {},
  methods: {},
  components: {},
};
</script>


<style scoped>
</style>
<template>
  <div>
    <b-button v-b-modal.modal-prevent-closing>Open Modal</b-button>

    <b-modal
      id="modal-prevent-closing"
      ref="modal"
      title="Profile"
      @show="resetModal"
      @hidden="resetModal"
      @ok="handleOk"
    >
      <form ref="form" @submit.stop.prevent="handleSubmit">
        <div class="row">
          <div class="col-6">
            <b-form-group
              label="Name"
              label-for="name-input"
              invalid-feedback="Name is required"
              :state="nameState"
            >
              <b-form-input
                id="name-input"
                v-model="customer.name"
                :state="nameState"
                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="Email"
              label-for="email-input"
              invalid-feedback="Email is required"
              :state="emailState"
            >
              <b-form-input
                type="email"
                id="email-input"
                v-model="customer.email"
                :state="emailState"
                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="Sex"
              label-for="sex-input"
              invalid-feedback="Sex is required"
              :state="sexState"
            >
              <b-form-input
                type="sex"
                id="sex-input"
                v-model="customer.sex"
                :state="sexState"
                required
              ></b-form-input>
            </b-form-group>

          </div>
          <div class="col-6">
            <b-form-group
              label="phone"
              label-for="phone-input"
              invalid-feedback="phone is required"
              :state="phoneState"
            >
              <b-form-input
                type="number"
                id="phone-input"
                v-model="customer.phone"
                :state="phoneState"
                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="address"
              label-for="address-input"
              invalid-feedback="address is required"
              :state="addressState"
            >
              <b-form-input
                type="address"
                id="address-input"
                v-model="customer.address"
                :state="addressState"
                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="location"
              label-for="location-input"
              invalid-feedback="location is required"
              :state="locationState"
            >
              <b-form-input
                type="location"
                id="location-input"
                v-model="customer.location"
                :state="locationState"
                required
              ></b-form-input>
            </b-form-group>
          </div>
        </div>
      </form>
    </b-modal>
  </div>
</template>

<script>
export default {
  props: {
    edit: {
      type: Object,
      default: null,
    },
  },
  watch: {
    edit() {
      if (this.edit) {
        this.customer = Object.assign({}, this.edit);
      } else {
        this.customer = {};
      }
    },
  },
  data() {
    return {
      customer: {
        name: "",
        email: "",
        sex:"",
        address:"",
        location:"",
        phone:""
      },
      name: "",
      nameState: null,
      submittedNames: [],

      email: "",
      emailState: null,
      submittedEmails: [],

    };
  },
  methods: {
    checkFormValidity() {
      const valid = this.$refs.form.checkValidity();
      this.nameState = valid;
      this.emailState = valid;
      return valid;
    },
    resetModal() {
      this.name = "";
      this.nameState = null;
    },
    handleOk(bvModalEvt) {
      // Prevent modal from closing
      bvModalEvt.preventDefault();
      // Trigger submit handler
      this.handleSubmit();
    },
    handleSubmit() {
      // Exit when the form isn't valid
      if (!this.checkFormValidity()) {
        return;
      }
      // Push the name to submitted names
      this.submittedNames.push(this.name);
      this.submittedEmails.push(this.email);
      // Hide the modal manually
      this.$nextTick(() => {
        this.$bvModal.hide("modal-prevent-closing");
      });
    },
  },
};
</script>

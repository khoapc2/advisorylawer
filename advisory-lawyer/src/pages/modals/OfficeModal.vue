<template>
  <div>
    <b-button v-b-modal.modal-prevent-closing style="display:none" >Open Modal</b-button>

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
                v-model="office.name"
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
                v-model="office.email"
                :state="emailState"
                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="Description"
              label-for="description-input"
              invalid-feedback="description is required"

            >
              <b-textarea

                id="description-input"
                v-model="office.description"

                required
              ></b-textarea>
            </b-form-group>

          </div>
          <div class="col-6">

            <b-form-group
              label="Website"
              label-for="website-input"
              invalid-feedback="website is required"
              
            >
              <b-form-input
                id="website-input"
                v-model="office.website"               
                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="Phone"
              label-for="phone-input"
              invalid-feedback="phone is required"

            >
              <b-form-input
                type="number"
                id="phone-input"
                v-model="office.phone_number"

                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="Address"
              label-for="address-input"
              invalid-feedback="address is required"
 
            >
              <b-form-input
                id="address-input"
                v-model="office.address"

                required
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label="Location"
              label-for="location-input"
              invalid-feedback="location is required"

            >
              <b-form-input
                id="location-input"
                v-model="office.location"
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
        this.office = Object.assign({}, this.edit);
      } else {
        this.office = {};
      }
    },
  },
  data() {
    return {
      office: {
        // name: "",
        // email: "",
        // sex:"",
        // address:"",
        // location:"",
        // phone:""
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

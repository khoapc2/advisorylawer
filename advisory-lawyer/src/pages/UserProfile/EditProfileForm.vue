<template>
  <card class="card" title="Edit Profile">
    <div>
      <form @submit.prevent>
        <div class="row">
          <div class="col-md-6">
            <fg-input
              type="text"
              label="Username"
              :disabled="true"
              v-model="username"
            >
            </fg-input>
          </div>
          <div class="col-md-6" v-if="role === 'admin'">
            <fg-input
              type="text"
              label="Your Name"
              :disabled="true"
              placeholder="Fullname"
              v-model="name"
            >
            </fg-input>
          </div>
          <div class="col-md-6" v-if="role === 'lawyer_office'">
            <fg-input
              type="text"
              label="Office Name"
              placeholder="Fullname"
              v-model="officeProfile.name"
            >
            </fg-input>
          </div>
        </div>

         <div class="row" v-if="role === 'lawyer_office'">
          <div class="col-md-8">
            <fg-input
              type="text"
              label="Address" 
              placeholder="Address"
              v-model="officeProfile.address"
            >
            </fg-input>
          </div>
          <div class="col-md-4" v-if="role === 'lawyer_office'">
            <fg-input
              type="text"
              label="Location"
              placeholder="Location"
              v-model="officeProfile.location"
            >
            </fg-input>
          </div>
        </div>

        <div class="row" v-if="role === 'lawyer_office'">
          <div class="col-md-4">
            <fg-input
              type="text"
              label="Phone"
              placeholder="Phone Number"
              v-model="officeProfile.phone_number"
            >
            </fg-input>
          </div>
          <div class="col-md-8" v-if="role === 'lawyer_office'">
            <fg-input
              type="text"
              label="Office's Website"
              placeholder="Website link"
              v-model="officeProfile.website"
            >
            </fg-input>
          </div>
          <!-- <div class="col-md-4">         
              <label>Sex</label>
              <select class="form-control" v-model="userProfile.sex" :required="true">
                  <option v-for="option in optionsSex" v-bind:key="option.name" v-bind:value="option.name" >{{ option.name }}</option>
              </select>             
          </div>
        </div> -->

        <!-- <div class="row">
          <div class="col-md-12">
            <fg-input
              type="text"
              label="Email"
              placeholder="Email"
              v-model="userProfile.email"
            >
            </fg-input>
          </div> -->
        </div> 

        <div class="row" v-if="role === 'lawyer_office'">
          <div class="col-md-12">
            <div class="form-group">
              <label>About Office</label>
              <textarea
                rows="5"
                class="form-control border-input"
                placeholder="Here can be your description"
                v-model="officeProfile.description"
              >
              </textarea>
            </div>
          </div>
        </div> 
         <div class="text-center" v-if="role === 'lawyer_office'">
          <p-button type="info" round @click.native.prevent="updateOfficerProfile(officeProfile)">
            Update Profile
          </p-button>
        </div> 
        <div class="clearfix"></div>
      </form>
    </div>
  </card>
</template>
<script>
import { mapState } from 'vuex';
// import { mapActions, mapGetters } from "vuex";
// import axios from "axios";

export default {
  data() {
    return {



      // userProfile: [{

      // }],
      // selectedSex: "Male",
      // optionsSex: [
      //   {
      //     name: 'Female'
      //   },
      //   {
      //     name: 'Male'
      //   }
      // ],
      // userProfile: {
      userProfile: [{
        location: "",
        phone: "",
        address: "",
      }],
      username: "",
      name: "",
      role: "",
      // },
    };
  },
  created() {
    this.role = localStorage.getItem("role");
    if (this.role !== null ) {
      this.username = localStorage.getItem("email");
      this.name = localStorage.getItem("displayName");
      if(this.role === "admin"){}
      else if(this.role === "lawyer_office"){
        this.$store.dispatch("office/getOfficerProfile");
      }else{
        this.$router.push("/");
      }
    } else {
      this.$router.push("/");
    }
  },
  methods: {
    updateOfficerProfile(user){
      this.$store.dispatch("office/updateOfficeProfile", user);
    }
  },
  computed: {
    ...mapState("office",{
      officeProfile: "officerProfile",
    }),
  },
};
</script>
<style></style>

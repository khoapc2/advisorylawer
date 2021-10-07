<template>
  <card class="card" title="Edit Profile">
    <div>
      <form @submit.prevent>
        <div class="row">
          <div class="col-md-6">
            <fg-input type="text"
                      label="Username"
                      :disabled="true"
                      v-model="userProfile.username">
            </fg-input>
          </div>
          <div class="col-md-6">
            <fg-input type="text"
                      label="Your Name"
                      placeholder="Fullname"
                      v-model="userProfile.name">
            </fg-input>
          </div>     
        </div>

        <div class="row">
          <div class="col-md-8">
            <fg-input type="text"
                      label="Address"
                      placeholder="Address"
                      v-model="userProfile.address">
            </fg-input>
          </div>
          <div class="col-md-4">
            <fg-input type="text"
                      label="Location"
                      placeholder="Location"
                      v-model="userProfile.location">
            </fg-input>
          </div>
        </div>

        <div class="row">
          <div class="col-md-4">
            <fg-input type="text"
                      label="Phone"
                      placeholder="Phone Number"
                      v-model="userProfile.phone">
            </fg-input>
          </div>
          <div class="col-md-4">
            <fg-input type="date"
                      label="Birth Day"
                      placeholder=" Your Birth Day"
                      v-model="userProfile.birthday">
            </fg-input>
          </div>
          <div class="col-md-4">
            <fg-input type="text"
                      label="Sex"
                      placeholder="Sex"
                      v-model="userProfile.sex">
            </fg-input>
          </div>
        </div>
        
        <div class="row">
          <div class="col-md-12">
            <fg-input type="text"
                      label="Email"
                      placeholder="Email"
                      v-model="userProfile.email">
            </fg-input>
          </div>
        </div>

        <div class="row">
          <div class="col-md-12">
            <div class="form-group">
              <label>About Me</label>
              <textarea rows="5" class="form-control border-input"
                        placeholder="Here can be your description"
                        v-model="userProfile.description">

              </textarea>
            </div>
          </div>
        </div>
        <div class="text-center">
          <p-button type="info"
                    round
                    @click.native.prevent="updateProfile">
            Update Profile
          </p-button>
        </div>
        <div class="clearfix"></div>
      </form>
    </div>
  </card>
</template>
<script>
import {mapActions,mapGetters} from 'vuex'
import axios from "axios";

export default {
  data() {
    return {
      userProfile:[],
      user: {
        // username: "Andeptroainhatthegioi@gmail.com",
        // email: "yeuem@yahoo.com",
        // fullname: "Trần Dương Phúc An",
        // phone: "09897172533",
        // address: "B2/1T, tổ 6, ấp làng lá",
        // location: "Hỏa Quốc",
        // birthday: "17/07/2000",
        // sex: "bede",
        // description: `We must accept finite disappointment, but hold on to infinite hope.`
      }
    };
  },
  created() {
        this.getProfileApi();
  },
  methods: {
    updateProfile() {
      alert("Your data: " + JSON.stringify(this.user));
    },
    getProfileApi() {
      console.log("tokenV " + localStorage.getItem("tokenID"));
      axios({
        method: "GET",
        url: "https://104.215.186.78/api/v1/user-accounts/profile",
        headers: {
          // "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      })
        .then((response) => {
          const data = response.data;
          console.log(response),
          this.userProfile = {
            id: data.id,
            location: data.location,
            sex: data.sex,
            email: data.email,
            username: data.username,
            description: data.description,
            name: data.name,
            birthday: data.date_of_birth,
            phone: data.phone_number,
            address: data.address,

          }
          _userProfile(this.userProfile)
        })
        .catch((error) => console.log(error));
    },
  },
  computed: {
    ...mapGetters({
      _getUserProfile: 'GET_USER_PROFILE'
    }),
    ...mapActions({
      _userProfile: 'getUserProfile'
     })
  },
};
</script>
<style>
</style>

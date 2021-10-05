<template>
  <card class="card" title="Edit Profile">
    <div>
      <form @submit.prevent>
        <div class="row">
          <div class="col-md-6">
            <fg-input type="text"
                      label="Username"
                      :disabled="true"
                      v-model="user.username">
            </fg-input>
          </div>
          <div class="col-md-6">
            <fg-input type="text"
                      label="Your Name"
                      placeholder="Fullname"
                      v-model="user.fullname">
            </fg-input>
          </div>     
        </div>

        <div class="row">
          <div class="col-md-8">
            <fg-input type="text"
                      label="Address"
                      placeholder="First Name"
                      v-model="user.address">
            </fg-input>
          </div>
          <div class="col-md-4">
            <fg-input type="text"
                      label="Country"
                      placeholder="Last Name"
                      v-model="user.location">
            </fg-input>
          </div>
        </div>

        <div class="row">
          <div class="col-md-4">
            <fg-input type="text"
                      label="Phone"
                      placeholder="Phone Number"
                      v-model="user.city">
            </fg-input>
          </div>
          <div class="col-md-4">
            <fg-input type="date"
                      label="Birth Day"
                      placeholder=" Your Birth Day"
                      v-model="user.birthday">
            </fg-input>
          </div>
          <div class="col-md-4">
            <fg-input type="text"
                      label="Sex"
                      placeholder="nhập vô con đĩ"
                      v-model="user.sex">
            </fg-input>
          </div>
        </div>
        
        <div class="row">
          <div class="col-md-12">
            <fg-input type="text"
                      label="Email"
                      placeholder="Email"
                      v-model="user.email">
            </fg-input>
          </div>
        </div>

        <div class="row">
          <div class="col-md-12">
            <div class="form-group">
              <label>About Me</label>
              <textarea rows="5" class="form-control border-input"
                        placeholder="Here can be your description"
                        v-model="user.description">

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
export default {
  data() {
    return {
      user: {
        username: "Andeptroainhatthegioi@gmail.com",
        email: "yeuem@yahoo.com",
        fullname: "Trần Dương Phúc An",
        phone: "09897172533",
        address: "B2/1T, tổ 6, ấp làng lá",
        location: "Hỏa Quốc",
        birthday: "17/07/2000",
        sex: "bede",
        description: `We must accept finite disappointment, but hold on to infinite hope.`
      }
    };
  },
  methods: {
    updateProfile() {
      alert("Your data: " + JSON.stringify(this.user));
    }
  }
};
</script>
<style>
</style>

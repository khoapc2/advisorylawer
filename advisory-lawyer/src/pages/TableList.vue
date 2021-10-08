<template>
  <div class="row">
    <!-- <div class="col-12">
      <card title="Yêu em là điều anh không thể ngờ" subTitle="yêu tất cả các em">
        <form @submit.prevent>
          <div class="row">
            <div class="col-md-5">
              <fg-input
                type="text"
                label="Username"
                :disabled="true"
                placeholder="Paper dashboard"
                v-model="user.company"
              >
              </fg-input>
            </div>
            <div class="col-md-3">
              <fg-input
                type="text"
                label="Username"
                placeholder="Username"
                v-model="user.username"
              >
              </fg-input>
            </div>
            <div class="col-md-4">
              <fg-input
                type="email"
                label="Username"
                placeholder="Email"
                v-model="user.email"
              >
              </fg-input>
            </div>
          </div>

          <div class="row">
            <div class="col-md-6">
              <fg-input
                type="text"
                label="First Name"
                placeholder="First Name"
                v-model="user.firstName"
              >
              </fg-input>
            </div>
            <div class="col-md-6">
              <fg-input
                type="text"
                label="Last Name"
                placeholder="Last Name"
                v-model="user.lastName"
              >
              </fg-input>
            </div>
          </div>

          <div class="row">
            <div class="col-md-12">
              <fg-input
                type="text"
                label="Address"
                placeholder="Home Address"
                v-model="user.address"
              >
              </fg-input>
            </div>
          </div>

          <div class="row">
            <div class="col-md-4">
              <fg-input
                type="text"
                label="City"
                placeholder="City"
                v-model="user.city"
              >
              </fg-input>
            </div>
            <div class="col-md-4">
              <fg-input
                type="text"
                label="Country"
                placeholder="Country"
                v-model="user.country"
              >
              </fg-input>
            </div>
            <div class="col-md-4">
              <fg-input
                type="number"
                label="Postal Code"
                placeholder="ZIP Code"
                v-model="user.postalCode"
              >
              </fg-input>
            </div>
          </div>

          <div class="row">
            <div class="col-md-12">
              <div class="form-group">
                <label>About Me</label>
                <textarea
                  rows="5"
                  class="form-control border-input"
                  placeholder="Here can be your description"
                  v-model="user.aboutMe"
                >
                </textarea>
              </div>
            </div>
          </div>
          <div class="text-center">
            <p-button type="info" round @click.native.prevent="updateProfile">
              Update Profile
            </p-button>
          </div>
          <div class="clearfix"></div>
        </form>

       
      </card>
    </div> -->

    <!-- <div slot="raw-content" class="table-responsive">
          <paper-table :data="table1.data" :columns="table1.columns">
          </paper-table>
      </div> -->

    <!-- <div class="col-12">
      <card class="card-plain">
        <div class="table-full-width table-responsive">
          <paper-table
            type="hover"
            :title="table2.title"
            :sub-title="table2.subTitle"
            :data="table2.data"
            :columns="table2.columns"
          >
          </paper-table>
        </div>
      </card>
    </div> -->

    <table class="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Address</th>
          <th scope="col">Phone</th>
          <th scope="col">Sex</th>
          <th scope="col">Email</th>
          <th scope="col">Role</th>
          <th scope="col">Status</th>
          <th scope="col" colspan="2" style="text-align:center">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in customerList" :key="user.id">
          <!-- <th scope="row">1</th> -->
          <td style="display:none">{{user.id}}</td>
          <td>{{ user.name }}</td>
          <td>{{ user.address }}</td>
          <td>{{ user.phone_number}}</td>
          <td>{{ user.sex }}</td>
          <td>{{ user.username}}</td>
          <td>{{ user.role}}</td>
          <td v-if="user.status === 1">Active</td>
          <td v-else>Inactive</td>
          <td>
            <button type="button" class="btn btn-warning" style="float: left" >Update</button>
            <button v-if="user.status === 1" type="button" class="btn btn-outline-danger" style="float: right" @click="banUser(user.id)">Ban</button>
             <button v-else-if="user.status === 0" type="button" class="btn btn-outline-danger" style="float: right"  @click="banUser(user.id)">Unbanned</button>
          </td>
        </tr>
        <!-- <tr>
      <th scope="row">2</th>
      <td>Jacob</td>
      <td>Thornton</td>
      <td>@fat</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>Larry</td>
      <td>the Bird</td>
      <td>@twitter</td>
    </tr> -->
      </tbody>
    </table>
  </div>
</template>
<script>
import { mapActions, mapGetters, mapState } from "vuex";
import axios from "axios";

export default {
  components: {},
  data() {
    return {
      listUser: [],
    };
  },
  created() {
    if(localStorage.getItem('role') !== 'admin'){
      this.$router.push("/");
    }else {
      this.$store.dispatch('getUserListApi');
    }
    



    // this.listUser = this._getUserList
    // listUser = _getUserList
  },
  computed: {
    ...mapGetters({
      _getUserList: "GET_LIST_USER",
    }),
    ...mapActions({
      // userList: "getUserList",
      // getUserListApi: "getUserListApi",
    }),
    ...mapState({
      customerList: "listUser",
    })
  },
  methods: {
    banUser(id){
      console.log(id)
      this.$store.dispatch('changeStatusUser',id)
    },
    // getListUserApi() {
    //   axios({
    //     method: "GET",
    //     url: "https://104.215.186.78/api/v1/user-accounts",
    //     headers: {
    //       // "Content-Type": "application/json; charset=utf-8",
    //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
    //     },
    //   })
    //     .then((response) => {
    //       Object.keys(response).forEach((property) => {
    //           // Access each object here by using response[property]...
    //           console.log(response[data])
    //       })
          // const data = response.data;
          //  userList(data)
          
          
          // const customer = {
          //   id: data.id,
          //   name: data.name,
          //   phone: data.phone_number,
          //   sex: data.sex,
          //   email: data.email,
          //   address: data.address,

            //   location: data.location,
            //   username: data.username,
            //   description: data.description,
            //   birthday: data.date_of_birth,
            
          // };
          // console.log(this.listUser);

          // _userList(this.listUser)
          // console.log('userList: ' + _getUserList);
    //     })
    //     .catch((error) => console.log(error));
    // },
   
  },
  mounted() {
    // _getBanUser,
    this.$store.dispatch('getUserListApi');

    console.log(this.$store.state.listUser)
    // this.listUser = this._getUserList;
    // console.log("Mount " + this.listUser.role)
  },
  watch:{
    
  }
};
</script>
<style lang="scss" scoped></style>>

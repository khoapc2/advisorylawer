<template>
  <div class="row">
    <div class="col-12">
      <card title="Officer's Management" subTitle="">
        <form @submit.prevent>
          <div class="row">
            <div class="col-md-4">
              <fg-input
                type="email"
                label="Officer's Email"
                placeholder="example@example.com"
                v-model="inpEmail"
              >
              </fg-input>
              <label v-if="emailErr !== ''" style="color: red"> {{emailErr}} </label>
            </div>
            <div class="col-md-6">
              <fg-input
                type="text"
                label="Officer's Name"
                placeholder="Officer's Name"
                v-model="inpName"
              >
              </fg-input>
              <label v-if="nameErr !== ''" style="color: red"> {{nameErr}} </label>
            </div>
            <div class="col-md-2">
             <p-button type="info" round @click="createOfficeAccount(inpName,inpEmail)">
              Create Officer
            </p-button>
          </div>
          </div>
          <div class="text-center">
            
            <div v-if="errorMessage === 'error'" class="alert alert-danger" role="alert">
              Create Fail
            </div>
            <div v-else-if="errorMessage === 'success'" class="alert alert-success" role="alert">
              Create Successful
            </div>
          </div>
          <div class="clearfix"></div>
        </form>
      </card>
    </div>

    <h3>Office's Detail</h3>
    <table class="table" ref="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col" >Name</th>
          <th scope="col" >Email</th>
          <th scope="col" >Status</th>
          <th scope="col" colspan="2" style="text-align:center">Action</th>
        </tr>
        <tr>
          <td>
            <div class="form-horizontal">
              <input
                type="text"
                name="..."
                class="form-control"
                placeholder="Search People..."
                style="width:280px;max-width:280px;display:inline-block"
                v-model="searchName"
                @keyup.enter="searchByName(searchName)"
              />
            </div>
          </td>
          <td>
            <input
                type="text"
                name="..."
                class="form-control"
                placeholder="Search Emaill..."
                style="width:280px;max-width:280px;display:inline-block"
                v-model="searchEmail"
                @keyup.enter="searchByEmail(searchEmail)"
              />
            </td>
             <td>
              <select class="form-control" :required="true" v-model="selected" @change="searchByStatus($event)">
                  <option :value="undefined" disabled style="display:none">Select something</option>
                  <option v-for="option in statusOption" :key="option.name" :value="option.name">{{
                    option.name
                  }}</option>
                </select>
          </td>
        </tr>
      </thead>
      <table-office>

      </table-office>
    </table>

    <!-- <ul class="pagination justify-content-center" style="margin:20px 0">
      <li class="page-item"><a class="page-link" href="#">Previous</a></li>
      <li class="page-item"><a class="page-link" href="#">1</a></li>
      <li class="page-item"><a class="page-link" href="#">2</a></li>
      <li class="page-item"><a class="page-link" href="#">3</a></li>
      <li class="page-item"><a class="page-link" href="#">Next</a></li>
    </ul> -->
  </div>
</template>
<script>
import { mapActions, mapGetters, mapState } from "vuex";
import TableOffice from './tables/TableOffice.vue'

export default {
  components: {
    TableOffice
    },
  data() {
    return {
      selected:undefined,
      searchStatus: "",
      searchName: "",
      searchEmail: "",


      errorMessage:'',
      inpEmail: '',
      inpName: '',
      listUser: [],
      nameErr: '',
      emailErr: '',
      roleOption: [
        {
          name: "customer",
        },
        {
          name: "admin",
        },
        {
          name: "lawyer",
        },
        {
          name: "office lawyer",
        },
      ],
      statusOption: [
        {
          name: "All"
        },
        {
          name: "Inactive"
        },
        {
          name: "Active"
        }
      ]
    };
  },
  created() {
    if (localStorage.getItem("role") !== "admin") {
      this.$router.push("/");
    } else {
      this.$store.dispatch("getListOfficer");
    }
  },
  computed: {
    ...mapGetters({
      _getUserList: "GET_LIST_USER",
    }),
    ...mapState({
      officerList: "listOfficer",
    }),
  },
  methods: {
    searchByStatus(ev){
      var status = ev.target.value
      var intStatus
      if(status === 'Inactive'){
        console.log(status)
        intStatus = 0;
      }else if(status === 'Active'){
        intStatus = 1;
      }else{
        intStatus = -1
      }

      if(intStatus !== -1){
        this.$store.dispatch("searchOfficeByStatus", intStatus);
      }else{
        this.$store.dispatch("getListOfficer");
      }
      this.searchName = "",
      this.searchEmail = ""
    },
    searchByName(username){
      this.$store.dispatch("searchOfficeByName", username);
      this.selected = undefined
      this.searchEmail = ''
    },
    searchByEmail(email){
      this.$store.dispatch("searchOfficeByEmail", email);
      this.selected = undefined
      this.searchName = ''
    },
    onUpdate() {
     this.$refs.table.refresh();
    },
    // banUser(id) {
    //   console.log(id);
    //   this.$store.dispatch("changeStatusOfficer", id);
    // },
    // updateCustomerRole(id,role){
    //   this.$store.dispatch("updateCustomerRole", {id,role})
    // },
    createOfficeAccount(inpName, inpEmail){
      if(inpName.trim() !== '' && inpEmail.trim() !== ''){
        console.log(inpName, inpEmail);
        try{
        this.$store.dispatch("createOffice", {inpName,inpEmail})
        // this.inpName = '',
        //   this.inpEmail = ''
          this.errorMessage = "success"
        }catch(error){
          this.errorMessage = "error"
        }
      }
      else {
        if(inpName.trim() == ''){
          this.emailErr = "Please input Office's email"
        }
        if(inpEmail.trim() == ''){
          this.nameErr = "Please input Office's name"
        }
      }
    }
  },
  mounted() {
    this.$store.dispatch("getListOfficer");
  },
};
</script>
<style lang="scss" scoped></style>

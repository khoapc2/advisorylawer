<template>
  <div class="row">
    <div class="col-12">
      <card title="Lawyer's Management" subTitle="">
        <form @submit.prevent>
          <div class="row">
            <div class="col-md-4">
              <fg-input
                type="email"
                label="Lawyer's Email"
                placeholder="example@example.com"
                v-model="inpEmail"
              >
              </fg-input>
              <label v-if="emailErr !== ''" style="color: red"> {{emailErr}} </label>
            </div>
            <div class="col-md-6">
              <fg-input
                type="text"
                label="Lawyer's Name"
                placeholder="Lawyer's Full Name"
                v-model="inpName"
              >
              </fg-input>
              <label v-if="nameErr !== ''" style="color: red"> {{nameErr}} </label>
            </div>
             <div class="col-md-2">
             <p-button type="info" round @click="createLawyerAccount(inpName,inpEmail)">
              Create Lawyer
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

    <h3>Lawyer's Detail</h3>
    <table class="table" ref="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col" >Name</th>
          <th scope="col" >Email</th>
          <th scope="col" >Office</th>
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
            <!-- <select class="form-control" :required="true" v-model="selected" @change="searchOfficeName($event)">
              <option :value="undefined" disabled style="display:none">Select something</option>
              <option :value="undefined" > All </option>
              <option v-for="office in listOfficer" :key="office.id" :value="office.name">{{
                office.name
              }}</option>
            </select> -->
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
      <table-lawyer> </table-lawyer>
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
import TableLawyer from "./tables/TableLawyer.vue";

export default {
  components: {
    TableLawyer,
  },
  data() {
    return {
      selected:undefined,
      searchStatus: "",
      searchName: "",
      searchEmail: "",

      errorMessage: "",
      inpEmail: "",
      inpName: "",
      nameErr: '',
      emailErr: '',
      listUser: [],
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
          name: "All",
        },
        {
          name: "Inactive",
        },
        {
          name: "Active",
        },
      ],
    };
  },
  created() {
    if (localStorage.getItem("role") !== "admin") {
      this.$router.push("/");
    } 
    // else {
    //   // this.$store.dispatch("lawyer/getUserListApi");
    // }
  },
  // computed: {
  //    ...mapState('office',{
  //     listOfficer: "listOfficer"
  //   }),
  // },
  methods: {
    // searchOfficeName(ev){
    //   var level = ev.target.value

    //   console.log(level)
    //   if(this.selected !== undefined){
    //     // this.$store.dispatch("office/searchLawyerOfficeByLevel", level);
    //   }else{
    //     // this.$store.dispatch("office/getListLawyerOffice");
    //   }
           
    //   this.searchName = "",
    //   this.searchEmail = ""
    // },


    searchByStatus(ev){
      var status = ev.target.value
      var intStatus
      if(status === 'Inactive'){
        intStatus = 0;
      }else if(status === 'Active'){
        intStatus = 1;
      }else{
        intStatus = -1
      }

      if(intStatus !== -1){
        this.$store.dispatch("lawyer/searchLawyerByStatus", intStatus);
      }else{
        this.$store.dispatch("lawyer/getListLawyer");
      }
      this.searchName = "",
      this.searchEmail = ""
    },
    searchByName(username){
      this.$store.dispatch("lawyer/searchLawyerByName", username);
      this.selected = undefined
      this.searchEmail = ''
    },
    searchByEmail(email){
      this.$store.dispatch("lawyer/searchLawyerByEmail", email);
      this.selected = undefined
      this.searchName = ''
    },
    onUpdate() {
      this.$refs.table.refresh();
    },
    banUser(id) {
      this.$store.dispatch("lawyer/changeStatusUser", id);
    },
    // updateCustomerRole(id,role){
    //   this.$store.dispatch("updateCustomerRole", {id,role})
    // },
    createLawyerAccount(inpName, inpEmail) {
      if (inpName.trim() !== "" && inpEmail.trim() !== "") {
        try {
          this.$store.dispatch("lawyer/createLawyer", { inpName, inpEmail });
            this.$fire({
              title: "Add Successful",
              type: "success",
              timer: 3000,
            }).then((r) => {
              console.log(r.value);
            });
        } catch (error) {
          this.errorMessage = "error";
        }
      } else {
        if (inpName.trim() == "") {
          this.emailErr = "Please input Office's email";
        }
        if (inpEmail.trim() == "") {
          this.nameErr = "Please input Office's name";
        }
      }
    },
  },
  
};
</script>
<style lang="scss" scoped></style>

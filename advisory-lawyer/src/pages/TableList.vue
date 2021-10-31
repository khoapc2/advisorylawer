<template>
  <div class="row">
    <div class="col-12">
      <card title="Customer's Management" subTitle="">
        <form @submit.prevent>
          <div class="row">
            <div class="col-md-4">
              <fg-input
                type="email"
                label="Customer's Email"
                placeholder="example@example.com"
                v-model="inpEmail"
              >
              </fg-input>
              <label v-if="emailErr !== ''" style="color: red">
                {{ emailErr }}
              </label>
            </div>
            <div class="col-md-6">
              <fg-input
                type="text"
                label="Customer's Name"
                placeholder="Customer's Full Name"
                v-model="inpName"
              >
              </fg-input>
              <label v-if="nameErr !== ''" style="color: red">
                {{ nameErr }}
              </label>
            </div>
            <div class="col-md-2">
              <p-button
                type="info"
                round
                @click.native.prevent="createCustomerAccount(inpName, inpEmail)"
              >
                Create Customer</p-button
              ><br />
            </div>
          </div>

          <div class="row"></div>
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

    <h3>Customer's Detail</h3>
    <table class="table" ref="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col" >Name</th>
          <th scope="col" >Email</th>
          <th scope="col" >Status</th>
          <th scope="col" colspan="2" style="text-align:center">Action</th>
        </tr>
      </thead>
      <table-customer> </table-customer>
    </table>
    <ul class="pagination justify-content-center" style="margin:auto;">
      <li class="page-item"><a class="page-link btn" href="#">Previous</a></li>
      <li class="page-item"><a class="page-link btn" href="#">1</a></li>
      <li class="page-item"><a class="page-link btn" href="#">2</a></li>
      <li class="page-item"><a class="page-link btn" href="#">3</a></li>
      <li class="page-item"><a class="page-link btn" href="#">Next</a></li>
    </ul>
  </div>
</template>
<script>
import { mapActions, mapGetters, mapState } from "vuex";
import TableCustomer from "./tables/TableCustomer.vue";
export default {
  components: {
    TableCustomer,
  },
  data() {
    return {
      emailErr: "",
      nameErr: "",
      inpEmail: "",
      inpName: "",
      listUser: [],
      errorMessage:'',
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
          name: "",
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
    } else {
      this.$store.dispatch("getUserListApi");
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
    }),
  },
  methods: {
    
    onUpdate() {
      this.$refs.table.refresh();
    },
    banUser(id) {
      this.$store.dispatch("changeStatusUser", id);
    },
    updateCustomerRole(id, role) {
      this.$store.dispatch("updateCustomerRole", { id, role });
    },
    createCustomerAccount(inpName, inpEmail) {
      if (inpName.trim() !== "" && inpEmail.trim() !== "") {
        try {
          this.$store.dispatch("createCustomer", {inpName,inpEmail})
          this.inpName = '',
          this.inpEmail = ''
          this.errorMessage = "success"
        }catch(error){
          this.errorMessage = "error"
        }
      }
      else {
        if(inpName.trim() == ''){
          this.emailErr = 'Please input your email'
        }
        if (inpEmail.trim() == "") {
          this.nameErr = "Please input your name";
        }
      }
    },
  },
  mounted() {
    this.$store.dispatch("getUserListApi");
  },
};
</script>
<style lang="scss" scoped></style>

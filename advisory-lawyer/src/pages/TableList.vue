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
                Create Account</p-button
              ><br />
            </div>
          </div>

          <div class="row"></div>

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
        <tr>
          <td>
            <div class="form-horizontal">
              <input
                type="text"
                name="..."
                class="form-control"
                placeholder="Search People..."
                style="width:280px;max-width:280px;display:inline-block"
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
            />
          </td>
          <td>
            <select class="form-control" :required="true">
              <option v-for="option in statusOption" :key="option.name">{{
                option.name
              }}</option>
            </select>
          </td>
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
      console.log(id);
      this.$store.dispatch("changeStatusUser", id);
    },
    updateCustomerRole(id, role) {
      this.$store.dispatch("updateCustomerRole", { id, role });
    },
    createCustomerAccount(inpName, inpEmail) {
      if (inpName.trim() !== "" && inpEmail.trim() !== "") {
        console.log(inpName, inpEmail);
        this.$store.dispatch("createCustomer", { inpName, inpEmail });
      } else {
        if (inpName.trim() == "") {
          this.emailErr = "Please input your email";
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

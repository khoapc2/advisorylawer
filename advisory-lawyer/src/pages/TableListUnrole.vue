<template>
  <div class="row">
    <!-- <div class="col-12"> -->
      <!-- <card title="Unrole User's Management" subTitle="">
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
            </div>
            <div class="col-md-6">
              <fg-input
                type="text"
                label="Customer's Name"
                placeholder="Customer's Full Name"
                v-model="inpName"
              >
              </fg-input>
            </div>
          </div>

          <div class="row"></div>

          <div class="text-center">
            <p-button type="info" round @click.native.prevent="createCustomerAccount(inpName,inpEmail)">
              Create Account
            </p-button>
            <p v-if="message !== ''"> {{message}} </p>
          </div>
          <div class="clearfix"></div>
        </form>
      </card>
    </div> -->

    <h3>Unrole User's Detail</h3>
    <table class="table" ref="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col" style="text-align:center">Name</th>
          <th scope="col" style="text-align:center">Email</th>
          <th scope="col" style="text-align:center">Role</th>
          <th scope="col" style="text-align:center">Status</th>
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
      <table-unrole>

      </table-unrole>
    </table>

    <ul class="pagination justify-content-center" style="margin:20px 0">
      <li class="page-item"><a class="page-link" href="#">Previous</a></li>
      <li class="page-item"><a class="page-link" href="#">1</a></li>
      <li class="page-item"><a class="page-link" href="#">2</a></li>
      <li class="page-item"><a class="page-link" href="#">3</a></li>
      <li class="page-item"><a class="page-link" href="#">Next</a></li>
    </ul>
  </div>
</template>
<script>
import { mapActions, mapGetters, mapState } from "vuex";
import TableUnrole from './tables/TableUnrole.vue'

export default {
  components: {
    TableUnrole
    },
  data() {
    return {
      message: '',
      inpEmail: '',
      inpName: '',
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
          name: ""
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
      this.$store.dispatch("getListUnroleUser");
    }

    // this.listUser = this._getUserList
    // listUser = _getUserList
  },
  computed: {
    ...mapState({
      customerList: "listUnroleUser",
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
    updateRole(id,role){
      this.$store.dispatch("updateUnroleUser", {id,role})
    },
    createCustomerAccount(inpName, inpEmail){
      if(inpName.trim() !== '' && inpEmail.trim() !== ''){
        console.log(inpName, inpEmail);
        this.$store.dispatch("createCustomer", {inpName,inpEmail})
      }
      else {
        this.message = "Create fail"
      }
    }
  },
  mounted() {
    this.$store.dispatch("getUserListApi");
  },
};
</script>
<style lang="scss" scoped></style>

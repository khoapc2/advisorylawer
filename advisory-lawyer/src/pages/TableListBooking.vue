<template>
  <div class="row">
    <h3>Booking Detail</h3>
    <table class="table" ref="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col" style="text-align:center">Customer's Name</th>
          <th scope="col" style="text-align:center">Lawyer's Name</th>
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
    
 
    createCustomerAccount(inpName, inpEmail){
      if(inpName.trim() !== '' && inpEmail.trim() !== ''){
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

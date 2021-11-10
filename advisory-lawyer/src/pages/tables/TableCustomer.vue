

<template>
<!-- #                        _oo0oo_                 -->
<!-- #                       o8888888o                -->
<!-- #                       88" . "88                -->
<!-- #                       (| -_- |)                -->    
<!-- #                       0\  =  /0                -->
<!-- #                     ___/`---'\___              -->
<!-- #                   .' \|     |// '.             -->
<!-- #                  / \|||  :  |||// \            -->
<!-- #                 / _||||| -:- |||||- \          -->
<!-- #                |   | \\  -  /// |   |          -->
<!-- #                | \_|  ''\---/''  |_/ |         -->
<!-- #                \  .-\__  '-'  ___/-. /         -->
<!-- #              ___'. .'  /--.--\  `. .'___       -->
<!-- #           ."" '<  `.___\_<|>_/___.' >' "".     -->
<!-- #          | | :  `- \`.;`\ _ /`;.`/ - ` : | |   -->
<!-- #          \  \ `_.   \_ __\ /__ _/   .-` /  /   -->
<!-- #      =====`-.____`.___ \_____/___.-`___.-'===== -->
<!-- #                        `=---=' -->
  <tbody>
        <CustomerModal :edit="customer"/>
        <tr>
          <td>
            <div class="form-horizontal">
              <input
                type="text"
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
              <option  v-for="option in statusOption" :key="option.name" :value="option.name" >{{
                option.name
              }}</option>
            </select>
          </td>
        </tr>
        <tr v-for="user in customerList" :key="user.id">
          <!-- <th scope="row">1</th> -->
          <td style="display:none">{{ user.id }}</td>
          <td>          
            {{user.name}}
          </td>
          <!-- <td>{{ user.address }}</td> -->
          <!-- <td>{{ user.phone_number }}</td> -->
          <!-- <td>{{ user.sex }}</td> -->
          <td>{{ user.email }}</td>
          
            <!-- <select class="form-control" v-model="user.role" :required="true">
              <option v-for="option in roleOption" :key="option.name">{{
                option.name
              }}</option>
            </select> -->
          
          <td v-if="user.status === 1">Active</td>
          <td v-else>Inactive</td>
          <td>
            <!-- <button type="button" class="btn btn-warning" style="float: left" @click="updateCustomerRole(user.id,user.role)">
              Update
            </button> -->
            <button
              type="button"
              class="btn btn-outline-info"
              style="float: right"
              v-b-modal.modal-prevent-closing
              @click="clickViewDetail(user)"
            >
            Detail
            </button>
            <button
              v-if="user.status === 1"
              type="button"
              class="btn btn-outline-danger"
              style="float: right"
              @click="banUser(user.id)"
            >
              Ban
            </button>
            <button
              v-else-if="user.status === 0"
              type="button"
              class="btn btn-outline-danger"
              style="float: right"
              @click="banUser(user.id)"
            >
              Unbanned
            </button>
          </td>
        </tr>
      </tbody>
</template>

<script>
import { mapActions, mapState } from "vuex";
import CustomerModal from '../modals/CustomerModal.vue';
export default {
  components :{
    CustomerModal
  },
  data() {
    return {
      selected:undefined,
      searchStatus: "",
      searchName: "",
      searchEmail: "",
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
      this.$store.dispatch("customer/getUserListApi");
    }
  },
  computed: {

    ...mapState('customer',{
      customerList: "listUser",
      customer: "customer"
    }),
  },
  methods: {
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
        this.$store.dispatch("customer/searchByStatus", intStatus);
      }else{
        this.$store.dispatch("customer/getUserListApi");
      }
      this.searchName = "",
      this.searchEmail = ""
    },
    searchByName(username){
      this.$store.dispatch("customer/searchByName", username);
      this.selected = undefined
      this.searchEmail = ''
    },
    searchByEmail(email){
      this.$store.dispatch("customer/searchByEmail", email);
      this.selected = undefined
      this.searchName = ''
    },

    clickViewDetail(user) {
      this.$store.dispatch("customer/getCustomerByEmail", user.email) 
    },
    onUpdate() {
     this.$refs.table.refresh();
    },
    banUser(id) {
      try {
      this.$store.dispatch("customer/changeStatusUser", id);
        this.$fire({
        title: "Add Successful",
        type: "success",
        timer: 3000,
      }).then((r) => {
        console.log(r.value);
      });
      } catch (err) {
        console.log(err)
      }
    },
    mounted() {
      this.$store.dispatch("customer/getUserListApi");
    },
  },
};
</script>

  









  



<style lang="scss" scoped></style>>

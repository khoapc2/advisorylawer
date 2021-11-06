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
            </div>
            <div class="col-md-2">
            <p-button type="info" round @click="addLawyer(inpEmail)">
              Add lawyer
            </p-button>
            <p v-if="message !== ''"> {{message}} </p>
          </div>
          </div>
          <div class="row"></div>
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
          <th scope="col" >Level</th>
          <th scope="col" >Sex</th>
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
              <select class="form-control" :required="true" v-model="selected" @change="searchByLevel($event)">
                  <option :value="undefined" >All</option>
                  <option v-for="level in listLevel" :key="level.id" :value="level.id">{{
                    level.level_name
                  }}</option>
              </select>
          </td>
        </tr>
      </thead>
      <table-officer-management-lawyer>

      </table-officer-management-lawyer>
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
import {mapState } from "vuex";
import TableOfficerManagementLawyer from './tables/TableOfficerManagementLawyer.vue'

export default {
  components: {
    TableOfficerManagementLawyer
    },
  data() {
    return {
      selected:undefined,
      searchLevel: "",
      searchName: "",
      searchEmail: "",

      message: '',
      inpEmail: '',
    };
  },
  created() {
    if (localStorage.getItem("role") !== "lawyer_office") {
      this.$router.push("/");
    } 
    // else {
    //   // this.$store.dispatch("office/getUserListApi");
    // }
  },
  computed: {
    ...mapState('office',{
      listLevel: "level"
    }),
  },
  methods: {
    addLawyer(lawyerEmail){
      try{
        this.$store.dispatch("office/addLawyerToOffice", lawyerEmail);
        this.inpEmail = "";
        this.$fire({
        title: "Add Successful",
        type: "success",
        timer: 3000,
      }).then((r) => {
        console.log(r.value);
      });
      }catch(error){
        console.log(error)
      }
    },
    searchByLevel(ev){
      var level = ev.target.value
      
      if(this.selected !== undefined){
        this.$store.dispatch("office/searchLawyerOfficeByLevel", level);
      }else{
        this.$store.dispatch("office/getListLawyerOffice");
      }
           
      this.searchName = "",
      this.searchEmail = ""
    },
    searchByName(name){
      this.$store.dispatch("office/searchLawyerOfficeByName", name);
      this.selected = undefined
      this.searchEmail = ''
    },
    searchByEmail(email){
      this.$store.dispatch("office/searchLawyerOfficeByEmail", email);
      this.selected = undefined
      this.searchName = ''
    },
    onUpdate() {
     this.$refs.table.refresh();
    },
  },
  mounted() {
    // this.$store.dispatch("getUserListApi");
    this.$store.dispatch("office/getLevel");
  },
};
</script>
<style lang="scss" scoped></style>

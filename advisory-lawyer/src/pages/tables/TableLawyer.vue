<template>
  <tbody>
        <LawyerModal :edit="lawyer"/>
        <tr v-for="user in listLawyer" :key="user.id">
          <td style="display:none">{{ user.id }}</td>
          <td>
            {{user.name}}
          </td>
          <td>{{ user.email }}</td>
          

            <!-- <select class="form-control" v-model="user.role" :required="true">
              <option v-for="option in roleOption" :key="option.name">{{
                option.name
              }}</option>
            </select> -->
          <td>{{ user.office_name }}</td>
          
          <td v-if="user.status === 1">Active</td>
          <td v-else>Inactive</td>
          <td>
            <!-- <button type="button" class="btn btn-warning" style="float: left" @click="updateRole(user)">
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
import {mapState } from "vuex";
import LawyerModal from '../modals/LawyerModal.vue';
export default {
  components :{
    LawyerModal
  },
  data() {
    return {
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
      // this.$store.dispatch("getUserListApi");
    }
  },
  computed: {
    ...mapState('lawyer',{
      listLawyer: "listLawyer",
      lawyer: "lawyer"
    }),
  },
  methods: {
    clickViewDetail(user) {
      console.log(user.name)
      this.$store.dispatch("lawyer/getLawyerByEmail", user.email) 
    },
    onUpdate() {
     this.$refs.table.refresh();
    },
    banUser(id) {
      this.$store.dispatch("lawyer/changeStatusLawyer", id);
    },
    updateRole(user){
      this.$store.dispatch("lawyer/updateUnroleUser", {user})
    },
  },
  mounted() {
    this.$store.dispatch("lawyer/getListLawyer");
  },
};
</script>

<style lang="scss" scoped></style>>

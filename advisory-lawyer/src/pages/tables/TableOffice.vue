<template>
  <tbody>
        <tr v-for="user in listOffice" :key="user.id" style="text-align:center">
          <td style="display:none">{{ user.id }}</td>
          <td>
            {{user.name}}
          </td>
          <td>{{ user.email }}</td>
          <td v-if="user.role === 'lawyer_office'">
            lawyer office
            <!-- <select class="form-control" v-model="user.role" :required="true">
              <option v-for="option in roleOption" :key="option.name">{{
                option.name
              }}</option>
            </select> -->
          </td>
          <td v-if="user.status === 1">Active</td>
          <td v-else>Inactive</td>
          <td>
            <!-- <button type="button" class="btn btn-warning" style="float: left" @click="updateRole(user)">
              Update
            </button> -->
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
import { mapActions, mapGetters, mapState } from "vuex";

export default {
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
    ...mapState({
      listOffice: "listOfficer",
    }),
  },
  methods: {
    onUpdate() {
     this.$refs.table.refresh();
    },
    banUser(id) {
      
      this.$store.dispatch("changeStatusOfficer", id);
    },
    updateRole(user){
      this.$store.dispatch("updateUnroleUser", {user})
    },
  },
  mounted() {
    this.$store.dispatch("getListOfficer");
  },
};
</script>

  









  



<style lang="scss" scoped></style>>

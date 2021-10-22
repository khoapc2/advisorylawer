<template>
  <tbody>
        <tr v-for="user in unroleUserList" :key="user.id" style="text-align:center">
          <!-- <th scope="row">1</th> -->
          <td style="display:none">{{ user.id }}</td>
          <td>
            {{user.name}}
          </td>
          <!-- <td>{{ user.address }}</td> -->
          <!-- <td>{{ user.phone_number }}</td> -->
          <!-- <td>{{ user.sex }}</td> -->
          <td>{{ user.email }}</td>
          <td>
            <!-- {{ user.role }} -->
            <select class="form-control" v-model="user.role" :required="true">
              <option v-for="option in roleOption" :key="option.name">{{
                option.name
              }}</option>
            </select>
          </td>
          <td v-if="user.status === 1">Active</td>
          <td v-else>Inactive</td>
          <td>
            <button type="button" class="btn btn-warning" style="float: left" @click="updateRole(user)">
              Update
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
import { mapActions, mapGetters, mapState } from "vuex";

export default {
  data() {
    return {
      
      listUser: [],
      roleOption: [
        {
          name: '',
        },
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
          name: "lawyer office",
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
      unroleUserList: "listUnroleUser",
    }),
  },
  methods: {
    onUpdate() {
     this.$refs.table.refresh();
    },
    banUser(id) {
      console.log(id);
      this.$store.dispatch("updateStatusUnrole", id);
    },
    updateRole(user){
      this.$store.dispatch("updateUnroleUser", {user})
    },
  },
  mounted() {
    this.$store.dispatch("getListUnroleUser");
  },
};
</script>

  









  



<style lang="scss" scoped></style>>

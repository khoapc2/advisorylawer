<template>
  <tbody>
        <tr v-for="user in listOfficeLawyer" :key="user.id" style="text-align:center">
          <td style="display:none">{{ user.id }}</td>
          <td>
            {{user.name}}
          </td>
          <td>{{ user.email }}</td>
          <td>
            <select class="form-control" v-model="user.level_id" :required="true">
              <option v-for="level in listLevel" :key="level.id" :value="level.id">{{
                level.level_name
              }}</option>
            </select>
          </td>
          <td>{{user.sex}}</td>
          <td>
            <button type="button" class="btn btn-warning" style="float: left" @click="updateLevel(user)">
              Update
            </button>
            <button
              type="button"
              class="btn btn-outline-danger"
              style="float: right"
              @click="deleteUser(user.id)"
            >
              Delete
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
      levelOption: [
        {
          name: "1",
        },
        {
          name: "2",
        },
      ],
    };
  },
  created() {
    if (localStorage.getItem("role") !== "lawyer_office") {
      this.$router.push("/");
    } else {
      // this.$store.dispatch("getUserListApi");
    }
  },
  computed: {
    ...mapState({
      listOfficeLawyer: "listOfficerManagementLawyer",
      listLevel: "level"
    }),
  },
  methods: {
    onUpdate() {
     this.$refs.table.refresh();
    },
    deleteUser(id) {
      this.$store.dispatch("removeLawyerFromOffice", id);
    },
    updateLevel(user){
      console.log(user)
      this.$store.dispatch("updateLevelLawyer", user)
    },

  },
  mounted() {
    this.$store.dispatch("getListLawyerOffice");
    this.$store.dispatch("getLevel");
  },
};
</script>

<style lang="scss" scoped></style>>

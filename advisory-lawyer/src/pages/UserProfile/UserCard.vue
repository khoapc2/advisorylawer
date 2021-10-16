<template>
  <card class="card-user">
    <div slot="image">
      <img src="@/assets/img/background_user.jpg" alt="..." />
    </div>
    <div>
      <div class="author">
        <img class="avatar border-white" :src="photo" alt="..." />
        <h4 class="title">
          {{ name }}
          <br />
          <!-- <a href="#"> -->
          <small v-if='role === "admin"' >Admin</small>
          <small v-if='role === "lawyer_office"'>Officer</small>

          <!-- </a> -->
        </h4>
      </div>
      <!-- <p class="description text-center">
        "I like the way you work it
        <br> No diggity
        <br> I wanna bag it up"
      </p> -->
    </div>
    <hr />
    <!-- <div class="text-center">
      <div class="row">
        <div
          v-for="(info, index) in details"
          :key="index"
          :class="getClasses(index)"
        >
        </div>
      </div>
    </div> -->
  </card>
</template>
<script>
export default {
  data() {
    return {
      idToken: "",
      name: "",
      photo: "",
      email: "",
      role: "",
    };
  },
  created() {
    this.role = localStorage.getItem("role");
    if (
       this.role === "admin" || this.role === "lawyer_office"
    ) {
       console.log("Come Here");
      this.name = localStorage.getItem("displayName");
      this.photo = localStorage.getItem("photoURL");
      this.email = localStorage.getItem("email");
    } else {
      this.$router.push("/");
    }
  },
  methods: {
    getClasses(index) {
      var remainder = index % 3;
      if (remainder === 0) {
        return "col-lg-3 offset-lg-1";
      } else if (remainder === 2) {
        return "col-lg-4";
      } else {
        return "col-lg-3";
      }
    },
  },
};
</script>
<style></style>

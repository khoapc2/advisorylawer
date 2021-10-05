<template>
  <card class="card-user">
    <div slot="image">
      <img src="@/assets/img/background_user.jpg" alt="...">
    </div>
    <div>
      <div class="author">
        <img class="avatar border-white" :src="photo" alt="...">
        <h4 class="title"> {{name}}
          <br>
          <!-- <a href="#"> -->
            <small>Admin</small>
          <!-- </a> -->
        </h4>
      </div>
      <!-- <p class="description text-center">
        "I like the way you work it
        <br> No diggity
        <br> I wanna bag it up"
      </p> -->
    </div>
    <hr>
    <div class="text-center">
      <div class="row">
        <div v-for="(info, index) in details" :key="index" :class="getClasses(index)">
          <h5>{{info.title}}
            <br>
            <small>{{info.subTitle}}</small>
          </h5>
        </div>
      </div>
    </div>
  </card>
</template>
<script>
import firebase from 'firebase'
import {mapState} from 'vuex'

export default {
  data() {
    return {
      name: '',
      photo: '',
      email: '',
      details: [
        {
          title: "",
          subTitle: ""
        },
        {
          title: "",
          subTitle: ""
        },
        {
          title: "",
          subTitle: ""
        }
      ]
    };
  },
  created() {
    firebase.auth().onAuthStateChanged((user) => {
      if (user) {
        this.user = user;
        this.name = this.user.displayName;
        this.email = this.user.email;
        this.photo = this.user.photoURL;
      }
    });




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
  computed: 
  mapState([])
  



};
</script>
<style>
  
</style>

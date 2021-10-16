<template>
  <div class="page-header clear-filter" filter-color="orange">
    <div
      class="page-header-image"
      style="background-image: url('img/background_mainscreen.jpg')"
    ></div>
    <div class="content">
      <div class="container">
        <div class="col-md-5 ml-auto mr-auto">
          <!-- <card type="login" plain> -->
          <!-- <div slot="header" class="logo-container">
              <img v-lazy="'img/now-logo.png'" alt="" />
            </div> -->

          <section id="firebaseui-auth-container"></section>
          <p v-if="checkAuth">Tài Khoản của bạn không được phép vào hệ thống</p>

          
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { Card, Button, FormGroupInput } from "@/components";
import { firebaseConfig } from "../components/helpers/firebaseConfig";
import firebase from "firebase";
import firebaseui from "firebaseui";
import "firebaseui/dist/firebaseui.css";

import axios from "axios";
import {mapActions,mapGetters} from 'vuex'
export default {
  data() {
    return {
      user: null,
      ui: '',
      checkAuth: false,
    };
  },
  mounted() {
    var uiConfig = {
      signInSuccessUrl: "/",
      signInOptions: [firebase.auth.GoogleAuthProvider.PROVIDER_ID],
    };
    if (firebaseui.auth.AuthUI.getInstance()) {
      this.ui = firebaseui.auth.AuthUI.getInstance();
      this.ui.start("#firebaseui-auth-container", uiConfig);
    } else {
      this.ui = new firebaseui.auth.AuthUI(firebase.auth());
      this.ui.start("#firebaseui-auth-container", uiConfig);
    }
  },
  computed: {
    ...mapGetters({
      _getUser: 'getUser'
    }
      
    )
  },
  methods: {
    ...mapActions({
      userInfor: 'getUserInfo'
      })
  },
 
  
  created() {
    if (firebase.apps.length === 0) {
      firebase.initializeApp(firebaseConfig);
      firebase.auth().onAuthStateChanged((user) => {
        if (user) {
          user
            .getIdToken()
            .then(async (idTokenn) => {
              console.log("ID Token: ", idTokenn);
              await Promise.resolve(
                axios({
                  method: "POST",
                  url: "https://104.215.186.78/api/v1/authentications/login",
                  data: {
                    id_token: `${idTokenn}`,
                  },
                  headers: {
                    "Content-Type": "application/json; charset=utf-8",
                  },
                })
              )
                .then((res) => {
                  const data = res.data;
                    (this.user = {
                      role: data.role,
                    });
                    localStorage.setItem("tokenID",  data.token);
                    localStorage.setItem("displayName",  user.displayName);
                    localStorage.setItem("email",  user.email);
                    localStorage.setItem("photoURL",  user.photoURL);
                    localStorage.setItem("role", this.user.role);
                    console.log(this.user.role)


                    console.log("LocalStorage  " + localStorage.getItem("tokenID"))
                  this.userInfor(this.user);
                  // console.log(this.user.role), console.log(this.user.userToken);
                  if ("admin" === this.user.role || "lawyer_office" === this.user.role) {
                    console.log('Here')
                    this.$router.push("/stats");
                  // } else if ("lawyer_office" === this.user.role){
                  //   this.$router.push("/stats-lawyer_office");
                  }else {
                    console.log('Here Else')
                    this.checkAuth = true;
                    this.$router.push('/')
                  }
                })
                .catch(error => {console.log(error), this.checkAuth = true});
            })
            .catch((error) => {
              console.log(error);
            });
        }
      });
    }
  },
};
</script>
<style></style>

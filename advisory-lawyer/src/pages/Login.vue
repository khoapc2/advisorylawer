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

          <section id="firebaseui-auth-container" ></section>

          <!-- <fg-input
              class="no-border input-lg"
              addon-left-icon="now-ui-icons users_circle-08"
              placeholder="First Name..."
            >
            </fg-input> -->
          <!-- 
            <fg-input
              class="no-border input-lg"
              addon-left-icon="now-ui-icons text_caps-small"
              placeholder="Last Name..."
            >
            </fg-input> -->

          <!-- <div id="firebaseui-auth-container"></div> -->

          <!-- <template slot="raw-content">
              <div class="card-footer text-center">
                <a
                  href="#/dashboard"
                  class="btn btn-primary btn-round btn-lg btn-block"
                  >Get Started</a>
              </div> -->

          <!-- <div class="pull-left">
                <h6>
                  <a href="#pablo" class="link footer-link">Create Account</a>
                </h6>
              </div>
              <div class="pull-right"> -->
          <!-- <h6>
                  <a href="#pablo" class="link footer-link">Need Help?</a>
                </h6> -->
          <!-- </div> -->
          <!-- </template> -->
          <!-- </card> -->
        </div>
      </div>
    </div>
    <!-- <main-footer></main-footer> -->
  </div>
</template>
<script>
import { Card, Button, FormGroupInput } from "@/components";
// import firebase from "firebase/compat/app";
// import "firebase/compat/auth";
import {firebaseConfig} from '../components/helpers/firebaseConfig';
import firebase from "firebase";
import firebaseui from "firebaseui";
import "firebaseui/dist/firebaseui.css";

import axios from "axios";

// 

// import MainFooter from '@/layout/MainFooter';
export default {
  data() {
    return {
        
    };
  },
  mounted() {
    var uiConfig = {
      signInSuccessUrl: "/",
      signInOptions: [
        firebase.auth.GoogleAuthProvider.PROVIDER_ID,
      ],
    };
    var ui = new firebaseui.auth.AuthUI(firebase.auth());

    // firebase.auth().currentUser.getIdToken(true).then(function(idToken) {
    //                 console.log('ID Tokennnn: ', idToken);
    //             }).catch(function(error) {

    //             });



    ui.start("#firebaseui-auth-container", uiConfig);

  },

  created() {
    firebase.initializeApp(firebaseConfig);
    firebase.auth().onAuthStateChanged((user) => {
      if(user) {
        user.getIdToken().then((idTokenn) => {
          console.log('ID Token: ', idTokenn);
          
          axios({
                method: 'POST',
                url:'https://104.215.186.78/api/authentications/login', 
                data: {
                  'idToken' : `${idTokenn}`
                }, 
                headers:{'Content-Type': 'application/json; charset=utf-8'}
            }).then(res => console.log(res)).catch(error => console.log('There was an error: ' + error))

        }).catch((error) => {
          console.log(error)
        }) 
        this.$router.push('/')
      } else {
        this.$router.push('/')
      }      
     });
    },
  mounted() {
    var uiConfig = {
      signInSuccessUrl: "/",
      signInOptions: [
        firebase.auth.GoogleAuthProvider.PROVIDER_ID,
      ],
    };
    var ui = new firebaseui.auth.AuthUI(firebase.auth());
    ui.start("#firebaseui-auth-container", uiConfig);
    },

  



};
</script>
<style></style>

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
import { firebaseConfig } from "../components/helpers/firebaseConfig";
import firebase from "firebase";
import firebaseui from "firebaseui";
import "firebaseui/dist/firebaseui.css";

import axios from "axios";

//

// import MainFooter from '@/layout/MainFooter';
export default {
  data() {
    return {
      user: null,
      ui: '',
    };
  },
  mounted() {
    var uiConfig = {
      signInSuccessUrl: "/",
      signInOptions: [firebase.auth.GoogleAuthProvider.PROVIDER_ID],
    };

    if (firebaseui.auth.AuthUI.getInstance()) {
      this.ui = firebaseui.auth.AuthUI.getInstance();
      ui.start("#firebaseui-auth-container", uiConfig);
    } else {
      this.ui = new firebaseui.auth.AuthUI(firebase.auth());
      ui.start("#firebaseui-auth-container", uiConfig);
    }
  },
  unmounted() {
     this.ui.delete()
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
                  console.log("Res: " + res);
                  const data = res.data;
                  (this.user = this.$store.state.users),
                    (this.user = {
                      role: data.role,
                      userToken: data.token,
                    });

                  console.log(this.user.role), console.log(this.user.userToken);

                  if (this.user.role === "admin") {
                    this.$router.push("/stats");
                  } else {
                    // this.$router.push('/')
                  }
                })
                .catch((error) => console.log("There was an error: " + error));
            })
            .catch((error) => {
              console.log(error);
            });
        }
      });
    }
  },
  mounted() {
    var uiConfig = {
      signInSuccessUrl: "/",
      signInOptions: [firebase.auth.GoogleAuthProvider.PROVIDER_ID],
    };
    var ui = new firebaseui.auth.AuthUI(firebase.auth());
    ui.start("#firebaseui-auth-container", uiConfig);
  },
};
</script>
<style></style>

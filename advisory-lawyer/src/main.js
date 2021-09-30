/*!

 =========================================================
 * Vue Now UI Kit - v1.1.0
 =========================================================

 * Product Page: https://www.creative-tim.com/product/now-ui-kit
 * Copyright 2019 Creative Tim (http://www.creative-tim.com)

 * Designed by www.invisionapp.com Coded by www.creative-tim.com

 =========================================================

 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 */
import Vue from 'vue';
import App from './App.vue';
// You can change this import to `import router from './starterRouter'` to quickly start development from a blank layout.
import router from './router';
import NowUiKit from './plugins/now-ui-kit';
import PaperDashboard from "./plugins/paperDashboard"

import firebase from 'firebase'
import {firebaseConfig} from './components/helpers/firebaseConfig'


Vue.config.productionTip = false;
Vue.use(PaperDashboard);
Vue.use(NowUiKit);

// var firebaseConfig = {
//   apiKey: "AIzaSyAgzYKDm5O_9woBI9Srik46ZANGT8mDa40",
//   authDomain: "advisory-lawyer.firebaseapp.com",
//   projectId: "advisory-lawyer",
//   storageBucket: "advisory-lawyer.appspot.com",
//   messagingSenderId: "71355061912",
//   appId: "1:71355061912:web:61e5c3d1d9040ee2c422ed"
// };

// firebase.initializeApp(firebaseConfig)

new Vue({
  router,
  created() {
    firebase.initializeApp(firebaseConfig);
    firebase.auth().onAuthStateChanged((user) => {
      if(user) {
        user.getIdToken().then((idToken) => {
          console.log('ID Tokennnn: ', idToken);
        }).catch((error) => {
          console.log(error)
        }) 
        this.$router.push('/dashboard')
      } else {
        this.$router.push('/')
      }
     });
    },
  
  render: h => h(App)
}).$mount('#app');

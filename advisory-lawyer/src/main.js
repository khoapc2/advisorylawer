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
import VueSimpleAlert from "vue-simple-alert";

// You can change this import to `import router from './starterRouter'` to quickly start development from a blank layout.
import router from './router';
import NowUiKit from './plugins/now-ui-kit';
import PaperDashboard from "./plugins/paperDashboard"
import { store } from './store/index';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';




Vue.use(VueSimpleAlert);
Vue.use(VueSimpleAlert, { reverseButtons: true });

Vue.use(BootstrapVue);
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin);
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
  store,
  render: h => h(App)
}).$mount('#app');

import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);
import state from "./states";
import mutations from "./mutations";
import actions from './actions';
import customerModule from './modules/customer/index.js';
import lawyerModule from './modules/lawyer/index.js';
import officeModule from './modules/office/index.js';
import unroleUser from './modules/unrole-user/index.js';



export const store = new Vuex.Store({
    modules: {
        customer: customerModule,
        lawyer: lawyerModule,
        office: officeModule,
        unroleUser: unroleUser,
    },
    state,
    mutations,
    actions,
});
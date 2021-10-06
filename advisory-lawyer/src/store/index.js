import Vue from 'vue';
import Vuex from 'vuex';

// import actions from './actions';
// import getters from './getters';
// import mutations from './mutations';

Vue.use(Vuex);


import state from "./states";
import getters from "./getters";
import mutations from "./mutations";
// import * as actions from "./actions";
import actions from './actions';


export const store = new Vuex.Store({
    state,
    getters,
    mutations,
    actions,
    // : {
    //     getUserInfo(context, payload){
    //         context.commit('setUserInfor', payload)
    //     }
    // },
});
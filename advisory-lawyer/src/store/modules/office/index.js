import officeMutations from './mutations.js';
import officeActions from './actions.js';

export default {
    namespaced: true,
    state() {
      return {
        // officer
      listOfficer: [],
      officerProfile:[],
      office:{},
      //officer lawyer
      listOfficerManagementLawyer:[],
      level: [],
      };
    },
    mutations: officeMutations,
    actions: officeActions,
  };
import lawyerMutations from './mutations.js';
import lawyerActions from './actions.js';

export default {
    namespaced: true,
    state() {
      return {
        // Lawyer
        listLawyer: [],
        lawyer:{},
      };
    },
    mutations: lawyerMutations,
    actions: lawyerActions,
  };
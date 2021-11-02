import customerMutations from './mutations.js';
import customerActions from './actions.js';

export default {
    namespaced: true,
    state() {
      return {
        listUser:[],
        statusBan: 0, 
        customer:{},
      };
    },
    mutations: customerMutations,
    actions: customerActions,
  };
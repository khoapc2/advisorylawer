import unroleMutations from "./mutations.js";
import unroleActions from "./actions.js";

export default {
  namespaced: true,
  state() {
    return {
      //Unrole User
      listUnroleUser: [],
    };
  },
  mutations: unroleMutations,
  actions: unroleActions,
};

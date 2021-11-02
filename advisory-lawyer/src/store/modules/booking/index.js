import bookingMutations from "./mutations.js";
import bookingActions from "./actions.js";

export default {
  namespaced: true,
  state() {
    return {
      listBooking: [],
    };
  },
  mutations: bookingMutations,
  actions: bookingActions,
};

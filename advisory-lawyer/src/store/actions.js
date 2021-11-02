export default {
  getUserProfile(context, payload) {
    context.commit("setUserProfile", payload);
  },
}
export default {
    getUser: (state) => state.user,
    
    GET_USER_PROFILE(state) {
        return state.profile 
    },
    GET_LIST_USER(state) {
        return state.listUser.filter(element => element.role === "customer");
    },

    GET_STATUS_BAN(state) {
        return state.listUser.role
    }   
}
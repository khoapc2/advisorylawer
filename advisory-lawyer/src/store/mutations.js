// export const USER_PROFILE = (state, profile) => {
//     state.profile = profile
// };

// export const USER_ROLE = (state, user) => {
//     state.user = user
// };

//HERE 
export default {
    setUserInfor(state, userInfor){
    state.user = userInfor
    },

    setUserProfile(state,userProfile) {
        state.profile = userProfile
    }
};

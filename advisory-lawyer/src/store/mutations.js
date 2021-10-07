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
    },
    
    LIST_USER(state,listUser){
        state.listUser = listUser
    },

    UPDATE_LIST_USER(state, payload) {
        console.log(state);
        console.log(payload.data.current_status)
        console.log("Mutaltion " + payload.data.current_status , "ID: "+ payload.id)
        state.listUser.forEach(element => {
            if(element.id == payload.id) {
                element.status = payload.data.current_status
            }
        })
    }
};

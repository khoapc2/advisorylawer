// export const USER_PROFILE = (state, profile) => {
//     state.profile = profile
// };

// export const USER_ROLE = (state, user) => {
//     state.user = user
// };

//HERE 
export default {
    

    setUserProfile(state,userProfile) {
        state.profile = userProfile
    },
    
    
    
    // Customer
    CUSTOMER(state, data){
        console.log(data);
        state.customer = data
    },

    // Lawyer
    LAWYER(state, data){
        state.lawyer = data
    },

    //Office
    OFFICE(state, data){
        state.office = data
    },

    

};

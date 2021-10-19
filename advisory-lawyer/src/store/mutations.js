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
    
    LIST_USER(state,listUser){
        state.listUser = listUser
    },

    UPDATE_LIST_USER(state, payload) {
        // console.log(state);
        // console.log(payload.data.current_status)
        // console.log("Mutaltion " + payload.data.current_status , "ID: "+ payload.id)
        state.listUser.forEach(element => {
            if(element.id == payload.id) {
                element.status = payload.data.current_status
            }
        })
    },

    UPDATE_CUSTOMER_ROLE(state, payload) {
        // var index = state.listUser.findIndex(user => payload.data.id === user.id);
        // state.listUser = state.listUser.split(index,1)
        // state.listUser.filter(element => element.payload.data.role === "customer")
        if(payload.data.role !== "customer"){
            const i = state.listUser.map(user => user.id).indexOf(payload.data.id);
            state.listUser.splice(i, 1);
        }
    },

    CREATE_ACCOUNT(state, data) {
        if(data !== null){
            state.listUser.push(data);
        }
    },


    //List Officer
    LIST_OFFICER(state, data) {
        if(data != null){
            state.listOfficer = data
        }
    },
    //List Lawyer
    LIST_LAWYER(state, data) {
        if(data != null){
            state.listLawyer = data
        }  
    },

    //List Unrole User
    LIST_UNROLE_USER(state,listUnroleUser){
        state.listUnroleUser = listUnroleUser
    },

    UPDATE_UNROLE_USER(state, payload){
        console.log(payload)
        if(payload !== null) {
            if(payload.data.role !== "undefined"){
                const i = state.listUnroleUser.map(user => user.id).indexOf(payload.data.id);
                state.listUnroleUser.splice(i, 1);
            }
        }
    },
    // Officer 
    LIST_LAWYER_OFFICER(state, data){
        state.listOfficerManagementLawyer = data
    },

    OFFICER_PROFILE(state, data){
        state.officerProfile = data
    },

    // Customer
    CUSTOMER(state, data){
        state.customer = data
    },

    // Lawyer
    LAWYER(state, data){
        state.lawyer = data
    }

};

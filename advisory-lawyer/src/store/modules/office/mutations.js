export default {
    //List Officer
    LIST_OFFICER(state, data) {
        if(data != null){
            state.listOfficer = data
        }
    },

    // Officer 
    LIST_LAWYER_OFFICER(state, data){
        state.listOfficerManagementLawyer = data
    },

    OFFICER_PROFILE(state, data){
        state.officerProfile = data
    },

    GET_LEVEL(state,data){
        state.level = data
    }
}
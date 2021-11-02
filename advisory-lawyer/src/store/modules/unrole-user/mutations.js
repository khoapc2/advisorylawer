export default {
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
}
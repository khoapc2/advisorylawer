export default {
    LIST_USER(state,listUser){
        state.listUser = listUser
    },

    UPDATE_LIST_USER(state, payload) {
        state.listUser.forEach(element => {
            if(element.id == payload.id) {
                element.status = payload.data.current_status
            }
        })
    },

    UPDATE_CUSTOMER_ROLE(state, payload) {
        if(payload.data.role !== "customer"){
            const i = state.listUser.map(user => user.id).indexOf(payload.data.id);
            state.listUser.splice(i, 1);
        }
    },
    
    CUSTOMER(state, data){
        state.customer = data
    },
}
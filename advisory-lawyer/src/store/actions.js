// import axios from 'axios'

// export const getUserProfile = ({ commit }) => {
    // axios({
    //     method: "POST",
    //               url: "https://104.215.186.78/api/v1/authentications/login",
    //               headers: {
    //                 "Content-Type": "application/json; charset=utf-8",
    //                 "Bearer": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUaGlzSXNKd3RTdWJqZWN0IiwianRpIjoiZjVhNzYzOTktYTc3MC00M2E2LWI3ZDAtYWQ2Y2I3ODZkYjBmIiwiSWQiOiI0IiwiRW1haWwiOiJraG9hcGNzZTE0MTA5NkBmcHQuZWR1LnZuIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW4iLCJleHAiOjE2MzM0NTkxNjIsImlzcyI6ImFkdmlzb3J5LWxhd3llciIsImF1ZCI6ImFkdmlzb3J5LWxhd3llciJ9.7hHxzoTyd27HRs5sAZpK0bSCTMchHtp2UgHqSfu3Sjk"
    //               },
    // }) .then(response => {
    //     commit('USER_PROFILE',response.data)
    // })
//     get('https://104.215.186.78/api/v1/user-accounts/profile')
//     .then(response => {
//         commit('USER_PROFILE',response.data)
//     })

// }

export default {
    getUserInfo(context, payload){
        context.commit('setUserInfor', payload)
    },
    getUserProfile(context, payload){
        context.commit('setUserProfile', payload)
    }
}
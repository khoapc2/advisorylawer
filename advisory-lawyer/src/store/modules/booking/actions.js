import axios from "axios";

const link = "https://104.215.186.78/";


export default {
  getListBooking(context) {
    const pageIndex = 1;
    const pageSize = 50;
    axios({
      method: "GET",
      url: link + "api/v1/bookings?pageIndex=" + pageIndex + "&pageSize=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_BOOKING", response.data);
    });
  },

  getListBookingByOfficeID(context, id) {
    const idOffice = localStorage.getItem('id');
    axios({
      method: "GET",
      url: link + "api/v1/bookings/office/" + idOffice,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_BOOKING", response.data);
    });
  }

  // searchUnRoleByName(context, username){
  //   const pageSize = 10;
  //   const pageIndex = 1;
  //   const role = "undefined";
  //   axios({
  //     method: "GET",
  //     url:
  //     "https://104.215.186.78/api/v1/user-accounts?name="+username+"&role="+role+"&page_index="+pageIndex+"&page_size="+pageSize,
  //     headers: {
  //       "Content-Type": "application/json; charset=utf-8",
  //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
  //     },
  //   }).then((response) => {
  //     context.commit("LIST_UNROLE_USER", response.data);
  //   });
  // },

  // searchUnRoleByStatus(context, status){
  //   const pageSize = 10;
  //   const pageIndex = 1;
  //   axios({
  //     method: "GET",
  //     url:
  //     "https://104.215.186.78/api/v1/user-accounts?role=undefined&status="+status+"&page_index="+pageIndex+"&page_size="+pageSize,
  //     headers: {
  //       "Content-Type": "application/json; charset=utf-8",
  //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
  //     },
  //   }).then((response) => {
  //     context.commit("LIST_UNROLE_USER", response.data);
  //   });
  // },

  // searchUnRoleByEmail(context, email) {
  //   const pageSize = 10;
  //   const pageIndex = 1;
  //   axios({
  //     method: "GET",
  //     url:
  //     "https://104.215.186.78/api/v1/user-accounts?email="+ email +"&role=undefined&page_index="+ pageIndex +"&page_size=" + pageSize,
  //     headers: {
  //       "Content-Type": "application/json; charset=utf-8",
  //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
  //     },
  //   }).then((response) => {
  //     context.commit("LIST_UNROLE_USER", response.data);
  //   });
  // },

  // getListUnroleUser(context) {
  //   axios({
  //     method: "GET",
  //     url:
  //       "https://104.215.186.78/api/v1/user-accounts?role=undefined&page_index=1",
  //     headers: {
  //       "Content-Type": "application/json; charset=utf-8",
  //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
  //     },
  //   }).then((response) => {
  //     context.commit("LIST_UNROLE_USER", response.data);
  //   });
  // },

  // updateUnroleUser(context, { user }) {
  //   if(user.role === 'lawyer office'){
  //     user.role = 'lawyer_office'
  //   }
  //   axios({
  //     method: "PUT",
  //     url: "https://104.215.186.78/api/v1/user-accounts",
  //     data: {
  //       id: `${user.id}`,
  //       name: `${user.name}`,
  //       email: `${user.email}`,
  //       role: `${user.role}`,
  //       status: `${user.status}`,
  //     },
  //     headers: {
  //       "Content-Type": "application/json; charset=utf-8",
  //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
  //     },
  //   }).then((response) => {
  //     const data = response.data;
  //     context.commit("UPDATE_UNROLE_USER", { data });
  //   });
  // },

  // updateStatusUnrole(context, id){
  //   axios({
  //     method: "PUT",
  //     url: "https://104.215.186.78/api/v1/user-accounts/change-status/",
  //     data: {
  //       id: `${id}`,
  //     },
  //     headers: {
  //       "Content-Type": "application/json; charset=utf-8",
  //       Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
  //     },
  //   }).then(response => {
  //     if(response !== null){
  //     context.dispatch("getListUnroleUser");
  //     }
  //   });
  // },
};

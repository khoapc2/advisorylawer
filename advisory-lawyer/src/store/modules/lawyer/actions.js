
import axios from "axios";

export default {
    //Lawyer
  searchLawyerByName(context, username){
    const pageSize = 10;
    const pageIndex = 1;
    const role = "lawyer";
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?name="+username+"&role="+role+"&page_index="+pageIndex+"&page_size="+pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER", response.data);
    });
  },

  searchLawyerByStatus(context, status){
    const pageSize = 10;
    const pageIndex = 1;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?role=lawyer&status="+status+"&page_index="+pageIndex+"&page_size="+pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER", response.data);
    });
  },


  searchLawyerByEmail(context, email) {
    const pageSize = 10;
    const pageIndex = 1;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?email="+ email +"&role=lawyer&page_index="+ pageIndex +"&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER", response.data);
    });
  },


  getLawyerByEmail(context, email) {
    if(email !== null){
      axios({
        method: "POST",
        url:
          "https://104.215.186.78/api/v1/lawyers/details",
        data:{
          email: `${email}`
        },
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        context.commit("LAWYER", response.data);
      });
    }
  },

  getListLawyer(context) {
    axios({
      method: "GET",
      url:
        "https://104.215.186.78/api/v1/user-accounts?role=lawyer&page_index=1",
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER", response.data);
    });
  },

  changeStatusLawyer(context, id) {
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/user-accounts/change-status",
      data: {
        id: `${id}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      if (response !== null) {
        context.dispatch("getListLawyer");
      }
    });
  },


  createLawyer(context, { inpName, inpEmail }) {
    if (inpEmail !== null && inpName !== null) {
      axios({
        method: "POST",
        url: "https://104.215.186.78/api/v1/user-accounts",
        data: {
          name: `${inpName}`,
          email: `${inpEmail}`,
          role: "lawyer",
        },
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        if (response !== null) {
          context.dispatch("getListOfficer");
        }
      });
    }
  },

}
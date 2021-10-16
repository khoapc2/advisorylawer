import axios from "axios";

export default {
  getUserInfo(context, payload) {
    context.commit("setUserInfor", payload);
  },

  getUserProfile(context, payload) {
    context.commit("setUserProfile", payload);
  },

  //Management Customer
  updateProfileForm(context, user) {
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/user-accounts",
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      const data = response.data;
      context.commit("UPDATE_LIST_USER", { data, id });
    });
  },

  getUserListApi(context) {
    axios({
      method: "GET",
      url: "https://104.215.186.78/api/v1/user-accounts?role=customer",
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_USER", response.data);
    });
  },

  changeStatusUser(context, id) {
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/user-accounts/change-status/",
      data: {
        id: `${id}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      const data = response.data;
      context.commit("UPDATE_LIST_USER", { data, id });
    });
  },

  updateCustomerRole(context, { id, role }) {
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/user-accounts",
      data: {
        id: `${id}`,
        role: `${role}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      const data = response.data;
      context.commit("UPDATE_CUSTOMER_ROLE", { data });
    });
  },

  createCustomer(context, { inpName, inpEmail }) {
    if (inpEmail !== null && inpName != null) {
      axios({
        method: "POST",
        url: "https://104.215.186.78/api/v1/user-accounts",
        data: {
          name: `${inpName}`,
          email: `${inpEmail}`,
          role: "customer",
        },
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        const data = response.data;
        context.commit("CREATE_ACCOUNT", { data });
      });
    }
  },

  //Officer
  getListOfficer(context) {
    axios({
      method: "GET",
      url:
        "https://104.215.186.78/api/v1/user-accounts?role=lawyer_office&page_index=1",
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_OFFICER", response.data);
    });
  },

  changeStatusOfficer(context, id) {
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
        context.dispatch("getListOfficer");
      }
    });
  },

  //Lawyer
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

  //Unrole User
  getListUnroleUser(context) {
    axios({
      method: "GET",
      url:
        "https://104.215.186.78/api/v1/user-accounts?role=undefined&page_index=1",
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_UNROLE_USER", response.data);
    });
  },

  updateUnroleUser(context, { user }) {
    if(user.role === 'lawyer office'){
      user.role = 'lawyer_office'
    }
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/user-accounts",
      data: {
        id: `${user.id}`,
        name: `${user.name}`,
        email: `${user.email}`,
        role: `${user.role}`,
        status: `${user.status}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      const data = response.data;
      console.log(response);
      context.commit("UPDATE_UNROLE_USER", { data });
    });
  },



  //role: Officer Management
  getListLawyerOffice(context) {
    const id = localStorage.getItem('id');
    const pageSize = 10;
    if(id !== null){
      axios({
        method: "GET",
        url:
          "https://104.215.186.78/api/v1/lawyers?lawyer_office_id="+ id + "&page_size=" + pageSize,
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        context.commit("LIST_LAWYER_OFFICER", response.data);
      });
    }
  },
};

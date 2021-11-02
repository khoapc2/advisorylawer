import axios from "axios";

export default {
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
      url: "https://104.215.186.78/api/v1/user-accounts?role=customer&page_index=1&page_size=10",
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
    if (inpEmail !== null && inpName !== null) {
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
        if (response !== null) {
          context.dispatch("getUserListApi");
        }
      });
    }
  },

  //AnTDP
  getCustomerByEmail(context, email) {
    if(email !== null){
      axios({
        method: "POST",
        url:
          "https://104.215.186.78/api/customers/details",
        data:{
          email: `${email}`
        },
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        context.commit("CUSTOMER", response.data);
      });
    }
  },

  getCustomerByEmail(context, email) {
    if(email !== null){
      axios({
        method: "POST",
        url:
          "https://104.215.186.78/api/customers/details",
        data:{
          email: `${email}`
        },
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        context.commit("CUSTOMER", response.data);
      });
    }
  },

  searchByName(context, username){
    const pageSize = 10;
    const pageIndex = 1;
    const role = "customer";
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?name="+username+"&role="+role+"&page_index="+pageIndex+"&page_size="+pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_USER", response.data);
    });
  },

  searchByStatus(context, status){
    const pageSize = 10;
    const pageIndex = 1;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?role=customer&status="+status+"&page_index="+pageIndex+"&page_size="+pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_USER", response.data);
    });
  },


  searchByEmail(context, email) {
    const pageSize = 10;
    const pageIndex = 1;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?email="+ email +"&role=customer&page_index="+ pageIndex +"&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_USER", response.data);
    });
  },





}
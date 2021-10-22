import axios from "axios";

export default {


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
    console.log("1");
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

  //Officer
  getListOfficer(context) {
    axios({
      method: "GET",
      url:
        "https://104.215.186.78/api/v1/user-accounts?role=lawyer_office&page_index=1",
        // https://104.215.186.78/api/v1/lawyers?lawyer_office_id="+ id + "&page_size=" + pageSize
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


  createOffice(context, { inpName, inpEmail }) {
    if (inpEmail !== null && inpName !== null) {
      axios({
        method: "POST",
        url: "https://104.215.186.78/api/v1/user-accounts",
        data: {
          name: `${inpName}`,
          email: `${inpEmail}`,
          role: "lawyer_office",
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

  //Lawyer
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

  getOfficeByEmail(context, email){
    if(email !== null){
      axios({
        method: "POST",
        url:
          "https://104.215.186.78/api/v1/lawyer-offices/details",
        data:{
          email: `${email}`
        },
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        context.commit("OFFICE", response.data);
      });
    }
  },

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

  getOfficerProfile(context){
    const id = localStorage.getItem('id');
    if(id !== null){
      axios({
        method: "GET",
        url:
          "https://104.215.186.78/api/v1/lawyer-offices/" + id,
        headers: {
          "Content-Type": "application/json; charset=utf-8",
          Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
        },
      }).then((response) => {
        context.commit("OFFICER_PROFILE", response.data);
      });
    }
  },

  updateOfficeProfile(context, user) {
    const id = localStorage.getItem('id');
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/lawyer-offices",
      data: {
        id: `${id}`,
        name: `${user.name}`,
        address: `${user.address}`,
        location: `${user.location}`,
        description: `${user.description}`,
        phone_number: `${user.phone_number}`,
        website: `${user.website}`,
        email: `${user.email}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      if (response !== null) {
        context.dispatch("officerProfile");
      }
    });
  },

  removeLawyerFromOffice(context, idLawyer){
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/lawyers/remove-out-of-office",
      data: {
        id: `${idLawyer}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      if (response !== null) {
        context.dispatch("getListLawyerOffice");
      }
    });
  },

  updateLevelLawyer(context, user){
    console.log(user.id +'  ' + user.level_id)
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/lawyers/update-level",
      data: {
        lawyer_id: `${user.id}`,
        level_id: `${user.level_id}`,
      },
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      if (response !== null) {
        context.dispatch("getListLawyerOffice");
      }
    });
  },

 
};



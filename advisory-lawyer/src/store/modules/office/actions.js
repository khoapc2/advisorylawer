import axios from "axios";

export default {
  //Officer
  searchOfficeByName(context, username){
    const pageSize = 10;
    const pageIndex = 1;
    const role = "lawyer_office";
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?name="+username+"&role="+role+"&page_index="+pageIndex+"&page_size="+pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_OFFICER", response.data);
    });
  },

  searchOfficeByStatus(context, status){
    const pageSize = 10;
    const pageIndex = 1;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?role=lawyer_office&status="+status+"&page_index="+pageIndex+"&page_size="+pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_OFFICER", response.data);
    });
  },

  searchOfficeByEmail(context, email) {
    const pageSize = 10;
    const pageIndex = 1;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/user-accounts?email="+ email +"&role=lawyer_office&page_index="+ pageIndex +"&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_OFFICER", response.data);
    });
  },

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


  //role: Officer Management
  searchLawyerOfficeByName(context, name){
    const id = localStorage.getItem('id');
    const pageSize = 10;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/lawyers?lawyer_office_id="+ id + "&name="+name+"&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER_OFFICER", response.data);
    });
  },

  searchLawyerOfficeByLevel(context, level){
    const id = localStorage.getItem('id');
    const pageSize = 10;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/lawyers?lawyer_office_id="+ id + "&level_id="+level+"&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER_OFFICER", response.data);
    });
  },


  searchLawyerOfficeByEmail(context, email) {
    const id = localStorage.getItem('id');
    const pageSize = 10;
    axios({
      method: "GET",
      url:
      "https://104.215.186.78/api/v1/lawyers?lawyer_office_id="+ id + "&email="+email+"&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      context.commit("LIST_LAWYER_OFFICER", response.data);
    });
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

  getLevel(context){
    const pageSize = 20
    axios({
      method: "GET",
      url: "https://104.215.186.78/api/v1/levels?page_index=1&page_size=" + pageSize,
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        Authorization: `Bearer ${localStorage.getItem("tokenID")}`,
      },
    }).then((response) => {
      if (response !== null) {
        context.commit("GET_LEVEL",response.data);
      }
    });
  },

  addLawyerToOffice(context, lawyer_email){
    const officeID = localStorage.getItem('id')
    console.log(lawyer_email)
    axios({
      method: "PUT",
      url: "https://104.215.186.78/api/v1/lawyers/add-to-office",
      data: {
        "office_id": `${officeID}`,
        "lawyer_email": `${lawyer_email}`
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



}
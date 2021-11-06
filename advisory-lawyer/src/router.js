import Vue from 'vue';
import Router from 'vue-router';
import Login from './pages/Login.vue';
// import Profile from './pages/Profile.vue';
import MainNavbar from './layout/MainNavbar.vue';
import MainFooter from './layout/MainFooter.vue';


import NotFound from "@/pages/NotFoundPage.vue";
import TableList from "@/pages/TableList.vue";
import TableListOfficer from "@/pages/TableListOfficer.vue";
import TableListLawyer from "@/pages/TableListLawyer.vue";
import TableListUnrole from "@/pages/TableListUnrole.vue";
import TableListOfficeManagementLawyer from "@/pages/TableListOfficeManagementLawyer.vue";
import TableListBooking from "@/pages/TableListBooking.vue";
import TableListOfficeBooking from "@/pages/TableListOfficeBooking.vue";




import UserProfile from "@/pages/UserProfile.vue";
import DashboardLayout from "@/layout/dashboard/DashboardLayout.vue";

Vue.use(Router);
export default new Router({
  linkExactActiveClass: 'active',
  routes: [
    {
      path: '/',
      components: { default: Login, header: MainNavbar, footer: MainFooter },
      props: {
        header: { colorOnScroll: 400 },
        footer: { backgroundColor: 'black' }
      }
    },
    // {
    //   path: '/landing',
    //   name: 'landing',
    //   components: { default: Landing, header: MainNavbar, footer: MainFooter },
    //   props: {
    //     header: { colorOnScroll: 400 },
    //     footer: { backgroundColor: 'black' }
    //   }
    // },
    {
      path: '/login',
      name: 'login',
      components: { default: Login, header: MainNavbar },
      props: {
        header: { colorOnScroll: 400 }
      }
    },


    {
      path: "/dashboard",
      component: DashboardLayout,
      // redirect: "/table-list",
      children: [
        // {
        //   path: "dashboard",
        //   name: "dashboard",
        //   component: Dashboard
        // },
        {
          path: "/stats",
          name: "Your Profile",
          component: UserProfile
        },
        // {
        //   path: "notifications",
        //   name: "notifications",
        //   component: Notifications
        // },
        // {
        //   path: "icons",
        //   name: "icons",
        //   component: Icons
        // },
        // {
        //   path: "maps",
        //   name: "maps",
        //   component: Maps
        // },
        // {
        //   path: "typography",
        //   name: "typography",
        //   component: Typography
        // },
        {
          path: "/table-list",
          name: "Customers",
          component: TableList
        },
        {
          path: "/table-list-officer",
          name: "Officers",
          component: TableListOfficer
        },
        {
          path: "/table-list-lawyer",
          name: "Lawyers",
          component: TableListLawyer
        },
        {
          path: "/table-list-unrole",
          name: "Unrole Users",
          component: TableListUnrole
        },
        {
          path: "/table-list-office-mangement-lawyer",
          name: "Office Management Lawyer",
          component: TableListOfficeManagementLawyer
        },
        {
          path: "/table-list-booking",
          name: "Booking Management",
          component: TableListBooking
        },
        {
          path: "/table-list-office-booking",
          name: "Booking Management",
          component: TableListOfficeBooking
        },
      ]
    },

    // {
    //   path: '/profile',
    //   name: 'profile',
    //   components: { default: Profile, header: MainNavbar, footer: MainFooter },
    //   props: {
    //     header: { colorOnScroll: 400 },
    //     footer: { backgroundColor: 'black' }
    //   }
    // }
    { path: "*", component: NotFound }
  ],
  scrollBehavior: to => {
    if (to.hash) {
      return { selector: to.hash };
    } else {
      return { x: 0, y: 0 };
    }
  }
});

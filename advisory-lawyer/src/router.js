import Vue from 'vue';
import Router from 'vue-router';
// import Index from './pages/Index.vue';
// import Landing from './pages/Landing.vue';
import Login from './pages/Login.vue';
import Profile from './pages/Profile.vue';
import MainNavbar from './layout/MainNavbar.vue';
import MainFooter from './layout/MainFooter.vue';

import TableList from "@/pages/TableList.vue";
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
          name: "stats",
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
          name: "table-list",
          component: TableList
        }
      ]
    },

    {
      path: '/profile',
      name: 'profile',
      components: { default: Profile, header: MainNavbar, footer: MainFooter },
      props: {
        header: { colorOnScroll: 400 },
        footer: { backgroundColor: 'black' }
      }
    }
  ],
  scrollBehavior: to => {
    if (to.hash) {
      return { selector: to.hash };
    } else {
      return { x: 0, y: 0 };
    }
  }
});

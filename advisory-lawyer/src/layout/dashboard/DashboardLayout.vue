<template>
  <div class="wrapper">
    <side-bar>
      <template slot="links">
        <!-- <sidebar-link to="/dashboard" name="Dashboard" icon="ti-panel"/> -->
        
        <sidebar-link to="/stats" name="Your Profile" icon="ti-user"/>
        <sidebar-link v-if="role === 'admin'" to="/table-list" name="Customer" icon="ti-folder"/>
        <sidebar-link v-if="role === 'admin'" to="/table-list-officer" name="Officer" icon="ti-folder"/>
        <sidebar-link v-if="role === 'admin'" to="/table-list-lawyer" name="Lawyer" icon="ti-folder"/>
        <sidebar-link v-if="role === 'admin'" to="/table-list-unrole" name="Unrole Users" icon="ti-folder"/>
        <sidebar-link v-if="role === 'admin'" to="/table-list-booking" name="Booking" icon="ti-folder"/>
        
        <sidebar-link v-if="role === 'lawyer_office'" to="/table-list-office-mangement-lawyer" name="Lawyer" icon="ti-folder"/>
        <sidebar-link v-if="role === 'lawyer_office'" to="/table-list-office-booking" name="Booking" icon="ti-folder"/>

        <!-- <sidebar-link to="/notifications" name="Notifications" icon="ti-bell"/> -->
      </template>
      <!-- <mobile-menu> -->
        <!-- <li class="nav-item">
          <a class="nav-link">
            <i class="ti-panel"></i>
            <p>Stats</p>
          </a>
        </li> 
        <drop-down class="nav-item"
                   title="5 Notifications"
                   title-classes="nav-link"
                   icon="ti-bell">
          <a class="dropdown-item">Notification 1</a>
          <a class="dropdown-item">Notification 2</a>
          <a class="dropdown-item">Notification 3</a>
          <a class="dropdown-item">Notification 4</a>
          <a class="dropdown-item">Another notification</a>
        </drop-down>
         <li class="nav-item">
          <a class="nav-link">
            <i class="ti-settings"></i>
            <p>Settings</p>
          </a>
        </li>
        <li class="divider"></li> -->
      <!-- </mobile-menu> -->
    </side-bar>
    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content @click.native="toggleSidebar">

      </dashboard-content>

      <content-footer></content-footer>
    </div>
  </div>
</template>
<style lang="scss">
</style>
<script>
import TopNavbar from "./TopNavbar.vue";
import ContentFooter from "./ContentFooter.vue";
import DashboardContent from "./Content.vue";
// import MobileMenu from "./MobileMenu.vue";
export default {
  data() {
    return {
      role: ''
    }
  },
  created() {
    this.role = localStorage.getItem('role')
  },
  components: {
    TopNavbar,
    ContentFooter,
    DashboardContent,
    // MobileMenu
  },
  methods: {
    toggleSidebar() {
      if (this.$sidebar.showSidebar) {
        this.$sidebar.displaySidebar(false);
      }
    }
  }
};
</script>

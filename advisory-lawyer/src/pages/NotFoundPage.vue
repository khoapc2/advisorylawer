<template>
  <div class="contact-us full-screen">
    <nav class="navbar navbar-ct-default" role="navigation-demo">
      <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <!-- <div class="navbar-header"> -->
          <!-- <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navigation-example-2">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <router-link :to="{path:'/'}" class="navbar-brand">Site title</router-link> -->
        <!-- </div> -->
  
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="navigation-example-2">
          <ul class="nav navbar-nav navbar-right">
            <li>
              <router-link :to="{path:'/'}">Home</router-link>
            </li>
          </ul>
        </div>
        <!-- /.navbar-collapse -->
      </div>
      <!-- /.container-->
    </nav>
    <div class="wrapper wrapper-full-page section content">
      <div class="">
        <div class="container">
          <div class="row">
            <div class="col-md-8 col-md-offset-2 text-center">
              <h2 class="title text-danger">404 Not Found</h2>
              <h2 class="title">Oops! It seems that this page does not exist.</h2>
              <h2 v-if="isLoggin"><router-link :to="{path:'/stats'}">Return to Login page</router-link></h2>
              <h2 v-else><router-link :to="{path:'/'}">Back To Home</router-link></h2>
            
            
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- <footer class="footer-demo">
      <div class="container">
        <nav class="pull-left">
          <ul>
            <li>
              <router-link :to="{path:'/'}">Home</router-link>
            </li>
            <li>
              <router-link :to="{path:'/register'}">Register</router-link>
            </li>
          </ul>
        </nav>
        <div class="copyright pull-right">
          &copy; 2017, made with
          <i class="fa fa-heart heart"></i> by Paper admin
        </div>
      </div>
    </footer> -->
  </div>
</template>

<script>
import firebase from 'firebase'
export default {
  
  data() {
    return {
      isLoggin: false
    }
  },
  
  created() {
    firebase.auth().onAuthStateChanged((user) => {
      if (user) {
        this.isLoggin = true;
      }
    }
  )},

  
};
</script>

<style scoped>
  .col-md-8.col-md-offset-2.text-center {
    text-align: left !important;
}
</style>

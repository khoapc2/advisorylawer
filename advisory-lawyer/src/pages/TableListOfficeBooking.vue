<template>
  <div class="row">
    <h3>Booking Detail</h3>
    <table class="table" ref="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col">Customer's Name</th>
          <th scope="col">Lawyer's Name</th>
          <th scope="col">Booking Date</th>
          <th scope="col">Pay Date</th>
          <th scope="col">Pay Method</th>
          <th scope="col">Price</th>
        </tr>
        <!-- <tr>
          <td>
            <div class="form-horizontal">
              <input
                type="text"
                name="..."
                class="form-control"
                placeholder="Search People..."
                style="width:280px;max-width:280px;display:inline-block"
              />
            </div>
          </td>
          <td>
            <input
                type="text"
                name="..."
                class="form-control"
                placeholder="Search Emaill..."
                style="width:280px;max-width:280px;display:inline-block"
              />
          </td>
          <td>
            </td>
             <td>
              <select class="form-control" :required="true">
                  <option v-for="option in statusOption" :key="option.name">{{
                    option.name
                  }}</option>
                </select>
          </td>
        </tr> -->
      </thead>
      <table-office-booking>

        </table-office-booking>
    </table>

    
  </div>
</template>
<script>
import TableOfficeBooking from './tables/TableOfficeBooking.vue'
export default {
  components: {
    TableOfficeBooking 
    },
  data() {
    return {
      message: '',
      inpEmail: '',
      inpName: '',
      listUser: [],
    };
  },
  created() {
    if (localStorage.getItem("role") !== "lawyer_office") {
      this.$router.push("/");
    } 
  },
  computed: {
   
  },
  methods: {
   
  },
  mounted() {
    
  },
};
</script>
<style lang="scss" scoped></style>

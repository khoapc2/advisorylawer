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
      <table-booking>

      </table-booking>
    </table>

    
  </div>
</template>
<script>
import TableBooking from './tables/TableBooking.vue'

export default {
  components: {
    TableBooking
    },
  data() {
    return {
      message: '',
      inpEmail: '',
      inpName: '',
      listUser: [],
      roleOption: [
        {
          name: "customer",
        },
        {
          name: "admin",
        },
        {
          name: "lawyer",
        },
        {
          name: "office lawyer",
        },
      ],
      statusOption: [
        {
          name: ""
        },
        {
          name: "Inactive"
        },
        {
          name: "Active"
        }
      ]
    };
  },
  created() {
    if (localStorage.getItem("role") !== "admin") {
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

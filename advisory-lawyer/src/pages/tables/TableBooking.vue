<template>
  <tbody>
        <tr v-for="booking in listBooking" :key="booking.id">
          <td style="display:none">{{ listBooking.id }}</td>
          <td>
            {{booking.customer_name}}
          </td>
          <td>{{booking.lawyer_name}}</td>
          <td>
            {{ format_date(booking.booking_date) }}
          </td>
           <td>
            {{format_date(booking.pay_date)}}
          </td>
          <td>
            {{booking.payment_method}}
          </td>
          <td>
            {{booking.total_price}}
          </td>
        </tr>
      </tbody>
</template>

<script>
import { mapState } from "vuex";
import moment from 'moment'

export default {
  data() {
    return {
      // listBooking: [],
    };
  },
  created() {
    if (localStorage.getItem("role") !== "admin") {
      this.$router.push("/");
    } else {
      // this.$store.dispatch("getUserListApi");
    }
  },
  computed: {
    ...mapState('booking',{
      listBooking: "listBooking",
    }),
  },
  methods: {
    format_date(value){
         if (value) {
           return moment(String(value)).format('DD-MM-YYYY HH:mm')
          }
      },
  },
  mounted() {
    this.$store.dispatch("booking/getListBooking");
  },
};
</script>
<style lang="scss" scoped></style>>

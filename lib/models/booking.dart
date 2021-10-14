// import 'dart:async';
// import 'dart:convert';

// import 'package:flutter/material.dart';
// import 'package:http/http.dart' as http;

// Future<List<Booking>> fetchBooking() async {
//   final response =
//       await http.get(Uri.parse('https://104.215.186.78/api/v1/bookings'));

//   print(response);

//   if (response.statusCode == 200) {
//     List jsonResponse = json.decode(response.body);
//     return jsonResponse
//         .map((booking) => new Booking.fromJson(booking))
//         .toList();
//   } else {
//     throw Exception('Fail to load');
//   }
// }

// class Booking {
//   final int bookingId;
//   final int customerId;
//   final String bookingDate;
//   final String paymentMethod;
//   final int totalPrice;
//   final DateTime payDate;
//   final int status;
//   final int customerCaseID;

//   Booking(
//       {required this.bookingId,
//       required this.customerId,
//       required this.bookingDate,
//       required this.paymentMethod,
//       required this.totalPrice,
//       required this.payDate,
//       required this.status,
//       required this.customerCaseID});

//   factory Booking.fromJson(Map<String, dynamic> json) {
//     return Booking(
//         bookingId: json['id'],
//         customerId: json['customer_id'],
//         bookingDate: json['booking_date'],
//         paymentMethod: json['payment_method'],
//         totalPrice: json['total_price'],
//         payDate: json['pay_date'],
//         status: json['status'],
//         customerCaseID: json['customer_case_id']);
//   }
//   @override
//   String toString() {
//     // TODO: implement toString
//     return super.toString();
//   }
// }

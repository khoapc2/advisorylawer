import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<List<Booking>> fetchBooking() async {
  final response =
      await http.get(Uri.parse('https://104.215.186.78/api/v1/bookings'));

  print(response);

  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse
        .map((booking) => new Booking.fromJson(booking))
        .toList();
  } else {
    throw Exception('Fail to load');
  }
}

Future<Booking> createCustomerCase(
    String customerId,
    String bookingDate,
    String paymentMethod,
    String totalPrice,
    String payDate,
    String status,
    String customerCaseID) async {
  final response = await http.post(
    Uri.parse('https://104.215.186.78/api/v1/customer-cases'),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, String>{
      'customer_id': customerId,
      'booking_date': bookingDate,
      'payment_method': paymentMethod,
      'pay_date': payDate,
      'customer_case_id': customerCaseID,
    }),
  );

  if (response.statusCode == 201) {
    // If the server did return a 201 CREATED response,
    // then parse the JSON.
    return Booking.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 201 CREATED response,
    // then throw an exception.
    throw Exception('Failed to create album.');
  }
}

class Booking {
  final int bookingId;
  final int customerId;
  final String bookingDate;
  final String paymentMethod;
  final int totalPrice;
  final DateTime payDate;
  final int status;
  final int customerCaseID;

  Booking(
      {required this.bookingId,
      required this.customerId,
      required this.bookingDate,
      required this.paymentMethod,
      required this.totalPrice,
      required this.payDate,
      required this.status,
      required this.customerCaseID});

  factory Booking.fromJson(Map<String, dynamic> json) {
    return Booking(
        bookingId: json['id'],
        customerId: json['customer_id'],
        bookingDate: json['booking_date'],
        paymentMethod: json['payment_method'],
        totalPrice: json['total_price'],
        payDate: json['pay_date'],
        status: json['status'],
        customerCaseID: json['customer_case_id']);
  }
  @override
  String toString() {
    // TODO: implement toString
    return super.toString();
  }
}

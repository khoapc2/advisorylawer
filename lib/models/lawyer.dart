import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<List<Lawyer>> fetchLawyer() async {
  final response = await http.get(Uri.parse(
      'https://104.215.186.78/api/v1/lawyers?page_index=1&page_size=10'));

  print(response);

  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((lawyer) => Lawyer.fromJson(lawyer)).toList();
  } else {
    throw Exception('Fail to load');
  }
}

class Lawyer {
  final int id;
  final String name;
  final String email;
  final String address;
  final String location;
  final String description;
  final String phoneNumber;
  final String website;
  final String sex;
  final String dateOfBirth;
  final int status;
  final int lawyerOfficeId;
  final int levelId;

  Lawyer(
      {required this.id,
      required this.name,
      required this.email,
      required this.address,
      required this.location,
      required this.description,
      required this.phoneNumber,
      required this.website,
      required this.sex,
      required this.dateOfBirth,
      required this.status,
      required this.lawyerOfficeId,
      required this.levelId});

  factory Lawyer.fromJson(Map<String, dynamic> json) {
    return Lawyer(
        id: json['id'],
        name: json['name'],
        email: json['email'],
        address: json['address'],
        location: json['location'],
        description: json['description'],
        phoneNumber: json['phone_number'],
        website: json['website'],
        sex: json['sex'],
        dateOfBirth: json['date_of_birth'],
        status: json['status'],
        lawyerOfficeId: json['lawyer_office_id'],
        levelId: json['level_id']);
  }
  @override
  String toString() {
    // TODO: implement toString
    return super.toString();
  }
}

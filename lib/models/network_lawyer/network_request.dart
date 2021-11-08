import 'dart:convert';
import 'dart:io';

import 'package:advisories_lawyer/lawyer/model_lawyer/category.dart';
import 'package:advisories_lawyer/lawyer/model_lawyer/document.dart';
import 'package:advisories_lawyer/lawyer/model_lawyer/post.dart';
import 'package:advisories_lawyer/lawyer/model_lawyer/slot.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/foundation.dart';

import 'package:http/http.dart' as http;

class NetworkRequest {
  static const String url = 'https://jsonplaceholder.typicode.com/posts';
  static const String urlCategory =
      'https://104.215.186.78/api/v1/categories?page_index=1&page_size=6';
  static const String urlSlot =
      'https://104.215.186.78/api/v1/slots?page_index=1&page_size=5';
  static const String urlDocument =
      'https://104.215.186.78/api/v1/documents?page_index=1&page_size=10';

  static List<CategoryDTO> parseCategory(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    List<CategoryDTO> categories =
        list.map((model) => CategoryDTO.fromJson(model)).toList();
    return categories;
  }

  static List<Post> parsePost(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    List<Post> posts = list.map((model) => Post.fromJson(model)).toList();
    return posts;
  }

  static List<SlotDTO> parseSlot(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    List<SlotDTO> slots = list.map((model) => SlotDTO.fromJson(model)).toList();
    return slots;
  }

  static List<DocumentDTO> parseDocument(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    List<DocumentDTO> documents =
        list.map((model) => DocumentDTO.fromJson(model)).toList();
    return documents;
  }

  static Future<List<Post>> fetachPosts({int page = 1}) async {
    final response = await http.get(Uri.parse(url));

    if (response.statusCode == 200) {
      print("connect dc r");
      return compute(parsePost, response.body);
    } else if (response.statusCode == 404) {
      print("Not found ");
      throw Exception('Not Found');
    } else {
      print("Fail to connect");
      throw Exception('Failed to get post');
    }
  }

  static Future<List<CategoryDTO>> fetachCategories({int page = 1}) async {
    final response = await http.get(Uri.parse(urlCategory));
    if (response.statusCode == 200) {
      print("connect dc r");
      return compute(parseCategory, response.body);
    } else if (response.statusCode == 404) {
      print("Not found ");
      throw Exception('Not Found');
    } else {
      print("Fail to connect");
      throw Exception('Failed to get post');
    }
  }

  static Future<List<DocumentDTO>> fetachDocument({int page = 1}) async {
    final response = await http.get(Uri.parse(urlDocument));
    if (response.statusCode == 200) {
      print("connect dc r");
      return compute(parseDocument, response.body);
    } else if (response.statusCode == 404) {
      print("Not found ");
      throw Exception('Not Found');
    } else {
      print("Fail to connect");
      throw Exception('Failed to get post');
    }
  }

  static Future<List<SlotDTO>> fetachSlot(int lawyerID, {int page = 1}) async {
    var idToken = await FirebaseAuth.instance.currentUser!.getIdToken();
    final response = await http.get(
      Uri.parse(
          'https://104.215.186.78/api/v1/slots?lawyer_id=$lawyerID&page_index=1&page_size=5'),
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer $idToken',
      },
    );

    if (response.statusCode == 200) {
      print("connect dc r");
      return compute(parseSlot, response.body);
    } else if (response.statusCode == 404) {
      print("Not found ");
      throw Exception('Not Found');
    } else {
      print("Fail to connect");
      throw Exception('Failed to get post');
    }
  }

  /*Future<List<Post>> fetchProducts() async { 
   final response = await http.get('http://192.168.1.2:8000/products.json' as Uri); 
   if (response.statusCode == 200) { 
      return parseProducts(response.body); 
   } else { 
      throw Exception('Unable to fetch products from the REST API');
   } 
}*/

}

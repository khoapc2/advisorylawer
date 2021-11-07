import 'dart:convert';

import 'package:advisories_lawyer/models/documents.dart';
import 'package:http/http.dart' as http;

class Docservice {
  Future<List<Doc>> fetchDoc(int cateid) async {
    final response = await http.get(Uri.parse(
        'https://104.215.186.78/api/v1/documents?category_id=$cateid&page_index=1&page_size=10'));

    if (response.statusCode == 200) {
      List jsonResponse = json.decode(response.body);
      return jsonResponse.map((doc) => Doc.fromJson(doc)).toList();
    } else {
      throw Exception('Fail to load');
    }
  }
}

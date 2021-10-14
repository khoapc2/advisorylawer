import 'dart:io';

import 'package:advisories_lawyer/models/documents.dart';
import 'package:flutter/material.dart';

import 'package:http/http.dart' as http;

class DocPage extends StatefulWidget {
  const DocPage({Key? key}) : super(key: key);

  @override
  _DocPageState createState() => _DocPageState();
}

class _DocPageState extends State<DocPage> {
  late Future<List<Doc>> futureDoc;
  @override
  void initState() {
    super.initState();
    futureDoc = fetchDoc();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Document'),
      ),
      body: Center(
        child: FutureBuilder<List<Doc>>(
          future: futureDoc,
          builder: (context, snapshot) {
            if (snapshot.hasData) {
              List<Doc> doc = snapshot.data!;

              return ListView.builder(
                itemCount: snapshot.data!.length,
                itemBuilder: (BuildContext context, int index) {
                  return Container(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text("Các Câu Hỏi Về " + doc[index].name),
                        Text(doc[index].description + "\n"),
                      ],
                    ),
                  );
                },
              );
            } else if (snapshot.hasError) {
              return Text('${snapshot.error} lỗi ');
            }

            // By default, show a loading spinner.
            return const CircularProgressIndicator();
          },
        ),
      ),
    );
  }
}

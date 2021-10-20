import 'dart:io';

import 'package:advisories_lawyer/models/documents.dart';
import 'package:advisories_lawyer/models/lawyer.dart';
import 'package:advisories_lawyer/views/booking_page.dart';
import 'package:advisories_lawyer/views/login_page.dart';
import 'package:flutter/material.dart';

import 'package:http/http.dart' as http;

class LawyerPage extends StatefulWidget {
  const LawyerPage({Key? key}) : super(key: key);

  @override
  _DocPageState createState() => _DocPageState();
}

class _DocPageState extends State<LawyerPage> {
  late Future<List<Lawyer>> futureLawyer;
  @override
  void initState() {
    super.initState();
    futureLawyer = fetchLawyer();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Lawyer List'),
        backgroundColor: Colors.purple[400],
        centerTitle: true,
      ),
      body: Column(
        children: [
          Center(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                // Expanded(
                //   child: Text(""),
                // ),
                SizedBox(
                  width: 50,
                ),
                Expanded(
                  child: Text(
                    "Name",
                    style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold),
                  ),
                ),
                Expanded(
                  child: Text("Email",
                      style:
                          TextStyle(fontSize: 17, fontWeight: FontWeight.bold)),
                ),
                Expanded(
                  child: Text("Description",
                      style:
                          TextStyle(fontSize: 17, fontWeight: FontWeight.bold)),
                ),
                Expanded(
                  child: Text("Sex",
                      style:
                          TextStyle(fontSize: 17, fontWeight: FontWeight.bold)),
                ),
              ],
            ),
          ),
          Expanded(
            child: Center(
              child: FutureBuilder<List<Lawyer>>(
                future: futureLawyer,
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    List<Lawyer> lawyer = snapshot.data!;

                    return ListView.builder(
                      itemCount: snapshot.data!.length,
                      itemBuilder: (BuildContext context, int index) {
                        return InkWell(
                          onTap: () {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) => BookingPage(),
                                  settings: RouteSettings(
                                    arguments: lawyer[index],
                                  ),
                                ));
                          },
                          child: ListTile(
                            onTap: null,
                            leading: CircleAvatar(
                              backgroundColor: Colors.blue,
                              child: Text(lawyer[index].name[0]),
                            ),
                            title: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Expanded(
                                  child: Text(lawyer[index].name),
                                ),
                                Expanded(
                                  child: Text(lawyer[index].email + "\n"),
                                ),
                                Expanded(
                                  child: Text(lawyer[index].description + "\n"),
                                ),
                                Expanded(
                                  child: Text(lawyer[index].sex + "\n"),
                                ),
                              ],
                            ),
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
          ),
        ],
      ),
    );
  }
}

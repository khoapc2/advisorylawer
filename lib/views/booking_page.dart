import 'package:advisories_lawyer/models/lawyer.dart';
import 'package:advisories_lawyer/provider/google_sign_in.dart';
import 'package:flutter/material.dart';

class BookingPage extends StatefulWidget {
  late List<int> cateID;
  BookingPage(this.cateID);

  @override
  _BookingPageState createState() => _BookingPageState(cateID: cateID);
}

class _BookingPageState extends State<BookingPage> {
  _BookingPageState({required this.cateID});
  late List<int> cateID;
  late final Future<Users> userList;
  @override
  void initState() {
    userList = getUsers();
  }

  DateTime date = DateTime.now();
  @override
  Widget build(BuildContext context) {
    //final lawyer = ModalRoute.of(context)!.settings.arguments as Lawyer;
    // final user = ModalRoute.of(context)!.settings.arguments as Users;
    return Scaffold(
      appBar: AppBar(
        title: Text('Booking Page'),
        backgroundColor: Colors.purple[400],
        centerTitle: true,
      ),
      body: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                buildFutureBuilder(),
                Text(
                  'Lawyer ID: ' + cateID.toString(),
                  style: TextStyle(fontSize: 25, fontWeight: FontWeight.bold),
                ),
                // Text(
                //   'Name: ' + lawyer.name,
                //   style: TextStyle(fontSize: 25, fontWeight: FontWeight.bold),
                // ),
                Text(
                    "Ngày chọn: " +
                        date.day.toString() +
                        " - " +
                        date.month.toString() +
                        " - " +
                        date.year.toString(),
                    style: TextStyle(color: Colors.white, fontSize: 20)),
              ],
            ),
          )),
    );
  }

  FutureBuilder<Users> buildFutureBuilder() {
    return FutureBuilder<Users>(
      future: userList,
      builder: (context, snapshot) {
        if (snapshot.hasData) {
          return Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Title: " + snapshot.data!.toString(),
                style: TextStyle(fontSize: 20),
              ),
            ],
          );
        } else if (snapshot.hasError) {
          return Text('${snapshot.error}');
        }

        return const CircularProgressIndicator();
      },
    );
  }
}

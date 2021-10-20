import 'dart:io';

import 'package:advisories_lawyer/models/catagories.dart';
import 'package:advisories_lawyer/models/customer_case.dart';
import 'package:advisories_lawyer/models/lawyer.dart';
import 'package:advisories_lawyer/models/users.dart';
import 'package:flutter/material.dart';

class BookingPage extends StatefulWidget {
  const BookingPage({Key? key}) : super(key: key);

  @override
  _BookingPageState createState() => _BookingPageState();
}

class _BookingPageState extends State<BookingPage> {
  late Future<List<Catagories>> futureCata;
  @override
  void initState() {
    super.initState();
    futureCata = fetchCatagories();
  }

  final TextEditingController _controller = TextEditingController();
  final TextEditingController _controller2 = TextEditingController();
  Future<CustomerCase>? _futureCustomerCase;

  @override
  Widget build(BuildContext context) {
    final lawyer = ModalRoute.of(context)!.settings.arguments as Lawyer;
    return Scaffold(
      appBar: AppBar(
        title: Text('Customer case'),
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
                Text(
                  'Email: ' + lawyer.email,
                  style: TextStyle(fontSize: 20),
                ),
                Text("Name: " + lawyer.name, style: TextStyle(fontSize: 20)),
                Container(
                  alignment: Alignment.centerLeft,
                  padding: const EdgeInsets.all(8.0),
                  child: (_futureCustomerCase == null)
                      ? buildColumn()
                      : buildFutureBuilder(),
                ),
              ],
            ),
          )),
    );
  }

  Column buildColumn() {
    return Column(
      mainAxisAlignment: MainAxisAlignment.start,
      children: <Widget>[
        TextField(
          controller: _controller,
          decoration: const InputDecoration(
              border: OutlineInputBorder(), hintText: 'Enter Title'),
        ),
        TextField(
          controller: _controller2,
          decoration: const InputDecoration(
              border: OutlineInputBorder(), hintText: 'Enter Your Problem'),
        ),
        ElevatedButton(
          onPressed: () {
            setState(() {
              _futureCustomerCase =
                  createCustomerCase(_controller.text, _controller2.text);
            });
          },
          child: const Text('Submit'),
        ),
      ],
    );
  }

  FutureBuilder<CustomerCase> buildFutureBuilder() {
    return FutureBuilder<CustomerCase>(
      future: _futureCustomerCase,
      builder: (context, snapshot) {
        if (snapshot.hasData) {
          return Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Title: " + snapshot.data!.name,
                style: TextStyle(fontSize: 20),
              ),
              Text("Your Problem: " + snapshot.data!.description,
                  style: TextStyle(fontSize: 20))
            ],
          );
        } else if (snapshot.hasError) {
          return Text('${snapshot.error}');
        }

        return const CircularProgressIndicator();
      },
    );
  }

  // FutureBuilder<List<Catagories>> buildFutureCataBuilder() {
  //   return FutureBuilder<List<Catagories>>(
  //     future: futureCata,
  //     builder: (context, snapshot) {
  //       if (snapshot.hasData) {
  //         List<Catagories> cata = snapshot.data!;
  //         return Column(
  //           children: [
  //             new Center(
  //       child: new DropdownButton(
  //         items: cata.map((item) {
  //           return new DropdownMenuItem(
  //             child: new Text(item['item_name']),
  //             value: item['id'].toString(),
  //           );
  //         }).toList(),
  //         onChanged: (newVal) {
  //           setState(() {
  //             _mySelection = newVal;
  //           });
  //         },
  //         value: _mySelection,
  //       ),
  //     ),
  //   );
  //           ],
  //         );
  //       } else if (snapshot.hasError) {
  //         return Text('${snapshot.error}');
  //       }

  //       return const CircularProgressIndicator();
  //     },
  //   );
  //}
}

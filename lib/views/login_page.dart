import 'package:advisories_lawer/provider/google_sign_in.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:provider/provider.dart';

class LoginPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    Widget titileSection = Container(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          Expanded(
              child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 50, 0, 20),
                child: Text(
                  "Welcome to our app",
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 30),
                ),
              ),
              //textfield
            ],
          ))
        ],
      ),
    );

    Widget buttonSection = Container(
      child:
          //Button
          Padding(
        padding: const EdgeInsets.fromLTRB(0, 30, 0, 0),
        child: SizedBox(
            width: double.infinity,
            height: 56,
            child: ElevatedButton.icon(
                style: ElevatedButton.styleFrom(
                    primary: Colors.white,
                    onPrimary: Colors.black,
                    minimumSize: Size(double.infinity, 50)),
                onPressed: () {
                  final provider =
                      Provider.of<GoogleSignInProvider>(context, listen: false);
                  provider.googleLogin();
                },
                icon: FaIcon(
                  FontAwesomeIcons.google,
                  color: Colors.red,
                ),
                label: Text('Sign Up with google'))),
      ),
    );

    return Scaffold(
      body: Container(
        padding: EdgeInsets.fromLTRB(30, 0, 30, 0),
        color: Colors.cyan[50],
        constraints: BoxConstraints.expand(),
        child: ListView(
          children: [
            titileSection,
            Center(
              child: Image.asset(
                'judge.png',
                width: 400,
                height: 200,
                fit: BoxFit.cover,
              ),
            ),
            buttonSection,
          ],
        ),
      ),
    );
  }
}

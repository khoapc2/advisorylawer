import 'package:advisories_lawyer/provider/google_sign_in.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:provider/provider.dart';

class LoginPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    Widget titileSection = Container(
      child: Row(
        children: [
          Expanded(
              child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.fromLTRB(170, 35, 0, 0),
                child: Text(
                  "Welcome back",
                  style: TextStyle(
                      color: Colors.white,
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
        padding: const EdgeInsets.fromLTRB(0, 20, 0, 0),
        child: SizedBox(
            width: 200,
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
        decoration: BoxDecoration(
          image: DecorationImage(
              image: AssetImage('assets/theme1.png'), fit: BoxFit.cover),
        ),
        child: ListView(
          children: [
            Padding(
              padding: const EdgeInsets.fromLTRB(20, 10, 0, 0),
              child: Container(
                child: Text(
                  "LOGIN",
                  style: TextStyle(
                      fontSize: 60,
                      color: Colors.white,
                      fontWeight: FontWeight.w700),
                ),
              ),
            ),
            titileSection,
            Column(
              children: [
                Image.asset(
                  'customer.png',
                  fit: BoxFit.fill,
                ),
                Center(
                  child: buttonSection,
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}

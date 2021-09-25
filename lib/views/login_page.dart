import 'package:flutter/material.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
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

    Widget inputSection = Container(
      padding: EdgeInsets.fromLTRB(10, 30, 0, 10),
      child: Row(
        children: [
          Expanded(
              child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 20),
                child: TextField(
                  style: TextStyle(fontSize: 18, color: Colors.black),
                  decoration: InputDecoration(
                    labelText: "USERNAME",
                    labelStyle:
                        TextStyle(color: Color(0xff888888), fontSize: 15),
                  ),
                ),
              ),

              //password
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 20),
                child: Stack(
                  alignment: AlignmentDirectional.centerEnd,
                  children: [
                    TextField(
                      style: TextStyle(fontSize: 18, color: Colors.black),
                      obscureText: true,
                      decoration: InputDecoration(
                        labelText: "PASSWORD",
                        labelStyle:
                            TextStyle(color: Color(0xff888888), fontSize: 15),
                      ),
                    ),
                    //textfeild

                    GestureDetector(
                      onTap: onToggleShowPass,
                      child: Text(
                        "SHOW",
                        style: TextStyle(color: Colors.blue, fontSize: 15),
                      ),
                    )
                  ],
                ),
              ),
            ],
          ))
        ],
      ),
    );

    Widget buttonSection = Container(
      child:
          //Button
          Padding(
        padding: const EdgeInsets.fromLTRB(0, 0, 0, 0),
        child: SizedBox(
          width: double.infinity,
          height: 56,
          child: RaisedButton(
            color: Colors.blue,
            shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.all(Radius.circular(8))),
            onPressed: onSignInClicked,
            child: Text("SIGN IN"),
          ),
        ),
      ),
    );

    Widget accountSection = Container(
      child: Padding(
        padding: const EdgeInsets.fromLTRB(10, 30, 0, 10),
        child: Center(
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(
                  child: Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    "NEW USER?  ",
                    style: TextStyle(fontSize: 15, color: Color(0xff888888)),
                  ),
                  Text(
                    "SIGN UP",
                    style: TextStyle(fontSize: 15, color: Colors.blue),
                  )
                ],
              )),
              Expanded(
                  child: Row(
                children: [
                  Text(
                    "FORGOT PASSWORD?",
                    style: TextStyle(fontSize: 15, color: Colors.blue),
                  )
                ],
              ))
            ],
          ),
        ),
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
            inputSection,
            buttonSection,
            accountSection
          ],
        ),
      ),
    );
  }

  void onToggleShowPass() {}
  void onSignInClicked() {}
}

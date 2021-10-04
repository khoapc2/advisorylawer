import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:table_calendar/table_calendar.dart';

class Schedule extends StatefulWidget {
  @override
  _SheduleState createState() => _SheduleState();
}

class _SheduleState extends State<Schedule> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: SingleChildScrollView(
        child: Column(
          children: [
            TableCalendar(
              focusedDay: DateTime.now(),
              firstDay: DateTime(1990),
              lastDay: DateTime(2050),
            ),
            SizedBox(
              height: 20,
            ),
            Container(
              padding: EdgeInsets.only(left: 30),
              width: MediaQuery.of(context).size.width,
              height: MediaQuery.of(context).size.height * 0.55,
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.only(
                      topLeft: Radius.circular((30)),
                      topRight: Radius.circular((30))),
                  color: Color(0xff30384c)),
              child: Stack(
                children: <Widget>[
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: <Widget>[
                      Padding(
                        padding: EdgeInsets.only(top: 30),
                        child: Text(
                          "Task today",
                          style: TextStyle(
                              color: Colors.white,
                              fontSize: 20,
                              fontWeight: FontWeight.bold),
                        ),
                      ),
                      serviceTask("8:00 AM", "advice for Tom", CupertinoIcons.check_mark_circled_solid, Color(0xff00cf8d)),
                      serviceTask("10:00 AM", "meeting the department", Icons.radio_button_unchecked, Color(0xff00cf8d)),
                      serviceTask("13:00 PM", "advice for Tom2", Icons.radio_button_unchecked, Color(0xff00cf8d)),
                      serviceTask("15:00 PM", "advice for Tom3", CupertinoIcons.check_mark_circled_solid, Color(0xff00cf8d)),
                     
                    ],
                  )
                ],
              ),
            )
          ],
        ),
      ),
    );
  }

  Container serviceTask(String timeTask, String description, IconData iconData, Color colorIcon) {
    return Container(
      padding: EdgeInsets.only(top: 20),
      child: Row(
        children: <Widget>[
          Icon(
            iconData,
            color: colorIcon,
            size: 30,
          ),
          Container(
            padding: EdgeInsets.only(left: 10, right: 10),
            width: MediaQuery.of(context).size.width * 0.8,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                Text('$timeTask',
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 20,
                        color: Colors.white)),
                SizedBox(
                  height: 10,
                ),
                Text('$description',
                    style: TextStyle(
                        color: Colors.white,
                        fontSize: 15,
                        fontWeight: FontWeight.bold))
              ],
            ),
          )
        ],
      ),
    );
  }
}





































/*import 'dart:ffi';

import 'package:flutter/material.dart';
import 'package:table_calendar/table_calendar.dart';

class Schedule extends StatefulWidget {

  @override
  _ScheduleState createState() => _ScheduleState();
}

class _ScheduleState extends State<Schedule> {
  late CalendarController _controller;
  @override
  void initState(){
    super.initState();
  }
  @override
  void dispose(){
    super.dispose();
    _controller.dispose();
  }
  @override
  Widget build(BuildContext context) {
    return Container(
      child: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            TableCalendar(
              calendarController: _controller
              )
          ],
        ),
        ),
    );
  }
}*/

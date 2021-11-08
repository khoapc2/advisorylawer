import 'package:flutter/material.dart';

class InputField extends StatelessWidget {
  final String title;
  final String hint;
  final TextEditingController? controller;
  final Widget? widget;
  const InputField({ Key? key,
   required this.title, required this.hint, this.controller, this.widget 
   }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(top: 16),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        /*children: [
          Text(title, style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.w400,
            color: Colors.black
          ),),
          Container(
            height: 52,
            width: 300,
            margin: EdgeInsets.only(top: 8.0),
            padding: EdgeInsets.only(left: 14),
            decoration: BoxDecoration(
              border: Border.all(
                color: Colors.grey,
                width: 1.0
              ),
              borderRadius: BorderRadius.circular(12)
            ),
          )
        ],*/
        children: [
          Text(title, style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.w400,
            color: Colors.black
          ),),
          Container(
            height: 52,
            margin: EdgeInsets.only(top: 8.0),
            padding: EdgeInsets.only(left: 14),
            decoration: BoxDecoration(
              color: Colors.white,
              border: Border.all(
                color: Colors.grey,
                width: 1.0
              ),
              borderRadius: BorderRadius.circular(12)
            ),
            child: Row(
              children: [
                Expanded(
                  child: TextFormField(
                    readOnly: widget==null?false:true,
                    autofocus: false,
                    cursorColor: Colors.grey,
                    controller: controller,
                    style: TextStyle(color: Colors.grey[800], fontSize: 14, fontWeight: FontWeight.w400),
                    decoration: InputDecoration(
                      hintText: hint,
                      hintStyle: TextStyle(color: Colors.grey[400], fontSize: 14, fontWeight: FontWeight.w400),
                      focusedBorder: UnderlineInputBorder(
                        borderSide: BorderSide(
                          color: Colors.white,
                          width: 0
                        )
                      )
                    ),
                  )
                ),
                widget==null?Container(): Container(child: widget,)
              ],
            ),
          )
          
        ],
      ),
      
    );
  }
}
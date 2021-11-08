import 'package:advisories_lawyer/lawyer/infor_user.dart';
import 'package:advisories_lawyer/lawyer/model_lawyer/booking.dart';
import 'package:advisories_lawyer/lawyer/network_lawyer/network_request.dart';
import 'package:advisories_lawyer/lawyer/profile_of_customer.dart';
import 'package:advisories_lawyer/lawyer/profile_of_customercase.dart';

import 'package:advisories_lawyer/provider/google_sign_in.dart';
import 'package:flutter/material.dart';

class ProfileBooking extends StatefulWidget {
  const ProfileBooking({ Key? key }) : super(key: key);

  @override
  _ProfileBooking createState() => _ProfileBooking();
}

class _ProfileBooking extends State<ProfileBooking> {

  List<BookingDTO> bookingData  = <BookingDTO>[];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    NetworkRequest.fetachBooking().then((dataFromSever){
      setState(() {
        bookingData = dataFromSever;
      });
    });
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Booking"),backgroundColor: Colors.purple[400],),
      body: Column(
        children: [
          Expanded(
            child: ListView.builder(
              padding: EdgeInsets.all(10),
              //list
              itemCount: bookingData.length,
              itemBuilder: (context, index){
                return Card(
                  child: InkWell(
                    onTap: (){
                      //Navigator.push(context,
                      //MaterialPageRoute(builder: (context) => DocumentPage(categoryData[index].id)));
                    },
                    child: Padding(
                      padding: EdgeInsets.all(10),
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.start,
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          SizedBox(
                            height: 5,
                          ),
                          Text('${bookingData[index].customerName}',
                            style: TextStyle(fontSize: 20, color: Colors.black, fontWeight: FontWeight.bold),
                          ),
                          ElevatedButton(
                            style: (ButtonStyle(
                              backgroundColor:
                                  MaterialStateProperty.all(Colors.blue),
                            )),
                            onPressed: () {
                              var  u;
                              InforUser inforUser= new InforUser();
                              if( inforUser.getUserInfo is Users){
                                u= inforUser.getUserInfo;
                              }
                              
                              print("heeee"+ inforUser.toString());
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => ProfileCustomer(bookingData[index].customerId)));
                            },
                            child: Text(
                              'Hồ sơ khách hàng',
                              style: TextStyle(color: Colors.white),
                            ),
                          ),
                          SizedBox(
                            height: 5,
                          ),
                          Text('ngày book: ${bookingData[index].bookingDate}',
                            style: TextStyle(fontSize: 16, color: Colors.black),
                          ),
                          SizedBox(
                            height: 5,
                          ),
                          Text('${bookingData[index].payDate}',
                            style: TextStyle(fontSize: 16, color: Colors.black),
                          ),
                          SizedBox(
                            height: 5,
                          ),
                          Text('${bookingData[index].totalPrice}',
                            style: TextStyle(fontSize: 16, color: Colors.black),
                          ),
                          SizedBox(
                            height: 5,
                          ),
                          Text('CusCase: ${bookingData[index].customerCaseId}',
                            style: TextStyle(fontSize: 16, color: Colors.black),
                          ),
                          RaisedButton(
                            color: Colors.blue,
                            onPressed: () {
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => ProfileOfCustomerCase(bookingData[index].customerCaseId)));
                                     
                            },
                            child: Text(
                              'tài liệu vụ án',
                              style: TextStyle(color: Colors.white),
                            ),
                          ),
                          
                        ],
                      ),
                    ),
                  ),
                );
              }
            )
          )
        ],
      ),
      
    );
  }
}
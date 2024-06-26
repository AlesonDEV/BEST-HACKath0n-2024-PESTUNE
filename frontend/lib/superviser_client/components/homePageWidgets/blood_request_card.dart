import 'dart:math';

import 'package:blood_flow/superviser_client/components/homePageWidgets/blood_requests_container.dart';
import 'package:blood_flow/superviser_client/config.dart';
import 'package:blood_flow/superviser_client/model/BloodType.dart';
import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';

import '../../../config/config.dart';
import '../../mainpage.dart';
import '../../model/blood_types.dart';
import 'blood_request_form.dart';
import 'package:http/http.dart' as http;

const BGColor = const Color(0xffF5F5F3);
const TextColor = const Color(0xff1f2c4b);

class BloodRequestCard extends StatefulWidget {
  double progress = 0;
  int goal;
  BloodType bloodType;
  Function(BloodType type, double progress, int goal) onTap;
  Function onDelete;

  void handleTap(){
    onTap(this.bloodType, this.progress, this.goal);
  }
  int id;
  BloodRequestCard(this.id,this.goal, this.bloodType, this.onTap, this.onDelete);
  BloodRequestCard.progress(this.id,this.goal, this.bloodType, this.progress, {required this.onTap, required this.onDelete});

  @override
  State<StatefulWidget> createState() => _BloodRequestState();
}

Future<http.Response> deleteBloodRequest(int bloodRequestId) async {
  final url = Uri.parse(Config.baseUrl + "/Orders/$bloodRequestId"); // Replace with your actual API endpoint

  final response = await http.delete(
    url,
  );

  if(response.statusCode >= 200 && response.statusCode < 300){
    print("Deleted");
  }else{
    print(response.statusCode);
  }
  return response;
}


class _BloodRequestState extends State<BloodRequestCard> {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: GestureDetector(
        onTap: widget.handleTap,
        child: Container(
          decoration: BoxDecoration(
            color: BGColor,
            borderRadius: BorderRadius.circular(15),
          ),
          width: screenSize.width * 0.9,
          height: screenSize.height * 0.2,
          alignment: Alignment.center,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              SizedBox(height: 10),
              Text(
                'Blood Type: ${widget.bloodType.name}', // Assuming BloodTypes is a string enum or similar
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
              SizedBox(height: 10),
              Row(
                children: [

                ],
              ),
              Expanded(
                child: Padding(
                  padding: EdgeInsets.symmetric(horizontal: 20),
                  child: LiquidLinearProgressIndicator(
                    value: widget.progress < 0.06 ? 0.06 : widget.progress / widget.goal,
                    valueColor: AlwaysStoppedAnimation(SecondaryColor),
                    backgroundColor: Colors.white,
                    borderRadius: 12.0,
                    direction: Axis.horizontal,
                  ),
                ),
              ),
              SizedBox(height: 10),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  IconButton(
                    icon: Icon(Icons.edit),
                    onPressed: () {
                      showDialog(
                        context: context,
                        builder: (BuildContext context) {
                          return AlertDialog(
                            title: Text('Apply donation'),
                            content: SingleChildScrollView(
                              child: ListBody(
                                  children: <Widget>[BloodDonationForm(
                                    closeForm: () {
                                      // Implement the logic to close the form
                                      Navigator.of(context).pop();
                                    }
                                  ),
                                  ]
                              ),
                            ),
                          );
                        },
                      );
                    },
                  ),
                  IconButton(
                    icon: Icon(Icons.delete),
                    onPressed: () {
                      showDialog(
                        context: context,
                        builder: (BuildContext context) {
                          return AlertDialog(
                            title: Text('Confirm'),
                            content: Text('Are you sure you want to delete request?'),
                            actions: <Widget>[
                              TextButton(
                                onPressed: () {
                                  Navigator.of(context).pop(); // Dismiss the dialog
                                },
                                child: Text('Cancel'),
                              ),
                              TextButton(
                                onPressed: () {
                                  deleteBloodRequest(widget.id);
                                  widget.onDelete();
                                  Navigator.of(context).pop(); // Dismiss the dialog after performing the action
                                },
                                child: Text('Delete'),
                              ),
                            ],
                          );
                        },
                      );
                    },
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}

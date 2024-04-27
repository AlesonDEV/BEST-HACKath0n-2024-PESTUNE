import 'dart:math';

import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';

import '../../mainpage.dart';
import '../../model/blood_types.dart';
import 'blood_request_form.dart';

const BGColor = const Color(0xffF5F5F3);
const TextColor = const Color(0xff1f2c4b);

class BloodRequestCard extends StatefulWidget {
  double progress = 0;
  double goal;
  BloodType bloodType;
  Function(BloodType type, double progress, double goal, int?) onTap;

  void handleTap(){
    onTap(this.bloodType, this.progress, this.goal, 0);
  }

  BloodRequestCard(this.goal, this.bloodType, {required this.onTap});
  BloodRequestCard.progress(this.goal, this.bloodType, this.progress, {required this.onTap});

  @override
  State<StatefulWidget> createState() => _BloodRequestState();
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
                'Blood Type: ${widget.bloodType.toShortString()}', // Assuming BloodTypes is a string enum or similar
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
                    valueColor: AlwaysStoppedAnimation(choosenButtonColor),
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
                                    CloseForm: () {
                                      // Implement the logic to close the form
                                      Navigator.of(context).pop();
                                    },
                                    AddRequest: (double donation, BloodType type) {
                                      // Implement the logic to handle the donation request
                                      // For example, you might want to update the state or send the data to a server
                                      Navigator.of(context).pop();
                                    },
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
                                  // TODO: Implement delete functionality
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

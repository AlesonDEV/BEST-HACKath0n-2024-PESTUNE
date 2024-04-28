import 'package:blood_flow/superviser_client/pages/requestInfo.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../components/Navigation/navigation.dart';
import '../components/homePageWidgets/blood_request_card.dart';
import '../components/homePageWidgets/blood_request_form.dart';
import '../components/homePageWidgets/blood_requests_container.dart';
import '../mainpage.dart';
import '../model/Donor.dart';
import '../model/blood_types.dart';

class HomePageWidget extends StatefulWidget {
  HomePageWidget({
    super.key,
  });



  @override
  State<StatefulWidget> createState() => _HomePageState();
}

class _HomePageState extends State<HomePageWidget>{
  final GlobalKey<BloodRequestContainerState> _key = GlobalKey();

  void onRequestCardTaped(BloodTypeOld bloodType, double progress, double goal, int? id){
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => BloodRequestInfoScreen(
          bloodType: bloodType.toShortString(),
          progress: progress,
          goal: goal, donors: [Donor("Yura", "Debelyak", 0.3)],
        ),
      ),
    );
  }
  @override
  Widget build(BuildContext context) {
    return(
        Stack(
          children: [
            BloodRequestContainer(key: _key),
            Positioned(
              bottom: 100,
              right: 20,
              child: ElevatedButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (BuildContext context) {
                      return AlertDialog(
                        title: Text('Blood Donation Form'),
                        content: SingleChildScrollView(
                          child: ListBody(
                            children: <Widget>[
                              BloodDonationForm(CloseForm: (){
                                Navigator.of(context).pop();
                              }, AddRequest: (double goal, BloodTypeOld type){
                                _key.currentState!.AddRequestCard(BloodRequestCard(goal, type, onTap: onRequestCardTaped,));
                                setState(() {
                                });
                                Navigator.of(context).pop();
                              },), // Your custom form widget
                            ],
                          ),
                        ),
                      );
                    },
                  );
                },
                child: Icon(Icons.add), // Replace with your desired icon
                style: ElevatedButton.styleFrom(
                  foregroundColor: ActiveIconColor, backgroundColor: choosenButtonColor, // Icon color
                  shape: CircleBorder(), // Make the button round
                  padding: EdgeInsets.all(24), // Button size
                ),
              ),
            ),
          ],
        )
    );
  }

}
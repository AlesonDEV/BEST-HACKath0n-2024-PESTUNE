import 'package:blood_flow/components/homePageWidgets/blood_request_card.dart';
import 'package:blood_flow/components/homePageWidgets/blood_requests_container.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../components/Navigation/navigation.dart';
import '../mainpage.dart';

class HomePageWidget extends StatelessWidget {
  final GlobalKey<BloodRequestContainerState> _key = GlobalKey();

  HomePageWidget({
    super.key,
  });

  final List<BloodRequestCard> cards = const <BloodRequestCard>[];

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
                _key.currentState!.AddRequestCard(BloodRequestCard());
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
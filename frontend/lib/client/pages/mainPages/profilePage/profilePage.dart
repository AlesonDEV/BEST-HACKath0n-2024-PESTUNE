import 'package:blood_flow/client/components/profilePage/profile_card_widget.dart';
import 'package:blood_flow/client/models/User.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/historyPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/medicalIdPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/settingsPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/supportPage.dart';
import 'package:flutter/material.dart';
import '../../../config/colors.dart';

class ProfilePage extends StatelessWidget {

  User user = User(
    name: 'Franchuk Ivan',
    id: '12412',
    bloodType: 'B+',
    age: 18,
    profilePictureUrl: 'https://example.com/user-profile-image.jpg',
  );

  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [

        SizedBox(height: screenSize.height / 8.0),
        Padding(
          padding: EdgeInsets.all(16.0),
          child: ProfileCard(screenSize: screenSize, user: user),
        ),
      ],
    );
  }
}

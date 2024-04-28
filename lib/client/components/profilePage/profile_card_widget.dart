import 'package:blood_flow/client/config/colors.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/historyPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/medicalIdPage.dart';
import 'package:flutter/material.dart';

import 'package:google_fonts/google_fonts.dart';

class ProfileCard extends StatelessWidget {
  const ProfileCard({
    super.key,
    required this.screenSize,
  });

  final Size screenSize;

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Center(
        child: Stack(
          alignment: Alignment(0.0, -1.25),
          children:[
            Card(
            color: CardColor,
            margin: EdgeInsets.all(24.0),
            child: Padding(
              padding: EdgeInsets.all(16.0),
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [

                  SizedBox(height: 60.0),

                  Text(
                    'Franchuk Ivan',
                    style: GoogleFonts.ubuntu(
                      textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 24),
                      fontWeight: FontWeight.w700,
                    ),
                  ),

                  Container(
                    decoration: BoxDecoration(
                      color: SecondaryCardColor,
                      borderRadius: BorderRadius.circular(30.0),
                    ),
                    padding: EdgeInsets.all(8.0),
                    child: Text(
                      'ID: 12412',
                      style: GoogleFonts.cabin(
                        textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 12),
                        fontWeight: FontWeight.w700,
                      ),
                    ),
                  ),

                  SizedBox(height: 24.0),

                  Container(
                    padding: EdgeInsets.all(8.0),
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(60.0),
                      color: ImportantCardColor,
                    ),
                    child: Row(
                      children: [
                        CircleAvatar(
                          radius: 25.0,
                          backgroundColor: MainColor,
                          backgroundImage: NetworkImage('URL_фото'),
                        ),
                        SizedBox(width: 16.0),
                        Expanded(
                          child: Text(
                            'Treatment History',
                            textAlign: TextAlign.center,
                            style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
                          ),
                        ),
                        SizedBox(width: 16.0),
                        ElevatedButton(
                          onPressed: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(builder: (context) => HistoryPage()),
                            );
                          },
                          style: ButtonStyle(
                            backgroundColor: MaterialStateProperty.all<Color>(Colors.black),
                            foregroundColor: MaterialStateProperty.all<Color>(Colors.white),
                            ),
                          child: Text('View',
                              style: GoogleFonts.cabin(
                              textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 14),
                          fontWeight: FontWeight.w700,
                        ),),
                        ),
                      ],
                    ),
                  ),

                  SizedBox(height: 16.0),

                  Container(
                    padding: EdgeInsets.symmetric(vertical: 8.0),
                    child: Row(
                      children: [
                        Expanded(
                          child: Column(
                            children: [
                              Container(
                                alignment: Alignment.center,
                                padding: EdgeInsets.symmetric(horizontal: 8.0),
                                child: Text(
                                  'B+',
                                  style: GoogleFonts.cabin(
                                    textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 40),
                                    fontWeight: FontWeight.w700,
                                  ),
                                ),
                              ),
                              Text(
                                'Blood type',
                                style: GoogleFonts.cabin(
                                  textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 12),
                                  fontWeight: FontWeight.w500,
                                ),
                              ),
                            ],
                          ),
                        ),
                        Container(
                          width: 1.0,
                          color: Colors.grey,
                          height: 40.0,
                        ),
                        Expanded(
                          child: Column(
                            children: [
                              Container(
                                alignment: Alignment.center,
                                padding: EdgeInsets.symmetric(horizontal: 8.0),
                                child: Text(
                                  '18',
                                  style: GoogleFonts.cabin(
                                    textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 40),
                                    fontWeight: FontWeight.w700,
                                  ),
                                ),
                              ),
                              Text(
                                'Years old',
                                style: GoogleFonts.cabin(
                                  textStyle: TextStyle(color: MainColor, letterSpacing: 0.5, fontSize: 12),
                                  fontWeight: FontWeight.w500,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),

            Stack(
              alignment: Alignment.bottomCenter,
              children: [
                CircleAvatar(
                  radius: 60,
                  backgroundImage: NetworkImage('https://example.com/user-profile-image.jpg'),
                ),
                IconButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => MedicalIdPage()),
                    );
                  },
                  icon: Icon(Icons.edit),
                ),
              ],
            ),
      ],
      ),
      ),
    );
  }
}

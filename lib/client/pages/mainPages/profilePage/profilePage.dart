import 'package:blood_flow/client/pages/mainPages/profilePage/historyPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/medicalIdPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/settingsPage.dart';
import 'package:blood_flow/client/pages/mainPages/profilePage/supportPage.dart';
import 'package:flutter/material.dart';
import '../../../config/colors.dart';

class ProfilePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Padding(
        padding: EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Stack(
              alignment: Alignment.bottomCenter,
              children: [
                CircleAvatar(
                  radius: 60,
                  backgroundImage: NetworkImage('https://example.com/user-profile-image.jpg'),
                ),
                IconButton(
                  onPressed: () {
                    
                  },
                  icon: Icon(Icons.edit),
                ),
              ],
            ),
            SizedBox(height: 20),
            Text(
              'User Name',
              style: TextStyle(
                fontSize: 24,
                fontWeight: FontWeight.bold,
              ),
            ),
            Text(
              'user@example.com',
              style: TextStyle(
                fontSize: 16,
                color: Colors.grey[600],
              ),
            ),

            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => MedicalIdPage()),
                );
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(ButtonColor),
                foregroundColor: MaterialStateProperty.all<Color>(MainTextColor),
                minimumSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Встановлення висоти
                fixedSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Фіксування висоти
              ),
              child: Text('Medical ID'),
            ),
            SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => HistoryPage()),
                );
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(ButtonColor),
                foregroundColor: MaterialStateProperty.all<Color>(MainTextColor),
                minimumSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Встановлення висоти
                fixedSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Фіксування висоти
              ),
              child: Text('History'),
            ),


            SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => SettingsPage()),
                );
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(ButtonColor),
                foregroundColor: MaterialStateProperty.all<Color>(MainTextColor),
                minimumSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Встановлення висоти
                fixedSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Фіксування висоти
              ),
              child: Text('Settings'),
            ),
            SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => SupportPage()),
                );
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(ButtonColor),
                foregroundColor: MaterialStateProperty.all<Color>(MainTextColor),
                minimumSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Встановлення висоти
                fixedSize: MaterialStateProperty.all(Size(double.infinity, 50)), // Фіксування висоти
              ),
              child: Text('Support'),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                // Дії для виходу з профілю
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(SecondaryColor),
                foregroundColor: MaterialStateProperty.all<Color>(MainColor),
              ),
              child: Text('Exit'),
            ),
          ],
        ),
      ),
    );
  }
}

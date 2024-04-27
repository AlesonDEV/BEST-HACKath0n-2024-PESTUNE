import 'package:blood_flow/superviser_client/pages/profile/settings_component.dart';
import 'package:flutter/material.dart';

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
                    // Дії для редагування профілю
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

            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => SettingsPage()),
                );
              },
              style: ElevatedButton.styleFrom(
                padding: EdgeInsets.symmetric(vertical: 16.0),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                minimumSize: Size(double.infinity, 0),
              ),
              child: Text('Settings'),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                // Дії для виходу з профілю
              },
              style: ElevatedButton.styleFrom(
                padding: EdgeInsets.symmetric(vertical: 16.0),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                minimumSize: Size(double.infinity, 0),
              ),
              child: Text('Exit'),
            ),
          ],
        ),
      ),
    );
  }
}

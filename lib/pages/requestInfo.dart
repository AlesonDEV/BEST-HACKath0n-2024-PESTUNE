import 'package:flutter/material.dart';

class BloodRequestInfoScreen extends StatelessWidget {
  final String bloodType;
  final double progress;
  final double goal;

  BloodRequestInfoScreen({required this.bloodType, required this.progress, required this.goal});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Blood Request Info'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              'Blood Type: $bloodType',
              style: TextStyle(fontSize: 24),
            ),
            SizedBox(height: 20),
            Text(
              'Progress: ${(progress / goal * 100).toStringAsFixed(2)}%',
              style: TextStyle(fontSize: 24),
            ),
          ],
        ),
      ),
    );
  }
}

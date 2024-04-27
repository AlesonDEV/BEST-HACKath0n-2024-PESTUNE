import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';
import '../components/infoWidgets/donor_card.dart';
import '../model/Donor.dart';

class BloodRequestInfoScreen extends StatelessWidget {
  final String bloodType;
  final double progress;
  final double goal;
  final List<Donor> donors;

  BloodRequestInfoScreen({
    required this.bloodType,
    required this.progress,
    required this.goal,
    required this.donors,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Blood Request Info'),
      ),
      body: Column(
        children: [
          Expanded(
            flex: 2,
            child: Center(
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
                  SizedBox(height: 20),
                  Container(
                    width: 200,
                    height: 200,
                    child: LiquidCircularProgressIndicator(
                      value: progress / goal < 0.08 ? 0.08 : progress / goal,
                      valueColor: AlwaysStoppedAnimation(Colors.red),
                      backgroundColor: Colors.white,
                      borderColor: Colors.black,
                      borderWidth: 5.0,
                      direction: Axis.vertical,
                      center: Text(
                        '${(progress / goal * 100).toStringAsFixed(2)}%',
                        style: TextStyle(fontSize: 24),
                      ),
                    ),
                  ),
                  SizedBox(height: 20,),
                  SingleChildScrollView(
                    child: Column(
                      children: donors.map((donor) => DonorCard(donor)).toList(),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}

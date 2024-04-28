import 'package:blood_flow/superviser_client/components/infoWidgets/donor_sesition_navigation.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';
import '../components/infoWidgets/donor_card.dart';
import '../model/Donor.dart';

class BloodRequestInfoScreen extends StatefulWidget {
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
  State<StatefulWidget> createState() => _BloodRequestInforState();
}

class _BloodRequestInforState extends State<BloodRequestInfoScreen>{
  int _selectedIndex = 0;
  void setSelectedIndex(int index){
    setState(() {
      _selectedIndex = index;
    });
  }

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
                    'Blood Type: $widget.bloodType',
                    style: TextStyle(fontSize: 24),
                  ),
                  SizedBox(height: 20),
                  Text(
                    'Progress: ${(widget.progress / widget.goal * 100).toStringAsFixed(2)}%',
                    style: TextStyle(fontSize: 24),
                  ),
                  SizedBox(height: 20),
                  Container(
                    width: 200,
                    height: 200,
                    child: LiquidCircularProgressIndicator(
                      value: widget.progress / widget.goal < 0.08 ? 0.08 : widget.progress / widget.goal,
                      valueColor: AlwaysStoppedAnimation(Colors.red),
                      backgroundColor: Colors.white,
                      borderColor: Colors.black,
                      borderWidth: 5.0,
                      direction: Axis.vertical,
                      center: Text(
                        '${(widget.progress / widget.goal * 100).toStringAsFixed(2)}%',
                        style: TextStyle(fontSize: 24),
                      ),
                    ),
                  ),
                  SizedBox(height: 20,),
                  DonnorNavigation(setSelectedIndex),
                  SizedBox(height: 20),
                  SingleChildScrollView(
                    child: IndexedStack(
                      index: _selectedIndex,
                      children: [
                        Column(
                          children: widget.donors.map((donor) => DonorCard(donor)).toList(),
                        ),
                        Text("Second page")
                      ],
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

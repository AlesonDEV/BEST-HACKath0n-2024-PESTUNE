import 'dart:math';

import 'package:blood_flow/mainpage.dart';
import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';

import '../../model/blood_types.dart';

const BGColor = const Color(0xffF5F5F3);
const TextColor = const Color(0xff1f2c4b);

class BloodRequestCard extends StatefulWidget {
  int progress = 0;
  int goal;
  BloodTypes bloodType;
  BloodRequestCard(this.goal, this.bloodType);
  BloodRequestCard.progress(this.goal, this.bloodType, this.progress);

  @override
  State<StatefulWidget> createState() => _BloodRequestState();
}

class _BloodRequestState extends State<BloodRequestCard> {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Padding(
      padding: const EdgeInsets.all(8.0),
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
              'Blood Type: ${widget.bloodType}', // Assuming BloodTypes is a string enum or similar
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 10),
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
                    // Implement edit action
                  },
                ),
                IconButton(
                  icon: Icon(Icons.delete),
                  onPressed: () {
                    // Implement delete action
                  },
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}

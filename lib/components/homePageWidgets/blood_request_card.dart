import 'package:blood_flow/components/homePageWidgets/blood_request_details.dart';
import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';
import '../../config/colors.dart';

class BloodRequestCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      decoration: BoxDecoration(
        color: MainColor,
        borderRadius: BorderRadius.circular(15),
      ),
      width: screenSize.width * 0.9,
      height: screenSize.height * 0.22,
      alignment: Alignment.center,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Container(
            width: 110.0,
            height: 110.0,
            child: LiquidCircularProgressIndicator(
              value: 0.5, // Defaults to 0.5.
              valueColor: AlwaysStoppedAnimation(Colors.pink),
              backgroundColor: Colors.white,
              borderColor: Colors.red,
              borderWidth: 1.0,
              direction: Axis.vertical,
              center: Text("A+"),
                ),
          ),
          Column(
            children: [
              SizedBox(height: 10),
              Text(
                'Blood request',
                style: TextStyle(fontSize: 24, color: MainTextColor),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 5),
              Text(
                'bebe bebe, 1',
                style: TextStyle(fontSize: 16, color: MainTextColor),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 5),
              Text(
                '1 liter',
                style: TextStyle(fontSize: 16, color: MainTextColor),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (BuildContext context) {
                      return DetailedBloodRequestCard();
                    },
                  );
                },
                child: Text('Відкрити віджет'),
              ),

            ],
          ),
        ],
      ),
    );
  }
}

import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';
import 'package:url_launcher/url_launcher.dart';

import '../../config/colors.dart';

class DetailedBloodRequestCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      decoration: BoxDecoration(
        color: MainColor,
        borderRadius: BorderRadius.circular(15),
      ),
      width: screenSize.width * 0.9,
      height: screenSize.width * 0.6,
      alignment: Alignment.center,
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Container(
            width: 200.0,
            height: 200.0,
            child: LiquidCircularProgressIndicator(
              value: 0.5,
              valueColor: AlwaysStoppedAnimation(Colors.pink),
              backgroundColor: Colors.white,
              borderColor: Colors.red,
              borderWidth: 1.0,
              direction: Axis.vertical,
              center: Text("A+"),
            ),
          ),
          SizedBox(height: 10),
          Text(
            'Запит на кров',
            style: TextStyle(fontSize: 24, color: MainTextColor),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 5),
          Text(
            'Адреса: вул. Перша, 1',
            style: TextStyle(fontSize: 16, color: MainTextColor),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 5),
          Text(
            'Кількість: 1 літр',
            style: TextStyle(fontSize: 16, color: MainTextColor),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 5),
          Text(
            'Електрона пошта: example@example.com',
            style: TextStyle(fontSize: 16, color: MainTextColor),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 5),
          Text(
            'Контактна інформація: +1234567890',
            style: TextStyle(fontSize: 16, color: MainTextColor),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 10),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: [
              ElevatedButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                child: Text('Скасувати'),
              ),

              ElevatedButton(
                onPressed: () {
                  // Записатися
                },
                child: Text('Записатися'),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

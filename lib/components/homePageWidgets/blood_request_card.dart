import 'package:flutter/material.dart';

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
      height: screenSize.width * 0.35,
      alignment: Alignment.center,
      child: Text(
        'hehe',
        style: TextStyle(fontSize: 24, color: SecondaryColor), // Зміна кольору тексту
        textAlign: TextAlign.center,
      ),
    );
  }
}
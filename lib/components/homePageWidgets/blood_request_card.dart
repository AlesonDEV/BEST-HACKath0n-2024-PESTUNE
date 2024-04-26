import 'package:flutter/material.dart';

const BGColor = const Color(0xffF5F5F3);
const TextColor = const Color(0xff1f2c4b);

class BloodRequestCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return
      Padding(
        padding: const EdgeInsets.all(8.0),
        child: Container(
          decoration: BoxDecoration(
            color: BGColor,
            borderRadius: BorderRadius.circular(15), // Заокруглення країв
          ),
          width: screenSize.width * 0.9,
          height: screenSize.height * 0.2,
          alignment: Alignment.center,
          child: Text(
            'hehe',
            style: TextStyle(fontSize: 24, color: TextColor), // Зміна кольору тексту
            textAlign: TextAlign.center,
          ),
        )
      );
  }
}
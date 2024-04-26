import 'package:flutter/material.dart';

import '../../../config/colors.dart';



class SliderImg extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      decoration: BoxDecoration(
        color: ElementColor,
        borderRadius: BorderRadius.circular(15), // Заокруглення країв
      ),
      alignment: Alignment.center,
      child: Text(
        'img_slider',
        style: TextStyle(fontSize: 24, color: MainColor), // Зміна кольору тексту
        textAlign: TextAlign.center,
      ),
    );
  }
}
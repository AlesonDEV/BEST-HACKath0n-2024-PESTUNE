import 'package:flutter/material.dart';

const BGColor = const Color(0xffc09880);
const TextColor = const Color(0xffF5F5F3);

class SliderImg extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      decoration: BoxDecoration(
        color: BGColor,
        borderRadius: BorderRadius.circular(15), // Заокруглення країв
      ),
      alignment: Alignment.center,
      child: Text(
        'img_slider',
        style: TextStyle(fontSize: 24, color: TextColor), // Зміна кольору тексту
        textAlign: TextAlign.center,
      ),
    );
  }
}
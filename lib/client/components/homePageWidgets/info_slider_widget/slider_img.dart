import 'package:flutter/material.dart';

import 'package:google_fonts/google_fonts.dart';

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
        style: GoogleFonts.nabla(
            textStyle: TextStyle(color: MainTextColor, letterSpacing: 0.5, fontSize: 24)
        ),
        textAlign: TextAlign.center,
      ),
    );
  }
}
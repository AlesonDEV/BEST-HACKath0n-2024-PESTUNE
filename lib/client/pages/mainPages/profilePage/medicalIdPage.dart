import 'dart:ui';

import 'package:blood_flow/client/components/profilePage/medical_card_widget.dart';
import 'package:flutter/material.dart';

import '../../../components/dymamicBG/metaballs_bg_widget.dart';

class MedicalIdPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;
    return Scaffold(
      appBar: AppBar(
        title: Text('Medical ID'),
      ),
      body: Stack(
        children: [
          Positioned.fill(
            child: MetaballsBackgroundWidget(),
          ),
          BackdropFilter(
            filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
            child: MedicalCard(screenSize: screenSize),
          ),
        ],
      ),
    );
  }
}


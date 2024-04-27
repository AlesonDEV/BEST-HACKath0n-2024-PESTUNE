import 'dart:ui';

import 'package:flutter/material.dart';

import '../../../components/dymamicBG/metaballs_bg_widget.dart';

class MedicalIdPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;
    return Scaffold(
      appBar: AppBar(
        title: Text('Медичний ID'),
      ),
      body: Stack(
        children: [
          Positioned.fill(
            child: MetaballsBackgroundWidget(),
          ),
          BackdropFilter(
            filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
            child: Container(
              child: Center(
                child: Card(
                  margin: EdgeInsets.all(16.0),
                  child: Padding(
                    padding: EdgeInsets.all(16.0),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        CircleAvatar(
                          radius: 90.0,
                          backgroundImage: NetworkImage('URL_фото'),
                        ),
                        SizedBox(height: 16.0, width: screenSize.width * 0.8),
                        Text(
                          'Franchuk Ivan',
                          style: TextStyle(fontSize: 28.0, fontWeight: FontWeight.bold),
                        ),
                        SizedBox(height: 8.0),
                        Text(
                          'id: #777',
                          style: TextStyle(fontSize: 18.0),
                        ),
                        SizedBox(height: 8.0),
                        Text(
                          '07 Jul 2005',
                          style: TextStyle(fontSize: 18.0),
                        ),
                        SizedBox(height: 8.0),
                        Text(
                          'Lviv, Kulparkivska 1',
                          style: TextStyle(fontSize: 18.0),
                        ),
                        SizedBox(height: 8.0),
                        Text(
                          'B+',
                          style: TextStyle(fontSize: 18.0),
                        ),
                        SizedBox(height: 8.0),
                        Text(
                          'example@example.com',
                          style: TextStyle(fontSize: 18.0),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

import 'dart:async';

import 'package:blood_flow/client/config/colors.dart';
import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';

class MapSample extends StatefulWidget {
  final CameraPosition kGooglePlex;
  final CameraPosition kLake;

  const MapSample({
    Key? key,
    required this.kGooglePlex,
    required this.kLake,
  }) : super(key: key);

  @override
  State<MapSample> createState() => MapSampleState();
}

class MapSampleState extends State<MapSample> {
  final Completer<GoogleMapController> _controller =
  Completer<GoogleMapController>();

  bool _lakeView = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Column(
          children: [

            SizedBox(height: 70),
            Row(
              children: [
                SizedBox(width: 30),
                Container(
                  width: 100.0,
                  height: 100.0,
                  child: LiquidCircularProgressIndicator(
                    value: 0.5,
                    valueColor: AlwaysStoppedAnimation(SecondaryColor),
                    backgroundColor: Colors.white,
                    borderColor: SecondaryColor,
                    borderWidth: 1.0,
                    direction: Axis.vertical,
                    center: Text("A+"),
                  ),
                ),
                Column(
                  children: [
                    Text(
                      'Ambulance 12',
                      style: TextStyle(fontSize: 24, color: MainTextColor),
                      textAlign: TextAlign.center,
                    ),
                    SizedBox(height: 5),
                    Text(
                      'Shevchenko street',
                      style: TextStyle(fontSize: 16, color: MainTextColor),
                      textAlign: TextAlign.center,
                    ),
                    SizedBox(height: 5),
                    Text(
                      '10000 ml',
                      style: TextStyle(fontSize: 16, color: MainTextColor),
                      textAlign: TextAlign.center,
                    ),
                    SizedBox(height: 5),
                    Text(
                      'example@example.com',
                      style: TextStyle(fontSize: 16, color: MainTextColor),
                      textAlign: TextAlign.center,
                    ),
                  ],
                ),
              ],
            ),
            SizedBox(height: 30),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                ElevatedButton(
                  onPressed: () {
                    Navigator.pop(context);
                  },
                  child: Text('Cancel'),
                ),

                ElevatedButton(
                  onPressed: () {
                    // Записатися
                  },
                  child: Text('Confirm'),
                ),
              ],
            ),

            SizedBox(height: 20),
            Container(
              width: 330.0,
              height: 330.0,
              child: GoogleMap(
                mapType: MapType.hybrid,
                initialCameraPosition: widget.kGooglePlex,
                onMapCreated: (GoogleMapController controller) {
                  _controller.complete(controller);
                },
              ),
            ),

          ],

        ),
      ),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: _toggleView,
        label: const Text('Scale'),
        icon: const Icon(Icons.directions_boat),
      ),
    );
  }

  Future<void> _toggleView() async {
    final GoogleMapController controller = await _controller.future;
    if (_lakeView) {
      await controller.animateCamera(CameraUpdate.newCameraPosition(widget.kGooglePlex));
      _lakeView = false;
    } else {
      await controller.animateCamera(CameraUpdate.newCameraPosition(widget.kLake));
      _lakeView = true;
    }
  }
}
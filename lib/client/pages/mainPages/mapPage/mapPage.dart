import 'dart:async';

import 'package:blood_flow/client/pages/mainPages/mapPage/mapMarkers.dart';
import 'package:blood_flow/client/pages/mainPages/mapPage/singleObjectMap.dart';
import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class MapPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height * 0.8, // 80% висоти екрану
      child: Center(
        child: MapSample(
          kGooglePlex: CameraPosition(
            target: LatLng(37.42796133580664, -122.085749655962),
            zoom: 14.4746,
          ),
          kLake: CameraPosition(
            bearing: 192.8334901395799,
            target: LatLng(37.43296265331129, -122.08832357078792),
            tilt: 59.440717697143555,
            zoom: 19.151926040649414,
          ),
        ),
      ),
    );
  }
}


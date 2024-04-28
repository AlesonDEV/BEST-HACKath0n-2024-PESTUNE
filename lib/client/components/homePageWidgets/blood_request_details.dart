import 'package:blood_flow/client/pages/mainPages/mapPage/singleObjectMap.dart';
import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';

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
        height: MediaQuery.of(context).size.height * 0.9,
        width: MediaQuery.of(context).size.width * 0.9,
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
      ),

        ],
      ),
    );
  }
}

import 'package:blood_flow/client/components/homePageWidgets/request_details_widget.dart';
import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';

import '../../../config/colors.dart';

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
              target: LatLng(49.83716, 24.05086),
              zoom: 16.4746,
            ),
            kLake: CameraPosition(
              bearing: 192.8334901395799,
              target: LatLng(49.83716, 24.05086),
              tilt: 59.440717697143555,
              zoom: 19.151926040649414,
            ),
            ambulanceName: 'Ambulance 12',
            streetName: 'Shevchenko street',
            bloodAmount: '10000 ml',
            email: 'example@example.com',
          ),
        ),
      ),

        ],
      ),
    );
  }
}

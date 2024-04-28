import 'dart:async';

import 'package:blood_flow/client/pages/mainPages/mapPage/mapMarkers.dart';
import 'package:blood_flow/client/components/homePageWidgets/request_details_widget.dart';
import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class MapPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height * 1,
      child: WidgetMarkersScreen(), // Використовуємо клас WidgetMarkersScreen для відображення маркерів на карті
    );
  }
}



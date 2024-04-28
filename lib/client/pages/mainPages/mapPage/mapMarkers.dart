import 'dart:async';
import 'dart:typed_data';
import 'dart:ui' as ui;

import 'package:blood_flow/client/components/mapPageWidgets/custom_marker_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

List<Map<String, dynamic>> data = [
  {
    'id': '1',
    'name': 'Franchuk Ivan',
    'globalKey': GlobalKey(),
    'position': LatLng(1.32, 103.80),
    'widget': CustomMarkerWidget(price: 200),
  },
  {
    'id': '2',
    'name': 'Bebe bebe',
    'globalKey': GlobalKey(),
    'position': LatLng(1.323, 103.82),
    'widget': CustomMarkerWidget(price: 200),
  },
  {
    'id': '3',
    'name': 'Ohoh hoho',
    'globalKey': GlobalKey(),
    'position': LatLng(1.325, 103.78),
    'widget': CustomMarkerWidget(price: 200),
  },
];

class WidgetMarkersScreen extends StatefulWidget{
  const WidgetMarkersScreen({super.key});

  @override
  State<WidgetMarkersScreen> createState() => _WidgetMarkersScreenState();
}

class _WidgetMarkersScreenState extends State<WidgetMarkersScreen>{
  final Completer<GoogleMapController> _controller = Completer();
  final Map<String, Marker> _markers = {};

  static const CameraPosition _cameraPosition = CameraPosition(
    target: LatLng(1.35, 103.80),
    zoom: 12,
  );

  bool _isLoaded = false;

  @override
  void initState(){
    WidgetsBinding.instance.addPostFrameCallback((_)=>_onBuildComplete());
    super.initState();
  }

  @override
  Widget build(BuildContext context){
    return Scaffold(
      body:
      /*_isLoaded ?*/
      GoogleMap(
        myLocationButtonEnabled: false,
        initialCameraPosition: _cameraPosition,
        onMapCreated: (GoogleMapController controller){
          _controller.complete(controller);
        },
        markers: _markers.values.toSet(),
      ) /*:
          ListView(children: [
            for (final item in data)
              Transform.translate(
                offset: Offset(
                  -MediaQuery.of(context).size.width * 0,
                  -MediaQuery.of(context).size.height * 0,
                ),
                child: RepaintBoundary(
                  key: item['globalKey'],
                  child: item['widget'],
                ),
              ),
          ],),*/
    );
  }

  Future<void> _onBuildComplete() async {
    await Future.wait(
      data.map((value) async{
        Marker marker = await _createMarker(value);
        _markers[marker.markerId.value] = marker;
    }));
    setState(() {
      _isLoaded = true;
    });
  }

  Future<Marker> _createMarker(
      Map<String, dynamic> data,
      ) async {
    RenderRepaintBoundary boundary = data['globalKey']
        .currentState
        ?.findRenderObject() as RenderRepaintBoundary;

   ui.Image image = await boundary.toImage(pixelRatio: 2);
   ByteData? byteData = await image.toByteData(
       format: ui.ImageByteFormat.png
   );

    return Marker(
      markerId: MarkerId(data['id']),
      position: data['position'],
      icon: BitmapDescriptor.fromBytes(byteData!.buffer.asUint8List()),
    );
  }
}
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
    'position': LatLng(49.8281008176169, 24.016234715611397),
    'widget': CustomMarkerWidget(price: 200),
  },
  {
    'id': '2',
    'name': 'Bebe bebe',
    'globalKey': GlobalKey(),
    'position': LatLng(49.8275319548568, 24.015525148459542),
    'widget': CustomMarkerWidget(price: 200),
  },
  {
    'id': '3',
    'name': 'Ohoh hoho',
    'globalKey': GlobalKey(),
    'position': LatLng(49.843558094896636, 24.044563139186426),
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
    target: LatLng(49.8, 24.0),
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
    var markers = {
      const Marker(
        markerId: MarkerId('1'),
        position: LatLng(49.838756183047714, 24.011238125952502),
      ),
      const Marker(
        markerId: MarkerId('2'),
        position: LatLng(49.8281008176169, 24.016234715611397),
      ),
      const Marker(
        markerId: MarkerId('3'),
        position: LatLng(49.8275319548568, 24.015525148459542),
      ),
      const Marker(
        markerId: MarkerId('4'),
        position: LatLng(49.843558094896636, 24.044563139186426),
      ),
      const Marker(
        markerId: MarkerId('5'),
        position: LatLng(49.87418748101075, 24.03965523254601),
      ),
    };

    return Scaffold(
      body:
      /*_isLoaded ?*/
      GoogleMap(
        myLocationButtonEnabled: false,
        initialCameraPosition: _cameraPosition,
        onMapCreated: (GoogleMapController controller){
          _controller.complete(controller);
        },
        markers: markers,
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
import 'package:blood_flow/client/components/homePageWidgets/blood_request_card.dart';
import 'package:blood_flow/client/components/homePageWidgets/info_slider_widget/info_slider_widget.dart';
import 'package:blood_flow/client/models/BloodRequest.dart';
import 'package:blood_flow/config/config.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'dart:convert';
import 'package:http/http.dart' as http;

class Order {
  final int id;
  final String title;
  final String description;
  final int bloodVolume;
  final int bloodTypeId;
  final String bloodTypeName;
  final int importanceId;
  final String importanceName;
  final int donorCenterId;
  final String donorCenterName;

  Order({
    required this.id,
    required this.title,
    required this.description,
    required this.bloodVolume,
    required this.bloodTypeId,
    required this.bloodTypeName,
    required this.importanceId,
    required this.importanceName,
    required this.donorCenterId,
    required this.donorCenterName,
  });

  factory Order.fromJson(Map<String, dynamic> json) {
    return Order(
      id: json['id'] as int,
      title: json['title'] as String,
      description: json['description'] as String,
      bloodVolume: json['bloodVolume'] as int,
      bloodTypeId: json['bloodTypeId'] as int,
      bloodTypeName: json['bloodTypeName'] as String,
      importanceId: json['importanceId'] as int,
      importanceName: json['importanceName'] as String,
      donorCenterId: json['donorCenterId'] as int,
      donorCenterName: json['donorCenterName'] as String,
    );
  }
}

Future<List<Order>> fetchOrdersByBloodType(int bloodTypeId) async {
  final response = await http.get(Uri.parse(Config.baseUrl + "/Orders?BloodTypeId=$bloodTypeId"));

  if (response.statusCode == 200) {
    final List<dynamic> jsonResponse = jsonDecode(response.body);
    final List<Order> orders = jsonResponse.map((data) => Order.fromJson(data)).toList();
    return orders;
  } else {
    throw Exception('Failed to load orders');
  }
}

List<BloodRequest> bloodRequests = [
  BloodRequest(hospitalName: 'Skarzhyntsi', bloodDonated: 500, totalBloodRequired: 1000.0),
  BloodRequest(hospitalName: 'Yablunivka', bloodDonated: 700, totalBloodRequired: 1000),
  BloodRequest(hospitalName: 'Biber', bloodDonated: 1200, totalBloodRequired: 2000),
  BloodRequest(hospitalName: 'Ginger', bloodDonated: 200, totalBloodRequired: 500),
];

class HomePageWidget extends StatelessWidget {
  const HomePageWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Order>>(
      future: fetchOrdersByBloodType(2), // Assuming bloodTypeId is 2
      builder: (context, snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return CircularProgressIndicator(); // Show a loading indicator while waiting for data
        } else if (snapshot.hasError) {
          return Text('Error loading orders: ${snapshot.error}');
        } else if (!snapshot.hasData) {
          return Text('No data available');
        } else {
          final List<Order> orders = snapshot.data!;

          // Print orders to console
          for (var order in orders) {
            print('Order ID: ${order.id}');
            print('Title: ${order.title}');
            // ... other fields
          }

          // Return your widget tree here
          return Container(
            child: Center(
              child: Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.only(left: 8.0, top: 8.0, right: 8.0, bottom: 0.0),
                    child: InfoSliderWidget(),
                  ),
                  Expanded(
                    child: SingleChildScrollView(
                      child: Column(
                        children: [
                          SizedBox(height: 20),
                          ...bloodRequests.map((request) => Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: BloodRequestCard(
                              hospitalName: request.hospitalName,
                              bloodDonated: request.bloodDonated,
                              totalBloodRequired: request.totalBloodRequired,
                            ),
                          )).toList(),
                          SizedBox(height: 100),
                        ],
                      ),
                    ),
                  ),
                ],
              ),
            ),
          );
        }
      },
    );
  }
}

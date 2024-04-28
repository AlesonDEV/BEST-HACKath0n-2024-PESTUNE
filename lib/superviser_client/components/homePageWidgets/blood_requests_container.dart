import 'dart:convert';

import 'package:blood_flow/config/config.dart';
import 'package:blood_flow/superviser_client/components/homePageWidgets/blood_request_card.dart';
import 'package:blood_flow/superviser_client/pages/requestInfo.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../../model/BloodType.dart';


class BloodRequestContainer extends StatefulWidget {
  const BloodRequestContainer({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => BloodRequestContainerState();
}

Future<List<BloodInfo>> fetchBloodInfoList() async {
  final url = Uri.parse(Config.baseUrl + "/Orders");

  final response = await http.get(url);

  if (response.statusCode == 200) {
    final data = jsonDecode(response.body) as List;
    return data.map((item) => BloodInfo.fromJson(item)).toList();
  } else {
    // Handle error (e.g., throw an exception or print an error message)
    throw Exception('Failed to load blood info list: ${response.statusCode}');
  }
}


class BloodInfo {
  final int id;
  final String title;
  final String description;
  final int bloodVolume;
  final int bloodTypeId;
  final int bloodTypeName;
  final int importanceId;
  final String importanceName;
  final int donorCenterId;
  final String donorCenterName;

  BloodInfo({
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

  factory BloodInfo.fromJson(Map<String, dynamic> json) => BloodInfo(
    id: json['id'] as int,
    title: json['title'] as String,
    description: json['description'] as String,
    bloodVolume: json['bloodVolume'] as int,
    bloodTypeId: json['bloodTypeId'] as int,
    bloodTypeName: json['bloodTypeName'] as int, // Might require clarification on data type
    importanceId: json['importanceId'] as int,
    importanceName: json['importanceName'] as String,
    donorCenterId: json['donorCenterId'] as int,
    donorCenterName: json['donorCenterName'] as String,
  );
}

class BloodRequestContainerState extends State<BloodRequestContainer> {
  static List<BloodRequestCard> bloodCards = [];

  @override
  void initState() {
    super.initState();
    _fetchData(); // Call the function to fetch data on state initialization
  }

  BloodRequestCard fetchCards(BloodInfo info){
    final bloodType = BloodType.bloodTypes[info.bloodTypeId]; // Map blood type ID to BloodTypeOld enum

    // Assuming a logic to determine progress based on information in BloodInfo (e.g., bloodVolume)
    final progress = 0; // Replace with your logic to calculate progress

    // Assuming a goal property exists in BloodInfo or a way to determine a goal
    final goal = info.bloodVolume; // Use goal if available, otherwise calculate it

    return BloodRequestCard.progress(info.id ,goal, bloodType, 0, onTap: (type, progress, goal) {
      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => BloodRequestInfoScreen(
            bloodType: BloodType.bloodTypes[bloodType.id].name,
            progress: progress,
            goal: goal, donors: [], id: info.id,
          ),
        ),
      );
    }, onDelete: (){
      print("object");
    });
  }

  Future<void> _fetchData() async {
    try {
      final bloodInfoList = await fetchBloodInfoList();
      // Assuming you have a method in BloodRequestCard to map BloodInfo to BloodRequestCard
      bloodCards = bloodInfoList.map((info) => fetchCards(info)).toList();
      setState(() {}); // Update UI after data is loaded
    } catch (error) {
      print('Error fetching blood info: $error');
      // Handle error appropriately (e.g., show error message)
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Center(
        child: Column(
          children: [
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: bloodCards,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
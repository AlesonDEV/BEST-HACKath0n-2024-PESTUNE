import 'package:blood_flow/config/config.dart';
import 'package:blood_flow/config/config.dart';
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
  final DonorCenter? donorCenter;

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
    this.donorCenter,
  });

  factory Order.fromJson(Map<String, dynamic> json) {
    return Order(
      id: json['id'],
      title: json['title'],
      description: json['description'],
      bloodVolume: json['bloodVolume'],
      bloodTypeId: json['bloodTypeId'],
      bloodTypeName: json['bloodTypeName'],
      importanceId: json['importanceId'],
      importanceName: json['importanceName'],
      donorCenterId: json['donorCenterId'],
      donorCenterName: json['donorCenterName'],
      donorCenter: DonorCenter.fromJson(json['donorCenter']),
    );
  }
}

class DonorCenter {
  final int cityId;
  final String cityName;
  final int streetId;
  final String streetName;
  final String houseNumber;
  final String latValue;
  final String lngValue;

  DonorCenter({
    required this.cityId,
    required this.cityName,
    required this.streetId,
    required this.streetName,
    required this.houseNumber,
    required this.latValue,
    required this.lngValue,
  });

  factory DonorCenter.fromJson(Map<String, dynamic> json) {
    return DonorCenter(
      cityId: json['cityId'],
      cityName: json['cityName'],
      streetId: json['streetId'],
      streetName: json['streetName'],
      houseNumber: json['houseNumber'],
      latValue: json['latValue'],
      lngValue: json['lngValue'],
    );
  }
}




Future<List<Order>> fetchOrdersByBloodType(int bloodTypeId) async {
  final response = await http.get(Uri.parse(Config.baseUrl + "/Orders?BloodTypeId=$bloodTypeId"));

  if (response.statusCode == 200) {
    // If the server returns a 200 OK response, then parse the JSON.
    var jsonResponse = jsonDecode(response.body) as List;
    List<Order> orders = jsonResponse.map((item) => Order.fromJson(item)).toList();
    return orders;
  } else {
    // If the server did not return a 200 OK response, then throw an exception.
    throw Exception('Failed to load orders');
  }
}

Future<DonorCenter> fetchDonorCenterAddress(int donorCenterId) async {
  final response = await http.get(Uri.parse(Config.baseUrl + "/DonorCenters/$donorCenterId/addresses"));

  if (response.statusCode == 200) {
    return DonorCenter.fromJson(jsonDecode(response.body));
  } else {
    throw Exception('Failed to load donor center address');
  }
}
import 'dart:convert';

import '../../config/config.dart';
import 'package:http/http.dart' as http;

class BloodType {
  int id;
  String name;

  BloodType(this.id, this.name);
  static List<BloodType> bloodTypes = [];

  factory BloodType.fromJson(Map<String, dynamic> json) {
    return BloodType(
      json['bloodTypeId'],
      json['bloodTypeName'],
    );
  }

}

Future<List<BloodType>> fetchBloodTypes() async {
  Uri test = Uri.parse(Config.baseUrl + "/BloodTypes");
  final response = await http.get(test, headers: {
    'accept': 'text/plain',
  });
  if (response.statusCode == 200) {
    final List<dynamic> data = json.decode(response.body);
    return data.map((json) => BloodType.fromJson(json)).toList();
  } else {
    throw Exception('Failed to load blood types');
  }
}


List<BloodType> parseBloodTypes(String responseBody) {
  final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();
  return parsed.map<BloodType>((json) => BloodType.fromJson(json)).toList();
}
import 'dart:convert';

import 'package:blood_flow/config/config.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class StreetDropdown extends StatefulWidget {
  final String url; // URL for GET request to fetch streets (based on cityId)
  final Function(int) onStreetSelected;
  int cityId;

  StreetDropdown({super.key, required this.url, required this.cityId, required this.onStreetSelected});

  @override
  State<StreetDropdown> createState() => _StreetDropdownState();
}

class _StreetDropdownState extends State<StreetDropdown> {
  List<Street> _streets = []; // List to store retrieved streets

  Future<void> _fetchStreets(int cityId) async {
    try {
      final url = Uri.parse(Config.baseUrl + "/Cities/${cityId}/streets"); // Build URL with cityId
      final response = await http.get(url);
      if (response.statusCode == 200) {
        final data = jsonDecode(response.body) as List;
        setState(() {
          _streets = data.map((street) => Street.fromJson(street)).toList();
        });
      } else {
        // Handle error (e.g., display a snackbar)
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text('Error fetching streets: ${response.statusCode}'),
          ),
        );
      }
    } catch (error) {
      // Handle network or other errors
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Error fetching streets: $error'),
        ),
      );
    }
  }

  @override
  void initState() {
    super.initState();
    _fetchStreets(widget.cityId);
  }

  @override
  Widget build(BuildContext context) {
    return DropdownButtonFormField<Street>(
      value: _streets.isEmpty ? null : _streets.first, // Handle initial state
      isExpanded: true, // Fill the available space
      hint: const Text('Select a Street'),
      items: _streets.map((street) => DropdownMenuItem<Street>(
        value: street,
        child: Text(street.streetName),
      )).toList(),
      onChanged: (street) => widget.onStreetSelected(street!.streetId),
    );
  }
}

class Street {
  final int streetId;
  final String streetName;

  Street({required this.streetId, required this.streetName});

  factory Street.fromJson(Map<String, dynamic> json) => Street(
    streetId: json['streetId'] as int,
    streetName: json['streetName'] as String,
  );
}
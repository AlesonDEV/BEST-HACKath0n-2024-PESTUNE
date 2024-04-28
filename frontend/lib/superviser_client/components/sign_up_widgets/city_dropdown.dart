import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class CityDropdown extends StatefulWidget {
  final String url; // URL for the GET request to fetch cities
  final Function(int) onCitySelected;

  const CityDropdown({Key? key, required this.url, required this.onCitySelected}) : super(key: key);

  @override
  State<CityDropdown> createState() => _CityDropdownState();
}

class _CityDropdownState extends State<CityDropdown> {
  List<City> _cities = []; // List to store retrieved cities
  City? _selectedCity; // Selected city object

  Future<void> _fetchCities() async {
    try {
      final response = await http.get(Uri.parse(widget.url));
      if (response.statusCode == 200) {
        final data = jsonDecode(response.body) as List;
        setState(() {
          _cities = data.map((city) => City.fromJson(city)).toList();
        });
      } else {
        // Handle error (e.g., display a snackbar)
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text('Error fetching cities: ${response.statusCode}'),
          ),
        );
      }
    } catch (error) {
      // Handle network or other errors
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Error fetching cities: $error'),
        ),
      );
    }
  }

  @override
  void initState() {
    super.initState();
    _fetchCities();
  }

  @override
  Widget build(BuildContext context) {
    return DropdownButtonFormField<City>(
      value: _selectedCity,
      isExpanded: true, // Fill the available space
      hint: const Text('Select a City'),
      items: _cities.map((city) => DropdownMenuItem<City>(
        value: city,
        child: Text(city.cityName),
      )).toList(),
      onChanged: (city) {
        setState(() => _selectedCity = city);
        widget.onCitySelected(city!.cityId);
      },
    );
  }
}

class City {
  final int cityId;
  final String cityName;

  City({required this.cityId, required this.cityName});

  factory City.fromJson(Map<String, dynamic> json) => City(
    cityId: json['cityId'] as int,
    cityName: json['cityName'] as String,
  );
}
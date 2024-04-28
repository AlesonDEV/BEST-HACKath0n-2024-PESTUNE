import 'package:flutter/material.dart';

import '../../model/BloodType.dart';

class BloodTypeDropdownFormField extends StatefulWidget {
  final Function(BloodType?) onChanged;

  BloodTypeDropdownFormField({required this.onChanged});

  @override
  _BloodTypeDropdownFormFieldState createState() => _BloodTypeDropdownFormFieldState();
}

class _BloodTypeDropdownFormFieldState extends State<BloodTypeDropdownFormField> {
  BloodType? _selectedBloodType;
  List<BloodType> _bloodTypes = [];
  String? _errorText;

  @override
  void initState() {
    super.initState();
    _bloodTypes = BloodType.bloodTypes;
  }

  String? _validateBloodType(BloodType? value) {
    if (value == null) {
      return 'Blood type is required';
    }
    return null;
  }

  @override
  Widget build(BuildContext context) {
    return DropdownButtonFormField<BloodType>(
      value: _selectedBloodType,
      onChanged: (BloodType? newValue) {
        setState(() {
          _selectedBloodType = newValue!;
          _errorText = null; // Reset error text
          widget.onChanged(newValue);
        });
      },
      validator: _validateBloodType,
      items: _bloodTypes.map((BloodType bloodTypeValue) {
        return DropdownMenuItem<BloodType>(
          value: bloodTypeValue,
          child: Text(bloodTypeValue.name),
        );
      }).toList(),
      decoration: InputDecoration(
        labelText: 'Blood Type',
        errorText: _errorText,
      ),
    );
  }
}

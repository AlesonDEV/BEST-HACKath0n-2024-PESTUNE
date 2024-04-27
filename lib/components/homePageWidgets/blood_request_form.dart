import 'package:blood_flow/model/blood_types.dart';
import 'package:flutter/material.dart';

class BloodDonationForm extends StatefulWidget {
  final Function() CloseForm;
  final Function(double goal, BloodTypes types) AddRequest;

  const BloodDonationForm({Key? key, required this.CloseForm, required this.AddRequest}) : super(key: key);

  @override
  _BloodDonationFormState createState() => _BloodDonationFormState();
}

class _BloodDonationFormState extends State<BloodDonationForm> {
  final _formKey = GlobalKey<FormState>();
  String _selectedBloodType = 'A+';
  double _selectedAmount = 1.0; // in liters

  @override
  Widget build(BuildContext context) {
    return Form(
        key: _formKey,
        child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
        DropdownButtonFormField<String>(
        value: _selectedBloodType,
        onChanged: (String? newValue) {
      setState(() {
        _selectedBloodType = newValue!;
      });
    },
    items: <String>['A+', 'B+', 'AB+', 'O+', 'A-', 'B-', 'AB-', 'O-']
        .map
      ((String value) {
      return DropdownMenuItem<String>(
        value: value,
        child: Text(value),
      );
    }).toList(),
          decoration: InputDecoration(
            labelText: 'Blood Type',
          ),
        ),
          SizedBox(height: 20),
          Slider(
            value: _selectedAmount,
            min: 0.5,
            max: 2.0,
            divisions: 3,
            onChanged: (value) {
              setState(() {
                _selectedAmount = value;
              });
            },
            label: 'Amount: ${_selectedAmount.toStringAsFixed(1)} liters',
          ),
          SizedBox(height: 20),
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 16.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                ElevatedButton(
                  onPressed: () {
                    widget.AddRequest(_selectedAmount, bloodTypeFromString(_selectedBloodType));
                  },
                  child: Text('Submit'),
                ),
                TextButton(
                  onPressed: () {
                    widget.CloseForm(); // Call the CloseForm function
                  },
                  child: Text('Cancel'),
                ),
              ],
            ),
          ),
        ],
        ),
    );
  }
}

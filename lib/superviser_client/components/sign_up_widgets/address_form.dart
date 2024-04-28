import 'package:flutter/material.dart';

class AddressForm extends StatefulWidget {
  final GlobalKey<FormState> formKey; // Pass the GlobalKey from the parent widget

  const AddressForm({Key? key, required this.formKey}) : super(key: key);

  @override
  _AddressFormState createState() => _AddressFormState();
}

class _AddressFormState extends State<AddressForm> {
  TextEditingController _cityController = TextEditingController();
  TextEditingController _buildingController = TextEditingController();
  TextEditingController _streetController = TextEditingController();

  bool validateAndSave() {
    final form = widget.formKey.currentState;
    if (form!.validate()) {
      form!.save();
      return true;
    }
    return false;
  }

  @override
  void dispose() {
    _cityController.dispose();
    _buildingController.dispose();
    _streetController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: widget.formKey, // Use the GlobalKey passed from the parent widget
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          TextFormField(
            controller: _cityController,
            decoration: InputDecoration(
              labelText: 'City',
              border: OutlineInputBorder(),
            ),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Please enter the city';
              }
              return null;
            },
          ),
          SizedBox(height: 16.0),
          TextFormField(
            controller: _streetController,
            decoration: InputDecoration(
              labelText: 'Street',
              border: OutlineInputBorder(),
            ),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Please enter the street';
              }
              return null;
            },
          ),
          SizedBox(height: 16.0),
          TextFormField(
            controller: _buildingController,
            decoration: InputDecoration(
              labelText: 'Building Number',
              border: OutlineInputBorder(),
            ),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Please enter the building number';
              }
              return null;
            },
          ),
          SizedBox(height: 16.0),
        ],
      ),
    );
  }
}

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:blood_flow/superviser_client/model/BloodType.dart';
import 'package:blood_flow/superviser_client/components/homePageWidgets/blood_checkbox.dart';
import 'package:http/http.dart' as http;

import '../../../config/config.dart';
import '../../model/blood_types.dart';

class BloodDonationForm extends StatefulWidget {
  final VoidCallback closeForm;

  const BloodDonationForm({Key? key, required this.closeForm}) : super(key: key);

  @override
  _BloodDonationFormState createState() => _BloodDonationFormState();
}

Future<http.Response> createBloodRequest(
    String title,
    String description,
    int bloodVolume,
    int bloodTypeId,
    int importanceId,
    String importanceName,
    int donorCenterId,
    String donorCenterName,
    ) async {
  final url = Uri.parse(Config.baseUrl + "/Orders"); // Replace with your actual API endpoint

  final body = jsonEncode(
    {
      "id": 0,
      "title": "string",
      "description": "string",
      "bloodVolume": bloodVolume,
      "bloodTypeId": bloodTypeId,
      "bloodTypeName": 0,
      "importanceId": 1,
      "importanceName": "string",
      "donorCenterId": Config.donorCenterId,
      "donorCenterName": "string"
    });

  final response = await http.post(
    url,
    headers: {"Content-Type": "application/json"},
    body: body,
  );

  if(response.statusCode > 200 && response.statusCode < 300){
    print("Created");
  }else{
    print(utf8.decode(response.bodyBytes));
    print("Error on creating request ${response.statusCode}");
  }
  return response;
}


class _BloodDonationFormState extends State<BloodDonationForm> {
  final _formKey = GlobalKey<FormState>();
  late BloodType _selectedBloodType;
  int _selectedAmount = 0; // in liters
  final _amountController = TextEditingController();

  @override
  void dispose() {
    _amountController.dispose();
    super.dispose();
  }

  bool _validateAndSave() {
    final form = _formKey.currentState;
    if (form != null && form.validate()) {
      form.save();
      return true;
    }
    return false;
  }

  String? _amountValidator(String? value) {

    if (value == null || value.isEmpty) {
      return 'Can\'t be empty';
    }
    final amount = int.tryParse(value);
    if (amount == null) {
      return 'Invalid number';
    } else if (amount < 1000) {
      return 'Too small amount';
    } else if (amount > 15000) {
      return 'Too big amount';
    }
    _selectedAmount = int.tryParse(value)!;
    return null;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              BloodTypeDropdownFormField(
                onChanged: (BloodType? selectedBloodType) {
                  if (selectedBloodType != null) {
                    _selectedBloodType = selectedBloodType;
                  }
                },
              ),
              SizedBox(height: 20),
              TextFormField(
                controller: _amountController,
                decoration: InputDecoration(
                  labelText: "Volume in ml",
                ),
                keyboardType: TextInputType.number,
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.digitsOnly
                ],
                validator: _amountValidator,
                onSaved: (value) {
                  if (value != null) {
                    _selectedAmount = int.parse(value);
                  }
                },
              ),
            ],
          ),
        ),
        SizedBox(height: 20),
        Padding(
          padding: const EdgeInsets.symmetric(vertical: 16.0),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () async {
                    _formKey.currentState!.validate();
                    await createBloodRequest("", "", _selectedAmount, _selectedBloodType.id, 1, "", Config.donorCenterId, "");
                    widget.closeForm;
                    },
                child: Text('Submit'),
              ),
              TextButton(
                onPressed: widget.closeForm,
                child: Text('Cancel'),
              ),
            ],
          ),
        ),
      ],
    );
  }
}

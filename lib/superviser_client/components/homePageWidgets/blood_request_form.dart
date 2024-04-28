import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:blood_flow/superviser_client/model/BloodType.dart';
import 'package:blood_flow/superviser_client/components/homePageWidgets/blood_checkbox.dart';

import '../../model/blood_types.dart';

class BloodDonationForm extends StatefulWidget {
  final VoidCallback closeForm;
  final Function(double goal, BloodTypeOld types) addRequest;

  const BloodDonationForm({Key? key, required this.closeForm, required this.addRequest}) : super(key: key);

  @override
  _BloodDonationFormState createState() => _BloodDonationFormState();
}

class _BloodDonationFormState extends State<BloodDonationForm> {
  final _formKey = GlobalKey<FormState>();
  late BloodType _selectedBloodType;
  double _selectedAmount = 0; // in liters
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
                    _selectedAmount = double.parse(value);
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
                onPressed: () {
                  if (_validateAndSave()) {
                    widget.addRequest(_selectedAmount, BloodTypeOld.O0); // TODO rewrite
                  }
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

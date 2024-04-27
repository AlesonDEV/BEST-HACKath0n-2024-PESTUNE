import 'package:flutter/material.dart';

import 'package:flutter/material.dart';

class BloodDonationForm extends StatefulWidget {
  final Function CloseForm;

  const BloodDonationForm({super.key, required this.CloseForm});
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


          Padding(
            padding: const EdgeInsets.symmetric(vertical: 16.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                ElevatedButton(
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {
                      // Process data
                    }
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
class SliderFormField extends FormField<double> {
  SliderFormField({
    double value = 1.0,
    required FormFieldSetter<double> onChanged,
    double min = 0.5,
    double max = 2.0,
    int divisions = 3,
    String label = '',
  }) : super(
    builder: (FormFieldState<double> state) {
      return Slider(
        value: value,
        onChanged: onChanged,
        min: min,
        max: max,
        divisions: divisions,
        label: label,
      );
    },
  );
}

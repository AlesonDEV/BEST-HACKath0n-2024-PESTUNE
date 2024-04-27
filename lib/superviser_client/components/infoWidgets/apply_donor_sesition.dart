import 'package:flutter/material.dart';

class ApplyDonorForm extends StatefulWidget {
  final Function() CloseForm;
  final Function(double donation) AddRequest;

  const ApplyDonorForm({Key? key, required this.CloseForm, required this.AddRequest}) : super(key: key);

  @override
  _ApplyDonorFormState createState() => _ApplyDonorFormState();
}

class _ApplyDonorFormState extends State<ApplyDonorForm> {
  final _formKey = GlobalKey<FormState>();
  double _selectedAmount = 1.0; // in liters

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: <Widget>[
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
                    widget.AddRequest(_selectedAmount);
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

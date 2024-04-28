import 'package:blood_flow/superviser_client/components/homePageWidgets/blood_checkbox.dart';
import 'package:blood_flow/superviser_client/model/BloodType.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import '../../model/blood_types.dart';

class BloodDonationForm extends StatefulWidget {
  final Function() CloseForm;
  final Function(double goal, BloodTypeOld types) AddRequest;

  BloodDonationForm({Key? key, required this.CloseForm, required this.AddRequest}) : super(key: key);

  @override
  _BloodDonationFormState createState() => _BloodDonationFormState();
}

class _BloodDonationFormState extends State<BloodDonationForm> {

  final _formKey = GlobalKey<FormState>();
  late BloodType _selectedBloodType;
  double _selectedAmount = 0; // in liters

  final _controller = TextEditingController();

  // dispose it when the widget is unmounted
  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  String? get _errorText {
    // at any time, we can get the text from _controller.value.text
    final text = _controller.value.text;
    // Note: you can do your own custom validation here
    // Move this logic this outside the widget for more testable code
    if (text.isEmpty) {
      return 'Can\'t be empty';
    }
    if (int.parse(text) < 1000) {
      return 'Too small amount';
    }

    if (int.parse(text) < 1000) {
      return 'Too small amount';
    }
    if(int.parse(text) > 15000){
      return 'Too big amount';
    }
    // return null if the text is valid
    return null;
  }



  @override
  Widget build(BuildContext context) {
    return
      Column(
        children: [
        Form(
        key: _formKey,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            BloodTypeDropdownFormField(onChanged: (BloodType? selectedBloodType) {
              _selectedBloodType = _selectedBloodType;
            },),
            SizedBox(height: 20),
            TextField(
              decoration: InputDecoration(
                labelText: "Volume in ml",
                errorText: _errorText,
              ),
              controller: _controller,
              keyboardType: TextInputType.number,
              inputFormatters: <TextInputFormatter>[
                FilteringTextInputFormatter.digitsOnly
              ],
              // Only numbers can be entered
              onChanged: (value) {
                setState(() {
                  if(!value.isEmpty) _selectedAmount = double.parse(value);
                });
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
                    if(_errorText == null && _formKey.currentState!.validate()){
                      widget.AddRequest(_selectedAmount, bloodTypeFromString("O-"));
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
      );
  }
}

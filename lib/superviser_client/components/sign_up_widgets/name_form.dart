import 'package:flutter/material.dart';

class NameFormWidget extends StatefulWidget {
  final GlobalKey<FormState> formKey;
  final Function(String) onSavedName; // Callback to pass the name value

  const NameFormWidget({Key? key, required this.formKey, required this.onSavedName}) : super(key: key);

  @override
  _NameFormWidgetState createState() => _NameFormWidgetState();
}

class _NameFormWidgetState extends State<NameFormWidget> {
  String _name = "";

  bool validateAndSave() {
    final form = widget.formKey.currentState;
    if (form!.validate()) {
      form.save();
      widget.onSavedName(_name); // Pass the name value to the callback
      return true;
    }
    return false;
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: widget.formKey,
      child: Column(
        children: <Widget>[
          TextFormField(
            decoration: InputDecoration(labelText: 'Name'),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Please enter your name.';
              }
              widget.onSavedName(value);
              return null;
            },
            onSaved: (value) {
              if (value != null) {
                _name = value;
              }
            },
          ),
          // The submit button can be removed if the form submission is handled by the parent widget
        ],
      ),
    );
  }
}

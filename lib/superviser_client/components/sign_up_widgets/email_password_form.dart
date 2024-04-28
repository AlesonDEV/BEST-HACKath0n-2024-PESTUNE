import 'package:flutter/material.dart';

class LoginNPasswordForm extends StatefulWidget {
  final GlobalKey<FormState> formKey; // Pass the GlobalKey from the parent widget
  final Function(String, String)? onFormSubmit; // Callback for form submission
  final Function(String) onPasswordChanged;
  final Function(String) onLoginChanged;

  const LoginNPasswordForm({Key? key, required this.formKey, this.onFormSubmit, required this.onPasswordChanged, required this.onLoginChanged}) : super(key: key);

  @override
  _LoginNPasswordFormState createState() => _LoginNPasswordFormState();
}

class _LoginNPasswordFormState extends State<LoginNPasswordForm> {
  String _email = "";
  String _password = "";
  String _confirmPassword = "";

  bool validateAndSave() {
    final form = widget.formKey.currentState;
    if (form!.validate()) {
      form.save();
      widget.onFormSubmit!(_email, _password); // Use the callback to submit the form
      return true;
    }
    return false;
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: widget.formKey, // Use the GlobalKey passed from the parent widget
      child: Column(
        children: <Widget>[
          TextFormField(
            decoration: InputDecoration(labelText: 'Email'),
            validator: (value) {
              if (value!.isEmpty || !value.contains('@')) {
                return 'Please enter a valid email address.';
              }
              return null;
            },
            onSaved: (value) {
              _email = value!;
            },
          ),
          TextFormField(
            decoration: InputDecoration(labelText: 'Password'),
            obscureText: true,
            validator: (value) {
              setState(() {
                _password = value!;
              });
              if (value!.isEmpty || value.length < 7) {
                return 'Password must be at least 7 characters long.';
              }
              return null;
            },
            onSaved: (value) {
              _password = value!;
            },
          ),
          TextFormField(
            decoration: InputDecoration(labelText: 'Confirm Password'),
            obscureText: true,
            validator: (value) {
              if (value != _password) {
                return 'Passwords do not match.';
              }
              return null;
            },
            onSaved: (value) {
              _confirmPassword = value!;
            },
          ),
          // The submit button can be removed if the form submission is handled by the parent widget
        ],
      ),
    );
  }
}

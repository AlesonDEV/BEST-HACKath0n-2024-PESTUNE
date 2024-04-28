import 'package:blood_flow/client/mainpage.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


class LoginForm extends StatefulWidget {
  @override
  _LoginFormState createState() => _LoginFormState();
}

class _LoginFormState extends State<LoginForm> {
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();

  Future<void> _login() async {
    var response = await http.post(
      Uri.parse('YOUR_SERVER_ENDPOINT/login'),
      body: {
        'username': _usernameController.text,
        'password': _passwordController.text,
      },
    );

    if (response.statusCode == 200) {
      var data = json.decode(response.body);
      if (data['isValidUser']) {
        Navigator.pushReplacement(
          context,
          MaterialPageRoute(builder: (context) =>
            MainPage() // TODO Implement this hop
          ),
        );
      } else {
        // Handle invalid login
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Invalid credentials')),
        );
      }
    } else {
      // Handle network error
      // ScaffoldMessenger.of(context).showSnackBar(
      //   SnackBar(content: Text('Network error')),
      // );
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(builder: (context) =>
            MainPage() // TODO Implement this hop
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {

    return(Padding(
      padding: EdgeInsets.all(16.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          TextField(
            controller: _usernameController,
            decoration: InputDecoration(
              labelText: 'Username',
            ),
          ),
          SizedBox(height: 8.0),
          TextField(
            controller: _passwordController,
            decoration: InputDecoration(
              labelText: 'Password',
            ),
            obscureText: true,
          ),
          SizedBox(height: 24.0),
          ElevatedButton(
            onPressed: _login,
            child: Text('Login'),
          ),
        ],
      ),
    ));
  }
}

import 'package:blood_flow/client/pages/authorization/singUpPage.dart';
import 'package:blood_flow/superviser_client/pages/authorization/loginPage.dart';
import 'package:flutter/material.dart';
import 'superviser_client/mainpage.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('Login'),
        ),
        body: LoginForm(),
      ),
    );
  }
}

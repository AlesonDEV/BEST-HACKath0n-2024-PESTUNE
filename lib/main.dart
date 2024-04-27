import 'package:blood_flow/pages/authorization/singUpPage.dart';
import 'package:flutter/material.dart';

import 'mainpage.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: SingUpPage(),
    );
  }
}


import 'dart:html' as html;

import 'package:blood_flow/client/mainpage.dart';
import 'package:blood_flow/superviser_client/mainpage.dart';
import 'package:blood_flow/superviser_client/pages/authorization/singUpPage.dart';
import 'package:flutter/material.dart';
import 'dart:io';
import 'package:http/http.dart' as http;
void main() async{
  WidgetsFlutterBinding.ensureInitialized(); // Required by FlutterConfig
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: MainPage(),
    );
  }
}

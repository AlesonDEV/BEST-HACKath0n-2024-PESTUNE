import 'package:blood_flow/client/pages/authorization/singUpPage.dart';
import 'package:flutter/material.dart';
void main() async{
  WidgetsFlutterBinding.ensureInitialized(); // Required by FlutterConfig

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

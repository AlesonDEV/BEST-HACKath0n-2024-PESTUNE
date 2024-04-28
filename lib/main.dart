import 'package:blood_flow/client/pages/authorization/singUpPage.dart';
import 'package:flutter/material.dart';
import 'package:flutter_config/flutter_config.dart';


void main() async{
  WidgetsFlutterBinding.ensureInitialized(); // Required by FlutterConfig
  await FlutterConfig.loadEnvVariables();

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

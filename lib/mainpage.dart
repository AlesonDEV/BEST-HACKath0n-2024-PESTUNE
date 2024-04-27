import 'package:blood_flow/pages/homePage.dart';
import 'package:blood_flow/pages/profilePage.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

import 'components/Navigations/navigation.dart';
import 'config/colors.dart';


class MainPage extends StatefulWidget {
  const MainPage({Key? key}) : super(key: key);

  @override
  State<MainPage> createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {
  int _selectedIndex = 0;

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: BGColor,
      body: SafeArea(
        bottom: false,
        child: Stack(
          children: [
            IndexedStack(
              index: _selectedIndex,
              children: [
                Container(
                  // Your AiCamera content here
                  child: Center(
                    child: Text('AiCamera Content'),
                  ),
                ),
                HomePageWidget(),
                ProfilePage(),
              ],
            ),
            Navigation(_onItemTapped),
          ],
        ),
      ),
    );
  }
}


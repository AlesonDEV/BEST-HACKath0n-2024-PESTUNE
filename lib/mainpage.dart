import 'package:blood_flow/pages/homePage.dart';
import 'package:blood_flow/pages/profile/profile_page.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

import 'components/Navigation/navigation.dart';

const navbarColor = const Color(0xfff5f5f5);
const choosenButtonColor = const Color(0xff1f2c4b);
const IdleIconColor = const Color(0xff1f2c4b);
const NavigationOutline = const Color(0xff1f2c4b);
const ActiveIconColor = const Color(0xffedecea);
const MainBackgroundColor = const Color(0xffd5d4d2);

const colorqqq = const Color(0xffc09880);

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
      backgroundColor: MainBackgroundColor,
      body: SafeArea(
        bottom: false,
        child: Stack(
          children: [
            IndexedStack(
              index: _selectedIndex,
              children: [
                HomePageWidget(),
                ProfilePage()
              ],
            ),
            Navigation(this._onItemTapped),
          ],
        ),
      ),
    );
  }
}


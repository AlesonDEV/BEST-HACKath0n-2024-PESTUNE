import 'package:blood_flow/pages/homePage.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

const navbarColor = const Color(0xfff5f5f5);
const choosenButtonColor = const Color(0xff1f2c4b);
const IdleIconColor = const Color(0xff1f2c4b);
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
                Container(
                  // Your AiCamera content here
                  child: Center(
                    child: Text('AiCamera Content'),
                  ),
                ),
                HomePageWidget(),
                Container(
                  // Your Map content here
                  child: Center(
                    child: Text('Map Content'),
                  ),
                ),
              ],
            ),
            Positioned(
              left: 20,
              right: 20,
              bottom: 15,
              child: ClipRRect(
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(40.0),
                  topRight: Radius.circular(40.0),
                  bottomLeft: Radius.circular(40.0),
                  bottomRight: Radius.circular(40.0),
                ),
                child: Container(
                  decoration: BoxDecoration(
                    color: navbarColor,
                    borderRadius: BorderRadius.circular(40),
                  ),
                  child: Padding(
                    padding: EdgeInsets.symmetric(horizontal: 10, vertical: 10),
                    child: GNav(
                      backgroundColor: navbarColor,
                      color: IdleIconColor,
                      activeColor: ActiveIconColor,
                      tabBackgroundColor: choosenButtonColor,
                      gap: 3,
                      onTabChange: _onItemTapped,
                      padding: EdgeInsets.only(left: 20.0, top: 10.0, right: 20.0, bottom: 10.0),
                      tabs: [
                        GButton(
                          icon: Icons.map_rounded,
                          text: 'Map',
                        ),
                        GButton(
                          icon: Icons.home,
                          text: 'Home',
                        ),
                        GButton(
                          icon: Icons.perm_identity_rounded,
                          text: 'Profile ',
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}


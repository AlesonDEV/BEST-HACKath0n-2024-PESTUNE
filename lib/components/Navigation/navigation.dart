import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

import '../../mainpage.dart';

class Navigation extends StatelessWidget{

  final Function(int) onItemTapped;

  Navigation(this.onItemTapped, {super.key});
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    var screenSize = MediaQuery.of(context).size;

    return(
        Positioned(
          left: 20,
          right: 20,
          bottom: 15,
          child: Container(
            decoration: BoxDecoration(
              borderRadius: const BorderRadius.only(
                topLeft: Radius.circular(40.0),
                topRight: Radius.circular(40.0),
                bottomLeft: Radius.circular(40.0),
                bottomRight: Radius.circular(40.0),
              ),
              boxShadow: [
                BoxShadow(
                  color: Colors.grey.withOpacity(0.5),
                  spreadRadius: 10,
                  blurRadius: 10,
                  offset: Offset(0,0),
                ),
              ],
            ),
            child: ClipRRect(
              borderRadius: const BorderRadius.only(
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
                    onTabChange: onItemTapped,
                    padding: EdgeInsets.only(left: 100.0, top: 10.0, right: 100.0, bottom: 10.0),
                    tabs: const [
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
        )
    );
  }

}
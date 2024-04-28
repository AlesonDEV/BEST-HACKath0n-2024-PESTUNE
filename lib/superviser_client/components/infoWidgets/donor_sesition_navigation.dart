import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

import '../../mainpage.dart';

class DonnorNavigation extends StatelessWidget{

  final Function(int) onItemTapped;

  DonnorNavigation(this.onItemTapped, {super.key});
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    var screenSize = MediaQuery.of(context).size;

    return(
        Container(
          width: screenSize.width*0.8,
          child: Container(
            decoration: BoxDecoration(
              borderRadius: const BorderRadius.only(
                topLeft: Radius.circular(40.0),
                topRight: Radius.circular(40.0),
                bottomLeft: Radius.circular(40.0),
                bottomRight: Radius.circular(40.0),
              ),
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
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    padding: EdgeInsets.only(left: 20.0, top: 10.0, right: 20.0, bottom: 10.0),
                    tabs: const [
                      GButton(
                        icon: Icons.verified,
                        text: 'Completed',
                      ),
                      GButton(
                        icon: Icons.question_mark,
                        text: 'Possible',
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
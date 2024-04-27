import 'package:blood_flow/mainpage.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../model/Donor.dart';

class DonorCard extends StatelessWidget{
  Donor donor;
  DonorCard(this.donor);
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery
        .of(context)
        .size;

    return Container(
      decoration: BoxDecoration(
        color: IdleIconColor,
        borderRadius: BorderRadius.circular(15),
      ),
      width: screenSize.width * 0.9,
      height: screenSize.height * 0.22,
      alignment: Alignment.center,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Container(
            width: 110.0,
            height: 110.0,
            child: CircleAvatar(
              radius: 50,
            ),
          ),
          Center(
            child:  Column(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                SizedBox(height: 10),
                Text(
                  '${donor.name} ${donor.surname}',
                  style: TextStyle(fontSize: 24, color: Colors.white),
                  textAlign: TextAlign.center,
                ),
                SizedBox(height: 5),
                Text(
                  '${donor.volume * 100} ml',
                  style: TextStyle(fontSize: 16, color: Colors.white),
                  textAlign: TextAlign.center,
                ),
                SizedBox(height: 5),
              ],
            ),
          )
        ],
      ),
    );
  }
}
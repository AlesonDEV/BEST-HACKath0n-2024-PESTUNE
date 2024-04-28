import 'package:blood_flow/client/pages/mainPages/homePage/blood_request_details_page.dart';
import 'package:flutter/material.dart';
import 'package:liquid_progress_indicator_v2/liquid_progress_indicator.dart';
import '../../config/colors.dart';
import 'package:google_fonts/google_fonts.dart';


class BloodRequestCard extends StatelessWidget {
  final String hospitalName;
  final double bloodDonated;
  final double totalBloodRequired;

  BloodRequestCard({
    required this.hospitalName,
    required this.bloodDonated,
    required this.totalBloodRequired,
  });
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      decoration: BoxDecoration(
        color: MainColor,
        borderRadius: BorderRadius.circular(15),
      ),
      width: screenSize.width * 0.9,
      height: screenSize.height * 0.18,
      alignment: Alignment.center,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Container(
            width: 110.0,
            height: 110.0,
            child: LiquidCircularProgressIndicator(
              value: bloodDonated / totalBloodRequired,
              valueColor: AlwaysStoppedAnimation(SecondaryColor),
              backgroundColor: Colors.white,
              borderColor: SecondaryColor,
              borderWidth: 1.0,
              direction: Axis.vertical,
              center: Text("A+"),
                ),
          ),
          Column(
            children: [
              SizedBox(height: 10),


              Text(
                hospitalName,
                style: GoogleFonts.ubuntu(
                  textStyle: TextStyle(color: MainTextColor, letterSpacing: 0.5, fontSize: 24),
                  fontWeight: FontWeight.w700,
                ),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 5),
              Text(
                totalBloodRequired.toString() + ' ml',
                style: TextStyle(fontSize: 16, color: MainTextColor),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (BuildContext context) {
                      return DetailedBloodRequestCard();
                    },
                  );
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(ButtonColor),
                  foregroundColor: MaterialStateProperty.all<Color>(MainTextColor),
                ),
                child: Text('More details'),
              ),


            ],
          ),
        ],
      ),
    );
  }
}

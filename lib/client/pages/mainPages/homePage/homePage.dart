import 'package:blood_flow/client/components/homePageWidgets/blood_request_card.dart';
import 'package:blood_flow/client/components/homePageWidgets/info_slider_widget/info_slider_widget.dart';
import 'package:blood_flow/client/models/BloodRequest.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class HomePageWidget extends StatelessWidget {
  const HomePageWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    List<BloodRequest> bloodRequests = [
      BloodRequest(hospitalName: 'Skarzhyntsi', bloodDonated: 500, totalBloodRequired: 1000.0),
      BloodRequest(hospitalName: 'Yablunivka', bloodDonated: 700, totalBloodRequired: 1000),
      BloodRequest(hospitalName: 'Biber', bloodDonated: 1200, totalBloodRequired: 2000),
      BloodRequest(hospitalName: 'Ginger', bloodDonated: 200, totalBloodRequired: 500),
    ];

    return Container(
      child: Center(
        child: Column(
          children: [
            Padding(
              padding: const EdgeInsets.only(left: 8.0, top: 8.0, right: 8.0, bottom: 0.0),
              child: InfoSliderWidget(),
            ),
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    SizedBox(height: 20),
                    ...bloodRequests.map((request) => Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: BloodRequestCard(
                        hospitalName: request.hospitalName,
                        bloodDonated: request.bloodDonated,
                        totalBloodRequired: request.totalBloodRequired,
                      ),
                    )).toList(),
                    SizedBox(height: 100),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
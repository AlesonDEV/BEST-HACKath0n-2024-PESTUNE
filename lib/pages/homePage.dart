import 'package:blood_flow/components/homePageWidgets/blood_request_card.dart';
import 'package:blood_flow/components/homePageWidgets/info_slider_widget/info_slider_widget.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class HomePageWidget extends StatelessWidget {
  const HomePageWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
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
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: BloodRequestCard(),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: BloodRequestCard(),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: BloodRequestCard(),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: BloodRequestCard(),
                    ),
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
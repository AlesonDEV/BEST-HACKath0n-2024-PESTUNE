import 'package:blood_flow/components/homePageWidgets/blood_request_card.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../components/Navigation/navigation.dart';

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
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    BloodRequestCard(),
                    BloodRequestCard(),
                    BloodRequestCard(),
                    BloodRequestCard(),
                    BloodRequestCard(),
                    BloodRequestCard(),
                    BloodRequestCard(),
                    BloodRequestCard()
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
import 'package:flutter/cupertino.dart';

import 'blood_request_card.dart';

class BloodRequestContainer extends StatefulWidget{
  const BloodRequestContainer({Key? key}): super(key: key);
  @override
  State<StatefulWidget> createState() => _BloodRequestContainerState();
}

class _BloodRequestContainerState extends State<BloodRequestContainer>{
  @override
  Widget build(BuildContext buildContext){
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


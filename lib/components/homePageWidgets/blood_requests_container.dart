import 'package:blood_flow/model/blood_types.dart';
import 'package:flutter/cupertino.dart';
import 'blood_request_card.dart';

class BloodRequestContainer extends StatefulWidget {

  const BloodRequestContainer({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => BloodRequestContainerState();
}

class BloodRequestContainerState extends State<BloodRequestContainer> {
  static List<BloodRequestCard> bloodCards = [BloodRequestCard.progress(20, BloodTypes.A0, 10), BloodRequestCard(30, BloodTypes.B1), BloodRequestCard(5, BloodTypes.AB1)];

  void AddRequestCard(BloodRequestCard toAdd){
    BloodRequestContainerState.bloodCards.add(toAdd);
  }
  @override
  Widget build(BuildContext buildContext) {
    return Container(
      child: Center(
        child: Column(
          children: [
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: BloodRequestContainerState.bloodCards,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

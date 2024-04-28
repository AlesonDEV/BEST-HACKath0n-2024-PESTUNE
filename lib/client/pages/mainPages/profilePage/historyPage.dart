import 'package:blood_flow/client/components/profilePage/profile_card_widget.dart';
import 'package:flutter/material.dart';

class HistoryPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {

    var screenSize = MediaQuery.of(context).size;
    return Scaffold(
      appBar: AppBar(
        title: Text('Історія'),
      ),
      body: Center(),
    );
  }
}

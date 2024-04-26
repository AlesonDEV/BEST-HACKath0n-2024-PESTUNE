import 'package:flutter/material.dart';

import '../../model/blood_types.dart';

const BGColor = const Color(0xffF5F5F3);
const TextColor = const Color(0xff1f2c4b);

class BloodRequestCard extends StatefulWidget {
  int progress = 0;
  int goal;
  BloodTypes bloodType;
  BloodRequestCard(this.goal, this.bloodType);
  BloodRequestCard.progress(this.goal, this.bloodType, this.progress);

  @override
  State<StatefulWidget> createState() => _BloodRequestState();
}

class _BloodRequestState extends State<BloodRequestCard>{
  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery
        .of(context)
        .size;

    return
      Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            decoration: BoxDecoration(
              color: BGColor,
              borderRadius: BorderRadius.circular(15), // Заокруглення країв
            ),
            width: screenSize.width * 0.9,
            height: screenSize.height * 0.2,
            alignment: Alignment.center,
            child: LinearProgressIndicator(
              value: widget.progress/widget.goal, // 70% progress
              backgroundColor: Colors.grey,
              valueColor: AlwaysStoppedAnimation<Color>(Colors.red),
            ),
          )
      );
  }
}

class AnimatedLinearProgressBar extends StatefulWidget {
  final double value;
  final Color backgroundColor;
  final Color color;

  const AnimatedLinearProgressBar({
    Key? key,
    required this.value,
    required this.backgroundColor,
    required this.color,
  }) : super(key: key);

  @override
  State<AnimatedLinearProgressBar> createState() => _AnimatedLinearProgressBarState();
}

class _AnimatedLinearProgressBarState extends State<AnimatedLinearProgressBar>
    with SingleTickerProviderStateMixin {
  late Animation<double> _animation;
  late AnimationController _controller;

  @override
  void initState() {
    super.initState();
    _controller = AnimationController(vsync: this, duration: Duration(seconds: 2));
    _animation = Tween<double>(begin: 0.0, end: widget.value).animate(_controller);
    _controller.forward();
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.circular(10),
      child: Stack(
        children: [
          Container(
            width: double.infinity,
            height: 10,
            color: widget.backgroundColor,
          ),
          LayoutBuilder(
            builder: (context, constraints) {
              return AnimatedBuilder(
                animation: _animation,
                builder: (context, child) => Container(
                  width: constraints.maxWidth * _animation.value,
                  height: 10,
                  color: widget.color,
                ),
              );
            },
          ),
        ],
      ),
    );
  }
}
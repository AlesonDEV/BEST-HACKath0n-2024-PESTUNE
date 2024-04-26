import 'package:blood_flow/components/homePageWidgets/info_slider_widget/slider_img.dart';
import 'package:flutter/material.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart'; // Correct import

const BGColor = const Color(0xffF5F5F3);
const IdleDotColor = const Color(0xffd5d4d2);
const CurentDotColor = const Color(0xff1f2c4b);

class InfoSliderWidget extends StatelessWidget {
  final _controller = PageController();

  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      height: screenSize.height * 0.2,
      decoration: BoxDecoration(
        color: BGColor,
        borderRadius: BorderRadius.circular(15),
      ),
      child: Stack(
        children: [
          SizedBox(
            height: screenSize.height * 0.2,
            child: PageView(
              controller: _controller,
              children: [
                SliderImg(),
                SliderImg(),
                SliderImg(),
                SliderImg(),
              ],
            ),
          ),
          Positioned(
            bottom: 5,
            left: screenSize.width * 0.37,
            right: 0,
            child: SmoothPageIndicator(
              controller: _controller,
              count: 4,
              effect: JumpingDotEffect(
                activeDotColor:  CurentDotColor,
                dotColor: IdleDotColor,
                dotHeight: 10,
                dotWidth: 10,
                spacing: 16,
                jumpScale: 3,
              ),
            ),
          ),
        ],
      ),
    );
  }
}

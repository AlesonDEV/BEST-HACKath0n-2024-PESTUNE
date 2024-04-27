import 'package:flutter/material.dart';
import 'package:metaballs/metaballs.dart';


class MetaballsBackgroundWidget extends StatelessWidget {
  const MetaballsBackgroundWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Metaballs(
        color: const Color(0xff683434),

        gradient: LinearGradient(
            colors: [
              const Color(0xffa94748),
              const Color(0xffdc2626),
            ],
            begin: Alignment.bottomRight,
            end: Alignment.topLeft
        ),
        metaballs: 30,
        animationDuration: const Duration(milliseconds: 200),
        speedMultiplier: 0.5,
        bounceStiffness: 3,
        minBallRadius: 30,
        maxBallRadius:40,
        glowRadius: 0.1,
        glowIntensity: 0.1
    );
  }
}
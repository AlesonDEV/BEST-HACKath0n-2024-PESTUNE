import 'package:flutter/material.dart';

import '../../mainpage.dart';

class SingUpPage extends StatefulWidget {
  const SingUpPage({super.key});

  @override
  State<SingUpPage> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<SingUpPage> {
  int currentStep = 0;
  bool isComplete = false;
  continueStep() {
    if (currentStep < 2) {
      setState(() {
        currentStep = currentStep + 1;
      });
    }
  }

  cancelStep() {
    if (currentStep > 0) {
      setState(() {
        currentStep = currentStep - 1;
      });
    }
  }

  onStepTapped(int value) {
    setState(() {
      currentStep = value;
    });
  }

  Widget controlBuilders(context, details) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          OutlinedButton(
            onPressed: details.onStepCancel,
            child: const Text('Back'),
          ),
          const SizedBox(width: 10),

          ElevatedButton(
            onPressed: details.onStepContinue,
            child: const Text('Next'),
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stepper(
        elevation: 0, //Horizontal Impact
        // margin: const EdgeInsets.all(20), //vertical impact
        controlsBuilder: controlBuilders,
        type: StepperType.horizontal,
        physics: const ScrollPhysics(),
        onStepTapped: onStepTapped,
        onStepContinue: () {
          final isLastStep = currentStep == 2;

          if (isLastStep) {
            showDialog(
              context: context,
              builder: (BuildContext context) {
                return AlertDialog(
                  title: const Text('Congratulations!'),
                  content: const Text('You have completed the sign-up process.'),
                  actions: <Widget>[
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).pop(); // Закриваємо діалогове вікно
                        Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (BuildContext context) => MainPage(),
                        ));
                      },

                      child: const Text('OK'),
                    ),
                  ],
                );
              },
            );
          } else {
            continueStep();
          }
        },

        onStepCancel: cancelStep,
        currentStep: currentStep, //0, 1, 2
        steps: [
          Step(
            title: const Text('Account'),
            content: Column(
              children: const [
                Text('This is the First step.'),
                SizedBox(height: 20),
                TextField(
                  decoration: InputDecoration(
                    labelText: 'Email',
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.all(
                        Radius.circular(30.0), // Заокруглення кутиків
                      ),
                    ),
                  ),
                ),
                SizedBox(height: 20),
                TextField(
                  decoration: InputDecoration(
                    labelText: 'Password',
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.all(
                        Radius.circular(30.0), // Заокруглення кутиків
                      ),
                    ),
                  ),
                ),
              ],
            ),
            isActive: currentStep >= 0,
            state: currentStep >= 0 ? StepState.complete : StepState.disabled,
          ),

          Step(
            title: const Text('Address'),
            content: const Text('This is the Second step.'),
            isActive: currentStep >= 0,
            state: currentStep >= 1 ? StepState.complete : StepState.disabled,
          ),
          Step(
            title: const Text('Complete'),
            content: const Text('This is the Third step.'),
            isActive: currentStep >= 0,
            state: currentStep >= 2 ? StepState.complete : StepState.disabled,
          ),
        ],
      ),
    );
  }
}

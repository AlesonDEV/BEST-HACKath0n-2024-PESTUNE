import 'package:blood_flow/client/config/colors.dart';
import 'package:blood_flow/client/models/BloodType.dart';
import 'package:blood_flow/client/pages/authorization/blood_dropdown.dart';
import 'package:flutter/material.dart';

import '../../mainpage.dart';

class SingUpPage extends StatefulWidget {
  const SingUpPage({super.key});

  @override
  State<SingUpPage> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<SingUpPage> {
  BloodType? _selectedBloodType;
  DateTime? _dateOfBirth;

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

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime.now(),
    );
    if (picked != null && picked != _dateOfBirth)
      setState(() {
        _dateOfBirth = picked;
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
      body: Theme(
        data: ThemeData(
          primaryColor: SecondaryColor,
          colorScheme: ColorScheme.light(primary: SecondaryColor),
        ),
        child: Stepper(
          elevation: 0,
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
                          Navigator.of(context).pop();
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
              title: const Text(''),
              content: Column(
                children: [
                  const Text(
                    'Personal info',
                    style: TextStyle(color: MainTextColor),
                  ),
                  const SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'Name',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                  const SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'Surname',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                  const SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'Date of Birth',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                    onTap: () {
                      FocusScope.of(context).requestFocus(new FocusNode()); // to remove the keyboard if shown
                      _selectDate(context);
                    },
                    controller: TextEditingController(text: _dateOfBirth != null ? _dateOfBirth!.toIso8601String() : ''),
                  ),
                  const SizedBox(height: 20),
                  BloodTypeDropdownFormField(
                    onChanged: (BloodType? newBloodType) {
                      // This function will be called whenever the selected blood type changes.
                      // 'newBloodType' is the newly selected blood type.
                      // You can add your code here to handle the change.
                      setState(() {
                        _selectedBloodType = newBloodType;
                      });
                    },
                  ),
                ],
              ),
              isActive: currentStep >= 0,
              state: currentStep >= 0 ? StepState.complete : StepState.disabled,
            ),

            Step(
              title: const Text(''),
              content: Column(
                children: [
                  const Text('Authentication data'),
                  SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'Email',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                  SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'Password',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                  SizedBox(height: 20),

                ],
              ),
              isActive: currentStep >= 0,
              state: currentStep >= 1 ? StepState.complete : StepState.disabled,
            ),
            Step(
              title: const Text(' '),
              content: Column(
                children: [
                  const Text('Adress Information'),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'City Name',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                  SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'Street Name',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                  SizedBox(height: 20),
                  TextField(
                    decoration: InputDecoration(
                      labelText: 'House Number',
                      labelStyle: TextStyle(color: MainTextColor),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(
                          Radius.circular(30.0),
                        ),
                        borderSide: BorderSide(color: MainTextColor),
                      ),
                      contentPadding: EdgeInsets.symmetric(vertical: 10.0, horizontal: 20.0),
                    ),
                  ),
                ],
              ),
              isActive: currentStep >= 0,
              state: currentStep >= 2 ? StepState.complete : StepState.disabled,
            ),
          ],
        ),
      ),
    );
  }
}

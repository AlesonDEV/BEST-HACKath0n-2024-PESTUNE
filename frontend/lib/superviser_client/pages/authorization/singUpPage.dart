import 'dart:convert';

import 'package:blood_flow/config/config.dart';
import 'package:blood_flow/superviser_client/components/sign_up_widgets/email_password_form.dart';
import 'package:blood_flow/superviser_client/components/sign_up_widgets/name_form.dart';
import 'package:flutter/material.dart';

import '../../components/sign_up_widgets/address_form.dart';
import '../../mainpage.dart';
import 'package:http/http.dart' as http;

class SingUpPage extends StatefulWidget {
  const SingUpPage({super.key});

  @override
  State<SingUpPage> createState() => _HomeScreenState();
}

Future<int> sendDonorCenterData(String donorCenterName) async {
  // Define the JSON data
  Map<String, dynamic> jsonData = {
    "donorCenterId": 0,
    "donorCenterName": donorCenterName,
  };

  // Encode the JSON data
  String requestBody = json.encode(jsonData);

  // Define the URL
  String url = '${Config.baseUrl}/DonorCenters';

  try {
    // Make the POST request
    var response = await http.post(
      Uri.parse(url),
      headers: {
        'Content-Type': 'application/json', // Set the content type
      },
      body: requestBody, // Pass the encoded JSON data as the body
    );

    // Check if the request was successful (status code 2xx)
    if (response.statusCode >= 200 && response.statusCode < 300) {
      // Parse response JSON
      Map<String, dynamic> responseData = json.decode(response.body);
      // Extract donorCenterId
      int donorCenterId = responseData['donorCenterId'];
      return donorCenterId;
    } else {
      throw Exception("Bad request");
    }
  } catch (e) {
    print('Error sending data: $e');
    throw Exception("Failed to send data");
  }
}

Future<http.Response> createContact(int id,String contactValue) async {
  final url = Uri.parse(Config.baseUrl + "/Donors/${id}/contacts"); // Replace with your actual API endpoint

  final body = jsonEncode({
    "contactId": id,
    "contactValue": contactValue,
  });

  final response = await http.post(
    url,
    headers: {"Content-Type": "application/json"},
    body: body,
  );

  return response;
}

Future<http.Response> createAddress(int donorCenterId,int cityId, int streetId, String houseNumber) async {
  final url = Uri.parse('Config.baseUrl + "/Cities/${cityId}/streets"'); // Replace with your actual API endpoint

  final body = jsonEncode({
    "cityId": cityId,
    "cityName": "cityName",
    "streetId": streetId,
    "streetName": "streetName",
    "houseNumber": houseNumber,
  });

  final response = await http.post(
    url,
    headers: {"Content-Type": "application/json"},
    body: body,
  );

  return response;
}

class _HomeScreenState extends State<SingUpPage> {
  int currentStep = 0;
  bool isComplete = false;

  final _nameFormKey = GlobalKey<FormState>();
  final _emailPasswordFormKey = GlobalKey<FormState>();
  final _adressFormKey = GlobalKey<FormState>();

  int id = 0;
  String email = "";
  String password = "";
  int cityId = 0;
  String buildingNumber = "";
  int streetId = 0;
  String name = "";

  void setEmail(String newEmail) {
    setState(() {
      email = newEmail;
    });
  }

  void setPassword(String newPassword) {
    setState(() {
      password = newPassword;
    });
  }

  void setCity(int newCity) {
    setState(() {
      cityId = newCity;
    });
  }

  void setBuildingNumber(String newBuildingNumber) {
    setState(() {
      buildingNumber = newBuildingNumber;
    });
  }

  void setStreet(int newStreet) {
    setState(() {
      streetId = newStreet;
    });
  }

  void setName(String newName) {
    setState(() {
      name = newName;
    });
  }


  continueStep() async {
    if (currentStep == 0) { // Assuming the name form is at step 0
      if (_nameFormKey.currentState!.validate()) {
        // If the form is valid, move to the next step
        try{
          id = await sendDonorCenterData(name);
          Config.donorCenterId = id;
          setState(() {
            currentStep++;
          });
        }catch(e){
          throw e;
        }
      }
    } else if(currentStep == 1){
      if (_adressFormKey.currentState!.validate()) {
        // If the form is valid, move to the next step
        try{
          await createAddress(id, cityId, streetId, buildingNumber);
          setState(() {
            currentStep++;
          });
        }catch(e){
          throw e;
        }
      }
    }
    else{
      if (_emailPasswordFormKey.currentState!.validate()) {
        // If the form is valid, move to the next step
        try{
          await createContact(id, email);
          setState(() {
            currentStep++;
          });
        }catch(e){
          throw e;
        }
      }
      // For other steps, just move to the next ste
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

          if (isLastStep && _emailPasswordFormKey.currentState!.validate()) {
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
              children:  [
                Text('Its time to set your name'),
                SizedBox(height: 20),
                NameFormWidget(formKey: _nameFormKey, onSavedName: (String name) {
                  this.name = name;
                }, ),
                SizedBox(height: 20),
              ],
            ),
            isActive: currentStep >= 0,
            state: currentStep >= 0 ? StepState.complete : StepState.disabled,
          ),

          Step(
            title: const Text('Address'),
            content: AddressForm(formKey: _adressFormKey, onBuildingNumberChanged: setBuildingNumber, onCityIdChanged: setCity, onStretIdChanged: setStreet,),
            isActive: currentStep >= 0,
            state: currentStep >= 1 ? StepState.complete : StepState.disabled,
          ),
          Step(
            title: const Text('Complete'),
            content: LoginNPasswordForm(formKey: _emailPasswordFormKey, onLoginChanged: setEmail, onPasswordChanged: setPassword,),
            isActive: currentStep >= 0,
            state: currentStep >= 2 ? StepState.complete : StepState.disabled,
          ),
        ],
      ),
    );
  }
}

import 'package:blood_flow/config/config.dart';
import 'package:blood_flow/superviser_client/components/sign_up_widgets/city_dropdown.dart';
import 'package:blood_flow/superviser_client/components/sign_up_widgets/street_dropdown.dart';
import 'package:flutter/material.dart';

class AddressForm extends StatefulWidget {
  final GlobalKey<FormState> formKey; // Pass the GlobalKey from the parent widget

  Function(int) onCityIdChanged;
  Function(int) onStretIdChanged;
  Function(String) onBuildingNumberChanged;

  AddressForm({Key? key, required this.formKey, required this.onBuildingNumberChanged, required this.onCityIdChanged, required this.onStretIdChanged}) : super(key: key);

  @override
  _AddressFormState createState() => _AddressFormState();
}

class _AddressFormState extends State<AddressForm> {
  int cityId = 0;
  int streetId = 0;
  String buildingNumber = "";


  TextEditingController _cityController = TextEditingController();
  TextEditingController _buildingController = TextEditingController();
  TextEditingController _streetController = TextEditingController();

  bool validateAndSave() {
    final form = widget.formKey.currentState;
    if (form!.validate()) {
      form!.save();
      return true;
    }
    return false;
  }

  @override
  void dispose() {
    _cityController.dispose();
    _buildingController.dispose();
    _streetController.dispose();
    super.dispose();
  }
  @override
  Widget build(BuildContext context) {

    final _streetDropDownList = GlobalKey<FormState>();

    void onCitySelected(int cityId){
      setState(() {
        this.cityId = cityId;
      });
      widget.onCityIdChanged(cityId);
    }

    void onStreetSelected(int streetId){
      widget.onStretIdChanged(streetId);
    }

    return Form(
      key: widget.formKey, // Use the GlobalKey passed from the parent widget
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          CityDropdown(url: Config.baseUrl+"/Cities", onCitySelected: onCitySelected),
          SizedBox(height: 16.0),
          StreetDropdown(key: _streetDropDownList,url: Config.baseUrl+"/Cities", onStreetSelected: onStreetSelected, cityId: cityId),
          SizedBox(height: 16.0),
          TextFormField(
            controller: _buildingController,
            decoration: InputDecoration(
              labelText: 'Building Number',
              border: OutlineInputBorder(),
            ),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Please enter the building number';
              }
              setState(() {
                widget.onBuildingNumberChanged(value);
                buildingNumber = value;
              });
              return null;
            },
          ),
          SizedBox(height: 16.0),
        ],
      ),
    );
  }
}

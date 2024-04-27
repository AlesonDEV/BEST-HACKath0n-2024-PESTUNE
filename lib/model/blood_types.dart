enum BloodTypes {
  O0,
  O1,
  A0,
  A1,
  B0,
  B1,
  AB0,
  AB1
}

extension BloodTypesExtension on BloodTypes {
  String toShortString() {
    return _stringFromBloodType(this);
  }
}

BloodTypes bloodTypeFromString(String value) {
  switch (value) {
    case 'O-':
      return BloodTypes.O0;
    case 'O+':
      return BloodTypes.O1;
    case 'A-':
      return BloodTypes.A0;
    case 'A+':
      return BloodTypes.A1;
    case 'B-':
      return BloodTypes.B0;
    case 'B+':
      return BloodTypes.B1;
    case 'AB-':
      return BloodTypes.AB0;
    case 'AB+':
      return BloodTypes.AB1;
    default:
      throw ArgumentError('Unknown blood type: $value');
  }
}

String _stringFromBloodType(BloodTypes bloodType) {
  switch(bloodType){
    case BloodTypes.A0:
      return "A-";
    case BloodTypes.O0:
      return "O-";
    case BloodTypes.O1:
      return "O+";
    case BloodTypes.A1:
      return "A+";
    case BloodTypes.B0:
      return "B-";
    case BloodTypes.B1:
      return "B+";
    case BloodTypes.AB0:
      return "AB-";
    case BloodTypes.AB1:
      return "AB+";
  }
}

enum BloodType {
  O0,
  O1,
  A0,
  A1,
  B0,
  B1,
  AB0,
  AB1
}

extension BloodTypesExtension on BloodType {
  String toShortString() {
    return _stringFromBloodType(this);
  }
}

BloodType bloodTypeFromString(String value) {
  switch (value) {
    case 'O-':
      return BloodType.O0;
    case 'O+':
      return BloodType.O1;
    case 'A-':
      return BloodType.A0;
    case 'A+':
      return BloodType.A1;
    case 'B-':
      return BloodType.B0;
    case 'B+':
      return BloodType.B1;
    case 'AB-':
      return BloodType.AB0;
    case 'AB+':
      return BloodType.AB1;
    default:
      throw ArgumentError('Unknown blood type: $value');
  }
}

String _stringFromBloodType(BloodType bloodType) {
  switch(bloodType){
    case BloodType.A0:
      return "A-";
    case BloodType.O0:
      return "O-";
    case BloodType.O1:
      return "O+";
    case BloodType.A1:
      return "A+";
    case BloodType.B0:
      return "B-";
    case BloodType.B1:
      return "B+";
    case BloodType.AB0:
      return "AB-";
    case BloodType.AB1:
      return "AB+";
  }
}

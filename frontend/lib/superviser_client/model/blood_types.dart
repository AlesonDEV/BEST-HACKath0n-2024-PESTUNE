enum BloodTypeOld {
  O0,
  O1,
  A0,
  A1,
  B0,
  B1,
  AB0,
  AB1
}

extension BloodTypesExtension on BloodTypeOld {
  String toShortString() {
    return _stringFromBloodType(this);
  }
}

BloodTypeOld bloodTypeFromString(String value) {
  switch (value) {
    case 'O-':
      return BloodTypeOld.O0;
    case 'O+':
      return BloodTypeOld.O1;
    case 'A-':
      return BloodTypeOld.A0;
    case 'A+':
      return BloodTypeOld.A1;
    case 'B-':
      return BloodTypeOld.B0;
    case 'B+':
      return BloodTypeOld.B1;
    case 'AB-':
      return BloodTypeOld.AB0;
    case 'AB+':
      return BloodTypeOld.AB1;
    default:
      throw ArgumentError('Unknown blood type: $value');
  }
}

String _stringFromBloodType(BloodTypeOld bloodType) {
  switch(bloodType){
    case BloodTypeOld.O0:
      return "O-";
    case BloodTypeOld.O1:
      return "O+";
    case BloodTypeOld.A0:
      return "A-";
    case BloodTypeOld.A1:
      return "A+";
    case BloodTypeOld.B0:
      return "B-";
    case BloodTypeOld.B1:
      return "B+";
    case BloodTypeOld.AB0:
      return "AB-";
    case BloodTypeOld.AB1:
      return "AB+";
  }
}

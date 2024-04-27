import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../model/Donor.dart';
import 'apply_donor_sesition.dart';

class DonorCard extends StatelessWidget {
  final Donor donor;
  DonorCard(this.donor);

  @override
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;

    return Container(
      decoration: BoxDecoration(
        color: Colors.grey[300], // Changed IdleIconColor to a placeholder color
        borderRadius: BorderRadius.circular(15),
      ),
      width: screenSize.width * 0.8,
      padding: EdgeInsets.all(10), // Added padding for better spacing
      child: Row(
        children: [
          Container(
            width: screenSize.width * 0.2,
            height: screenSize.height * 0.2,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              color: Colors.blue, // Placeholder color, replace with actual image
            ),
          ),
          SizedBox(width: 20), // Added spacing between profile image and details
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  '${donor.name} ${donor.surname}',
                  style: TextStyle(fontSize: 16, color: Colors.black), // Changed to fixed font size
                  textAlign: TextAlign.start,
                ),
                SizedBox(height: 5),
                Text(
                  '${donor.volume * 100} ml',
                  style: TextStyle(fontSize: 14, color: Colors.black), // Changed to fixed font size
                  textAlign: TextAlign.start,
                ),
              ],
            ),
          ),
          SizedBox(width: 10), // Added spacing between details and action buttons
          IconButton(
            onPressed: () {
              showDialog(
                context: context,
                builder: (BuildContext context) {
                  return AlertDialog(
                    title: Text('Apply donation'),
                    content: SingleChildScrollView(
                      child: ListBody(
                        children: <Widget>[ApplyDonorForm(
                          CloseForm: () {
                            // Implement the logic to close the form
                            Navigator.of(context).pop();
                          },
                          AddRequest: (double donation) {
                            // Implement the logic to handle the donation request
                            // For example, you might want to update the state or send the data to a server
                            Navigator.of(context).pop();
                          },
                        ),
                        ]
                      ),
                    ),
                  );
                },
              );
            },
            icon: Icon(Icons.list_alt, size: 32, color: Colors.black),
          ),
          // Added spacing between action buttons
          IconButton(
            onPressed: () {
              showDialog(
                context: context,
                builder: (BuildContext context) {
                  return AlertDialog(
                    title: Text('Confirm'),
                    content: Text('Are you sure you want to delete this?'),
                    actions: <Widget>[
                      TextButton(
                        onPressed: () {
                          Navigator.of(context).pop(); // Dismiss the dialog
                        },
                        child: Text('Cancel'),
                      ),
                      TextButton(
                        onPressed: () {
                          // TODO: Implement delete functionality
                          Navigator.of(context).pop(); // Dismiss the dialog after performing the action
                        },
                        child: Text('Delete'),
                      ),
                    ],
                  );
                },
              );
            },
            icon: Icon(Icons.delete_outline, size: 32, color: Colors.black),
          ),
          SizedBox(width: screenSize.width * 0.05),
        ],
      ),
    );
  }
}

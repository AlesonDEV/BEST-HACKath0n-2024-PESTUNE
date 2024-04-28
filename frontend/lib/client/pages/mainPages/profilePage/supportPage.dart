import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class SupportPage extends StatefulWidget {
  @override
  _SupportPageState createState() => _SupportPageState();
}

class _SupportPageState extends State {
  final List<Map<String, dynamic>> messages = [];
  final TextEditingController _controller = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Support'),
      ),
      body: Column(
        children: [
          Expanded(
            child: SingleChildScrollView(
              child: Column(
                children: List.generate(messages.length, (index) {
                  if (messages[index]['sender'] == 'user') {
                    return Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        Container(
                          constraints: BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.7),
                          decoration: BoxDecoration(
                            color: Colors.blue,
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          padding: EdgeInsets.all(8.0),
                          child: Text(
                            messages[index]['text'],
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                        SizedBox(width: 8.0),
                        Container(
                          margin: EdgeInsets.only(right: 8.0),
                          child: CircleAvatar(
                            child: Text(messages[index]['sender'][0]),
                          ),
                        ),
                      ],
                    );
                  } else {
                    return Row(
                      children: [
                        Container(
                          margin: EdgeInsets.only(left: 8.0),
                          child: CircleAvatar(
                            child: Text(messages[index]['sender'][0]),
                          ),
                        ),
                        SizedBox(width: 8.0),
                        Container(
                          constraints: BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.7),
                          margin: EdgeInsets.only(right: 8.0),
                          decoration: BoxDecoration(
                            color: Colors.grey[300],
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          padding: EdgeInsets.all(8.0),
                          child: Text(messages[index]['text']),
                        ),
                      ],
                    );
                  }
                }),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16.0),
            child: TextField(
              controller: _controller,
              decoration: InputDecoration(
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.all(
                    Radius.circular(30.0),
                  ),
                ),
                hintText: 'Type a message...',
                contentPadding: EdgeInsets.symmetric(horizontal: 16.0),
                suffixIcon: IconButton(
                  icon: Icon(Icons.send),
                  onPressed: () {
                    sendMessage('user', _controller.text);
                    _controller.clear();
                  },
                ),
              ),
              onSubmitted: (value) {
                sendMessage('user', value);
                _controller.clear();
              },
            ),
          ),
        ],
      ),
    );
  }

  void sendMessage(String sender, String text) {
    setState(() {
      messages.add({'sender': sender, 'text': text});
      messages.add({'sender': 'bot', 'text': 'Thank you for your message!'});
    });
  }
}

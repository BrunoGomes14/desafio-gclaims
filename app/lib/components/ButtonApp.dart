

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class ButtonApp extends StatelessWidget {

  final String text;
  final VoidCallback onTap;

  const ButtonApp(this.text, this.onTap);

  @override
  Widget build(BuildContext context) {
      return TextButton(
        style: ButtonStyle(
            backgroundColor: MaterialStateProperty.all<Color>(Colors.red),
          ),
        onPressed: onTap,
        child: Text(text,
          style: const TextStyle(color: Colors.white),
        ),
      );
  }
}
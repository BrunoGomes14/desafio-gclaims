import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class TextFieldApp extends StatelessWidget {
  final TextEditingController controller;
  final String hint;
  final AssetImage imgIcon;
  final TextInputAction action;
  final bool bHintLabel;
  final TextInputType keyBoardType;
  final int maxLenght;
  final bool allCaps;

  const TextFieldApp(
      {
      required this.controller,
      required this.hint,
      required this.imgIcon,
      this.action = TextInputAction.next,
      this.bHintLabel = true,
      this.keyBoardType = TextInputType.text,
      this.maxLenght = 100,
      this.allCaps = false});

  @override
  Widget build(BuildContext context) {
    return Container(
        margin: const EdgeInsets.only(top: 0.5),
        height: 60,
        child: Row(
          children: <Widget>[
            Flexible(
                child: TextField(
              controller: controller,
              keyboardType: keyBoardType,
              decoration: decoracao(context),
              textInputAction: action,
              style: const TextStyle(fontSize: 16),
              maxLength: maxLenght,
            )),
          ],
        ));
  }

  InputDecoration decoracao(context) {
    return InputDecoration(
      counterText: "",
      prefixIcon: Padding(
          padding: const EdgeInsets.only(top: 14, left: 4, right: 0, bottom: 14),
          child: SizedBox(height: 5, child: ImageIcon(imgIcon))),
      hintText: bHintLabel ? null : hint,
      labelText: bHintLabel ? hint : null,
    );
  }
}

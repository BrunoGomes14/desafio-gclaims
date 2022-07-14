import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class DropDownButtonApp extends StatelessWidget {
  final int value;
  final String hint;
  final String label;
  final Function(dynamic) onChanged;
  final List<DropdownMenuItem> items;

  const DropDownButtonApp(
      {this.value = -1,
      required this.onChanged,
      required this.items,
      this.hint = "",
      this.label = ""});

  @override
  Widget build(BuildContext context) {
    return Column(children: <Widget>[
      Container(
        padding: const EdgeInsets.only(top: 5, bottom: 5, left: 13, right: 13),
        child: Row(
          children: <Widget>[
            Expanded(
                child: Container(
              padding: EdgeInsets.only(
                  left: 15,
                  top: value == -1 ? 8 : 0,
                  bottom: value == -1 ? 8 : 0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  const SizedBox(height: 5),
                  Visibility(
                      visible: value != -1,
                      child: Text(label,
                          style: const TextStyle(
                              color: Colors.grey, fontSize: 13))),
                  Container(
                    height: 35,
                    child: DropdownButton(
                      hint: Text(
                        hint,
                        style:
                            const TextStyle(color: Colors.grey, fontSize: 15),
                      ),
                      isExpanded: true,
                      value: value == -1 ? null : value,
                      underline: const SizedBox(),
                      onChanged: onChanged,
                      items: items,
                    ),
                  ),
                ],
              ),
            )),
          ],
        ),
      ),
      Row(
        children: <Widget>[
          Expanded(child: Container(height: 0.5, color: Colors.grey))
        ],
      )
    ]);
  }
}

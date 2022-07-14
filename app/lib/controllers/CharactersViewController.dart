import 'dart:async';
import 'dart:convert';

import 'package:flutter/cupertino.dart';
import '../models/Character.dart';
import '../views/LoadView.dart';
import 'package:http/http.dart' as http;

class CharactersViewController {
  BuildContext context;
  Function setStateCallback;
  List<Character> listCharacter = [];
  int iSelecionado = -1;
  TextEditingController txtFiltro = TextEditingController();

  final Map<String, String> mapOrder = {
    "": "",
    "A-Z": "name",
    "Z-A": "-name",
  };

  final List<String> listOrder = ["", "A-Z", "Z-A"];

  CharactersViewController(this.context, this.setStateCallback);

  requestCharacter() async {

    try {

      String orderBy = iSelecionado >= 0 ? mapOrder[listOrder[iSelecionado]]! : "";
      String filter = txtFiltro.text;

      Map<String, String> map = {};

      if (orderBy.trim().isNotEmpty){
        map["orderBy"] = orderBy;
      }

      if (filter.trim().isNotEmpty){
        map["nameStartsWith"] = filter;
      }

      LoadViewState().showDialogBox(context);
      var response = await http.get(Uri.http("192.168.15.5:5294", "/Characters", map))
                               .timeout(const Duration(minutes: 1));
      LoadViewState().dimissDialog(context);

      listCharacter = [];

      if (response.statusCode == 200){
        final data = jsonDecode(response.body);

        for (Map<String, dynamic> i in data){
          listCharacter.add(Character.fromJson(i));
        }

        setStateCallback();
      }
      else {
        Navigator.pushNamed(context, "/erroView", arguments: requestCharacter);
      }
    }
    on TimeoutException catch (_) {
      LoadViewState().dimissDialog(context);
      Navigator.pushNamed(context, "/erroView", arguments: requestCharacter);
    }
    on Exception catch (_) {
      LoadViewState().dimissDialog(context);
      Navigator.pushNamed(context, "/erroView", arguments: requestCharacter);
    }
  }
}

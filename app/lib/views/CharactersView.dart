import 'package:app/components/ButtonApp.dart';
import 'package:app/controllers/CharactersViewController.dart';
import 'package:app/models/Character.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../components/DropDownButtonApp.dart';
import '../components/TextFieldApp.dart';

class CharactersView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => CharactersViewState();
}

class CharactersViewState extends State<CharactersView> {
  late CharactersViewController controller;

  @override
  void initState() {
    super.initState();

    imageCache.clear();
    controller = CharactersViewController(context, setStateCallback);

    Future.delayed(const Duration(seconds: 0), () {
      controller.requestCharacter();
    });
  }

  void setStateCallback() {
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;

    return Scaffold(
        resizeToAvoidBottomInset: true,
        body: SafeArea(
          left: false,
          top: true,
          right: false,
          bottom: false,
          child: Container(
              height: height,
              width: width,
              color: Colors.black,
              child: Column(children: <Widget>[
                filtroNome(),
                filtroOrdenacao(),
                grid(),
              ])),
        ));
  }

  Widget filtroNome() {
    return Container(
      padding: const EdgeInsets.all(15),
      child: Material(
        elevation: 5,
        borderRadius: BorderRadius.circular(6),
        child: TextFieldApp(
          controller: controller.txtFiltro,
          hint: "Buscar por nome...",
          imgIcon: const AssetImage("assets/images/imgIronMan.png"),
        ),
      ),
    );
  }

  Widget filtroOrdenacao() {
    return Row(
      children: <Widget>[
        Expanded(
          child: Container(
            padding: const EdgeInsets.all(15),
            child: Material(
              elevation: 5,
              borderRadius: BorderRadius.circular(6),
              child: DropDownButtonApp(
                value: controller.iSelecionado,
                hint: "Ordenar",
                label: "Ordenar",
                items: controller.listOrder.map<DropdownMenuItem>((v) => DropdownMenuItem(
                  value: controller.listOrder.indexOf(v),
                  child: Text(v),
                )).toList(),
                onChanged: (value) {
                  setState(() {
                    controller.iSelecionado = value;
                  });
                },
              ),
            ),
          ),
        ),
        Container(
            height: 60,
            width: 110,
            margin: const EdgeInsets.only(right: 13),
            child: ButtonApp("Buscar", () {

              if (controller.iSelecionado < 0 && controller.txtFiltro.text.isEmpty)
                return;

              controller.requestCharacter();
            }))
      ],
    );
  }

  Widget grid() {
    return Expanded(
      child: Container(
          padding: const EdgeInsets.only(left: 10, right: 10),
          child: GridView.count(
            crossAxisCount: 2,
            childAspectRatio: 0.60,
            children: List.generate(controller.listCharacter.length, (index) {
              return itemGrid(controller.listCharacter[index]);
            }),
          )),
    );
  }

  Widget itemGrid(Character character) {
    return Container(
      margin: const EdgeInsets.all(5),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: const BorderRadius.all(Radius.circular(12)),
        boxShadow: [
          BoxShadow(
            color: Colors.red.withOpacity(0.3),
            spreadRadius: 4,
            blurRadius: 5,
            offset: const Offset(0, 3), // changes position of shadow
          ),
        ],
      ),
      child: Column(children: <Widget>[
        Row(
          children: <Widget>[
            Expanded(
                child: ClipRRect(
                    borderRadius: const BorderRadius.only(
                        topLeft: Radius.circular(12),
                        topRight: Radius.circular(12)),
                    child: Image.network(
                      character.thumbnail!.Url(),
                      height: 150,
                      fit: BoxFit.fill,
                    ))),
          ],
        ),
        Container(
          padding: EdgeInsets.all(6),
          child: Row(
            children: <Widget>[
              Flexible(
                child: Text(
                  character.name!,
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 20,
                  ),
                  maxLines: 2,
                  overflow: TextOverflow.ellipsis,
                  textAlign: TextAlign.center,
                ),
              )
            ],
          ),
        ),
        const SizedBox(height: 8),
        Container(
            padding: const EdgeInsets.only(left: 6, right: 6),
            child: Row(
              children: <Widget>[
                Flexible(
                  child: Text(
                    character.description!,
                    style: const TextStyle(
                      fontSize: 15,
                    ),
                    maxLines: 5,
                    overflow: TextOverflow.ellipsis,
                    textAlign: TextAlign.left,
                  ),
                ),
              ],
            )
        ),
      ]), //your widget here
    );
  }
}

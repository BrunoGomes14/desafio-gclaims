

import 'package:app/components/ButtonApp.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class ErroView extends StatefulWidget{
  @override
  State<StatefulWidget> createState() => ErroViewState();
}

class ErroViewState extends State<ErroView>{

  @override
  Widget build(BuildContext context) {

    Function funcTentarNovamente = ModalRoute.of(context)!.settings.arguments as Function;

    return Scaffold(
      body: WillPopScope(
        onWillPop: () async {
          return false;
        },
        child: Container(
          width: MediaQuery.of(context).size.width,
          child:  Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              Image.asset("assets/images/img_astronauta.png",
                width: 250,
                height: 250,
              ),

              const Text(
                "Ooops!",
                style: TextStyle(
                    color: Colors.indigo,
                    fontSize: 30
                ),
              ),

              const SizedBox(
                height: 13,
              ),

              const Text(
                "Sem conexão\nVerifique sua internet.",
                textAlign: TextAlign.center,
                style: TextStyle(
                    color: Colors.indigo,
                    fontSize: 20
                ),
              ),

              Container(
                  margin: new EdgeInsets.only(top: 25),
                  width: 250,
                  height: 48,
                  child: ButtonApp( "Tentar novamente", () {
                      Navigator.pop(context);
                      funcTentarNovamente();
                    },
                  )),
            ],
          ),
        ),
      ),
    );
  }
}
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

class LoadView extends StatefulWidget {
  @override
  LoadViewState createState() => LoadViewState();
}

class LoadStatus{
  static List<int> list = [];
}

class LoadViewState extends State<LoadView> {
  bool _bFecha = false;

  void showDialogBox(BuildContext context) {

    LoadStatus.list.add(1);

    // flutter defined function
    showDialog(
      barrierDismissible: false,
      context: context,
      builder: (BuildContext context) {
        // return object of type Dialog
        return WillPopScope(
            onWillPop: () async => _bFecha,
            child: Container(
                color: Colors.black12,
                width: MediaQuery.of(context).size.width,
                height: MediaQuery.of(context).size.height,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: <Widget>[
                    Image.asset("assets/images/load_principal.gif", height: 95, width: 95,)
                  ],
                )
            )
        );
      },
    );
  }

  void dimissDialog(BuildContext context){

    if (LoadStatus.list.isNotEmpty){
      _bFecha = true;
      LoadStatus.list.removeAt(0);
      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container();
  }
}

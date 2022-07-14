import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';


class SplashView extends StatefulWidget{
  @override
  State<StatefulWidget> createState() => SplashViewState();
}

class SplashViewState extends State<SplashView> {

  @override
  void initState() {
    Future.delayed(Duration(seconds: 5), () async {
      Navigator.popAndPushNamed(context, "/characters");
    });
  }

  @override
  Widget build(BuildContext context) {

    return Container(
      height: MediaQuery.of(context).size.height,
      width:  MediaQuery.of(context).size.height,
      color: Colors.black,
      padding: const EdgeInsets.all(30),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: <Widget>[
          Image.asset("assets/images/imgMarvel.png",
            width: 200,
            height: 200,
          )
        ],
      ),
    );
  }

}

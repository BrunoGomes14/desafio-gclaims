import 'package:app/views/CharacterDetailView.dart';
import 'package:flutter/material.dart';
import 'views/SplashView.dart';
import 'views/CharactersView.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Marvel Characters',
      routes: {
        '/splash_view': (context) => SplashView(),
        '/characters': (context) => CharactersView(),
        '/characterDetail': (context) => CharacterDetailView(),
        '/erroView': (context) => CharacterDetailView(),
      },
      initialRoute: '/splash_view',
    );
  }
}
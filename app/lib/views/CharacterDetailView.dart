import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class CharacterDetailView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => CharacterDetailViewState();
}

class CharacterDetailViewState extends State<CharacterDetailView> {
  static int iSelecionado = -1;

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;

    return Scaffold(
      resizeToAvoidBottomInset: true,
      appBar: appBar(false),
      body: SingleChildScrollView(
        child: Container(
            height: height,
            width: width,
            color: Colors.black,
            padding: EdgeInsets.only(top: 30, left: 15, right: 15),
            child: Column(children: <Widget>[
              _cabecalho(),
              const SizedBox(height: 30),
              _resumo(),
              const SizedBox(height: 30),
              _subtitulo(),
              _historias()
            ])),
      ),
    );
  }

  Widget _cabecalho() {
    return Row(
      children: <Widget>[
        ClipRRect(
            borderRadius: BorderRadius.circular(150),
            child: Image.network(
              "http://i.annihil.us/u/prod/marvel/i/mg/c/e0/535fecbbb9784.jpg",
              height: 150,
              width: 150,
              fit: BoxFit.fill,
            )),
        const SizedBox(width: 15),
        const Flexible(
            child: Text(
          "Personagem abobinha",
          style: TextStyle(
              color: Colors.white, fontWeight: FontWeight.bold, fontSize: 25),
          maxLines: 3,
          overflow: TextOverflow.ellipsis,
        ))
      ],
    );
  }

  Widget _resumo() {
    return Row(
      children: <Widget>[
        Expanded(
            child: Container(
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
              ]),
          padding: const EdgeInsets.all(30),
          child: Column(children: const <Widget>[
            Text(
              "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
              style: TextStyle(fontSize: 15),
            )
          ]), //your widget here
        )),
      ],
    );
  }

  Widget _subtitulo() {
    return Row(
      children: <Widget>[
        Text(
          "Aparece em:",
          style: TextStyle(
              color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18),
        )
      ],
    );
  }

  Widget _historias() {
    return Row(
      children: <Widget>[
        Expanded(
            child: Container(
          height: 200,
          child: ListView(
            shrinkWrap: true,
            scrollDirection: Axis.horizontal,
            children: List.generate(
              10,
              (i) => Container(
                width: 118,
                margin: EdgeInsets.all(10),
                color: Colors.white,
                alignment: Alignment.center,
                child: Image.network(
                  "http://i.annihil.us/u/prod/marvel/i/mg/2/00/5ba3bfcc55f5a.jpg",
                  fit: BoxFit.fill,
                ),
              ),
            ),
          ),
        ))
      ],
    );
  }

  AppBar appBar(bool bFavorito) {
    return AppBar(
      backgroundColor: Colors.black,
      title: const Text('Voltar'),
      leading: IconButton(
        icon: Icon(Icons.arrow_back),
        onPressed: () {},
      ),
      actions: <Widget>[
        IconButton(
          icon: Image.asset(bFavorito
              ? 'assets/images/star.png'
              : 'assets/images/outline_star.png'),
          onPressed: () => {},
        ),
        IconButton(
          icon: Image.asset('assets/images/delete.png'),
          onPressed: () => {},
        ),
      ],
    );
  }
}

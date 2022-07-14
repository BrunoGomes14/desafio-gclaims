
class Character {
  int? id;
  String? name;
  String? description;
  String? modified;
  Thumbnail? thumbnail;
  bool? favorite;
  List<Thumbnail>? thumbnailComics;

  Character(
      {this.id,
        this.name,
        this.description,
        this.modified,
        this.thumbnail,
        this.favorite,
        this.thumbnailComics});

  Character.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    name = json['name'];
    description = json['description'];
    modified = json['modified'];
    thumbnail = json['thumbnail'] != null
        ? Thumbnail.fromJson(json['thumbnail'])
        : null;
    favorite = json['favorite'];
    if (json['thumbnailComics'] != null) {
      thumbnailComics = <Thumbnail>[];
      json['thumbnailComics'].forEach((v) {
        thumbnailComics!.add(Thumbnail.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['name'] = name;
    data['description'] = description;
    data['modified'] = modified;
    if (thumbnail != null) {
      data['thumbnail'] = thumbnail!.toJson();
    }
    data['favorite'] = favorite;
    if (thumbnailComics != null) {
      data['thumbnailComics'] =
          thumbnailComics!.map((v) => v.toJson()).toList();
    }
    return data;
  }
}

class Thumbnail {
  String? path;
  String? extension;

  Thumbnail({this.path, this.extension});

  Thumbnail.fromJson(Map<String, dynamic> json) {
    path = json['path'];
    extension = json['extension'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['path'] = path;
    data['extension'] = extension;
    return data;
  }

  String Url() {
    return "${path!}.${extension!}";
  }
}

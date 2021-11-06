import 'package:advisories_lawyer/models/documents.dart';
import 'package:advisories_lawyer/service/document_service.dart';
import 'package:flutter/cupertino.dart';

class DocListViewModel extends ChangeNotifier {
  // ignore: deprecated_member_use
  List<DocViewModel> documents = <DocViewModel>[];

  Future<void> fetchDoc(int cateID) async {
    final results = await Docservice().fetchDoc(cateID);
    this.documents =
        results.map((item) => DocViewModel(documents: item)).toList();
    notifyListeners();
  }
}

class DocViewModel {
  final Doc documents;

  DocViewModel({required this.documents});

  int get id {
    return this.documents.id;
  }

  String get name {
    return this.documents.name;
  }

  String get descriptioln {
    return this.documents.description;
  }

  int get categoryID {
    return this.documents.category_id;
  }
}

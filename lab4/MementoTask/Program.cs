using MementoTask;

var editor = new TextEditor();

editor.Write("Hello ");
editor.Write("dear!");
editor.Write(", world!");
editor.Show();

editor.ShowHistory();


editor.Undo();
editor.Show();

editor.Undo();
editor.Show();

editor.Redo();
editor.Show();



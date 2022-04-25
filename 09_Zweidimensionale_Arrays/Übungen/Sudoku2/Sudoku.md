c# Programmieren (c) HTL-Leonding

# Sudoku

## Lehrziele

* Methoden
* UnitTest
* mehrdimensionale Arrays

## Aufgabenstellung

Das Logikrätsel **Sudou** (siehe https://de.wikipedia.org/wiki/Sudoku) ist in den vergangenen Jahren sehr populär geworden. In fast jeder Zeitung ist eine Rätsel enthalten.  
In dieser Aufgabe sollen Methoden geschrieben werden, die beim Lösen eines Sudokus helfen können.

### Methoden

* `void PrintSudoku(int[,] sudoku, bool showHelp)`  
 Das Sudoku wird am Bildschirm ausgegeben. Versuchen Sie eine ansprechende Form zu finden.
 Mit dem Parameter **showHelp** wird gesteuert, ob die noch möglichen Zahlen der Zelle gedruckt werden sollen.  
* `bool IsSudokuComplete(int[,] sudoku)`  
Die Mehtode Überprüft, ob in allen Zellen des Sudokus ein Wert enthalten ist. 
* `bool SetField(int[,] sudoku, int row, int col, int no)`  
Nur über diese Methode kann/darf ein Wert des Sudokus gesetzt werden. Ist das Setzen des Wertes nicht möglich liefert die Mehtode den Rückgabewert **false**.
Mit dem Wert 0 für **no** kann auch ein Wert wieder gelöscht werden. 
* `int[,][] GetPossibleNumbers(int[,] sudoku)`  
Für jede leere Zelle des Sudokus wird berechnet, welche Werte (1-9) noch möglich sind. Die Werte ergeben sich aus den bereits enthaltenen Zahlen der Reihe, Spalte und Segment. 

In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.

### Hauptprogramm

Das Hauptprogramm unterstützt die Eingabe eines Sudokus. Der Benutzer kann die Zelle (Eingabe von Zeile und Spalte) auswählen, in der er einen Wert (0-9, 0 für löschen) schreiben will. Das Programm verhindert dabei falsche Eingaben.

Nach jeder Eingabe wird das Sudoku auf dem Bildschirm ausgedruckt.
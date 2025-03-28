c# Programmieren (c) HTL-Leonding

# Matrix-Add

## Lehrziele

* 2D-Arrays
* Vertiefung Methoden

## Aufgabenstellung

Gesucht sind folgende Methoden:
* Addition von zwei Matrizen.  
  Bei der Addition von zwei Matrizen muss die Zeilenanzahl und die Spaltenanzahl übereinstimmen, man kann also nur Matrizen addieren, die in beiden Dimensionen gleich sind. Geben Sie den Wert `null`
  zurück, wenn die Dimensionen nicht passen.  
  Bei der Addition wird jede Zelle der einen Matrix mit der Zelle (an der gleichen Position) der zweiten Matrix addiert und in das Ergebnis (wieder an der gleichen Position) geschrieben.  
  Es gilt für alle Zellen:  
  `result[row,col] = matrixA[row,col] + matrixB[row,col]`  
  Implementieren Sie eine Methode die zwei Matrizen (=zweidimensionale Arrays) als Parameter bekommt und eine neu Matrize als Ergebnis zurückgibt.  

* Distinct (eindeutige Werte).  
  Die gesuchte Methode bestimmt alle unterschiedlichen Werte der Matrize und gibt diese als Array (eindimensional) aus.  
  `int[] Distinct(int[,] matrix)`  

* Ausgabe einer Matrize.  
  Schreiben Sie eine Methode zur Ausgabe einer Matrize. Die Matrize wird auf der Konsole sauber formatiert ausgegeben.  
  Hinweis: Alle Werte müssen mit der gleichen Feldbreite ausgegeben werden.  

### Programmablauf

Schreiben sie ein Hauptprogramm (=Testprogramm), dass alle oben angeführte Methoden verwendet. Zeigen Sie damit, dass die Implementierung der Matrix-Operationen korrekt ist.

### Unittests
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.

### Bildschirmausgabe

Die Bildschirmausgabe des Hauptprogramms (=Testprogramms) könnte wie folgt aussehen:

```
 1  2  3
 4  5  6
 7  8 99
*
11 12 13
24 25 26
37 38 39
=
 12  14  16
 28  30  32
 44  46 138

Distinct numbers: 12,14,16,28,30,32,44,46,138

```
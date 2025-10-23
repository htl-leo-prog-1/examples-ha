c# Programmieren (c) HTL-Leonding

# Matrix-Operationen

## Lehrziele

* 2D-Arrays
* Vertiefung Methoden

## Aufgabenstellung

In der Mathematik werden 2 dimensionale Matrizen (oft) benötigt. Schreiben Sie zur Unterstützung von mathematischen Berechnungen Methoden, mit denen Matrizen berechnet werden können:
* Multiplikation von zwei Matrizen.  
  Die Berechnungsvorschrift können sie in Wikipedia unter der Adresse https://de.wikipedia.org/wiki/Matrizenmultiplikation nachlesen.  
  Die Methode muss fehlerhafte Parameter überprüfen. Z.B. ist eine Multiplikation nur möglich, wenn die Dimensionen der beiden Argumente korrekt sind.  
  `int[,] Multiply(int[,] matrixA, int[,] matrixB)`
* Drehen einer Matrix im Uhrzeigersinn.  
  Die gesuchte Methode soll eine existierende Matrize im Uhrzeigersinn drehen und als Ergebnis zurückgeben.  
  `int[,] RotateClockwise(int[,] matrix)`  
  Hinweis: aus einer m:n Matrix wird eine n:m 
* Drehen einer Matrix gegen den Uhrzeigersinn.  
  `int[,] RotateCounterclockwise(int[,] matrix)`  
* Spiegeln einer Matrize um die horizontale Achse.  
  `int[,] MirrorHorizontal(int[,] matrix)`  
* Spiegeln einer Matrize um die vertikale Achse.  
  `int[,] MirrorVertical(int[,] matrix)`  
* Unterstützung für den Ausdrucken der Matrix.
  `string[] ToString(int[,] matrix)`
  Liefert ein String-Array von allen Zeilen (row). Jeder String (row) enthält die Spalten, die durch Leerzeichen getrennt sind. Die Feldbreite errechnet sich aus dem Maximum- (oder Minimum-) Wert aller Matrikelemente:
  Beispiel (die Punkte sind Leerzeichen):

     erg[0] = `"...1....2.1000"`  
     erg[1] = `"...3....4....5"`
 * Ausgeben einer Matrix auf der Konsole.  
  `void Print(int[,] matrix)`  
  Formatiert wird wie in der Methode ToStrings. 
  
    

### Programmablauf

Schreiben sie ein Hauptprogramm (=Testprogramm), dass alle oben angeführte Methoden verwendet. Zeigen Sie damit, dass die Implementierung der Matrix-Operationen korrekt ist.


### Unittests
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.

### Bildschirmausgabe

Die Bildschirmausgabe des Hauptprogramms (=Testprogramms) könnte wie folgt aussehen:

```
3 6 7
5 3 5
6 2 9
*
1 2 7
0 9 3
6 0 6
=
 45  60  81
 35  37  74
 60  30 102

 1  2  3  4
 5  6  7  8
 9 10 11 12
rotate clockwise
 9  5  1
10  6  2
11  7  3
12  8  4
rotate counterclockwise
 1  2  3  4
 5  6  7  8
 9 10 11 12
mirror horizontal
 9 10 11 12
 5  6  7  8
 1  2  3  4
mirror vertical
12 11 10  9
 8  7  6  5
 4  3  2  1
```
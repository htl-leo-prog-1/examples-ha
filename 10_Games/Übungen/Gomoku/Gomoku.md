c# Programmieren (c) HTL-Leonding

# Gomoku

## Lehrziele

* mehrdimensionale Arrays
* Board

## Aufgabenstellung

**Gomoku** ist ein Spiel für zwei Spieler, dass in verschiedenen Ländern unter verschiedenen Namen gespielt wird. In China z.B. **Wuziqi**, in Korea **Omok**, in Europa  **Fünf in einer Reihe** und international **Gomoku**. Auf einen 15x15, 17x17 oder 19x19 dürfen die beiden Spieler abwechselnd Steine an eine beliebige, leere Spielfeldposition setzen. Gewinner ist derjenige, der als ersters fünf Steine in einer Reihe, Spalte oder Diagonale hat.  

### Programmablauf
Schreiben Sie ein Programm mit dem **Gomoku** gespielt werden kann.  
* Beim Programmstart wird die Dimension des Spielfelds eingegeben. 
  Da es sich um ein quadratisches Spielfeld handelt, muss nur eine Dimension eingegeben werden, z.B.: `17`.  
  Erlaubte Größen sind 15x15, 17x17 oder 19x19.
* Anschließend wird das **Board** mit den eingegebenen Dimensionen erstellt.
* Zwei Benutzer können abwechselnd eine Position (Zeile/Spalte) eingeben, in die der nächste Stein plaziert werden soll.  
  Beispiel für die Eingabe `3,7`  
* Das Spiel ist beendet, wenn ein Spieler gewonnen hat **oder** kein Stein mehr eingeworfen werden kann (das Spielfeld ist voll => unentschieden).
* Ein Spieler kann **aufgeben**.  
  Mit der Eingabe eine Rufzeichens hat der andere Spieler gewonnen und das Programm wird beendet.
* Bei einer fehlerhaften Eingabe muss diese wiederholt werden: z.B. einer falsche Spielfeldgröße, bei einer ungültigen Zeile/Spalte, bei einem bereits besetztem Feld, ... 

### Programmdesign

Achten Sie bei der Umsetzung auf ein sauberes Design Ihres Programms.  
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.  
Damit die Unittests ausgeführt werden können müssen sie folgende (Hilfs-)Methoden umsetzen:

* `int IsWinner(int[,] field, int row, int col)`  
Überprüft, ob sich durch die Belegung eines Feldes ein Sieger ergeben hat. Dabei werden nicht alle Felder überprüfen, sondern nur die an die neu gesetzte Position angrenzenden.  
Rückgabe: 0 falls kein Gewinner, sonst 1/2

Testen Sie das Programm ausführlich. 

Verwenden Sie im Programm (für das Feld **field**) folgende Codierung: -1 = frei, 0 = Spieler 1 (rotes <span style="color:red">X</span>), 1 = Spieler 2 (grünes <span style="color:green">O</span>)

### Bildschirmausgabe

```
Connect Four
============
Zeilen   [2..10]: 6
Spalten  [2..10]: 7
Spieler 1, Spalte  [0..6]: 0
Spieler 2, Spalte  [0..6]: 3
Spieler 1, Spalte  [0..6]: 0
Spieler 2, Spalte  [0..6]: 2
Spieler 1, Spalte  [0..6]: 0
Spieler 2, Spalte  [0..6]: 4
Spieler 1, Spalte  [0..6]: 6
Spieler 2, Spalte  [0..6]: 5
Gewinner ist Spieler 2!
```

![](images/screen1.png)
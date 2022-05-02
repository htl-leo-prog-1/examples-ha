c# Programmieren (c) HTL-Leonding

# Mine Sweeper

## Lehrziele

* mehrdimensionale Arrays
* Board
* Schrittweise Verfeinerung
* Rekursion

## Aufgabenstellung

Der **MineSweeper** ist ein beliebtest Computerspiel. Es war bis zur Version von Windows 7 auf allen Microsoft Betriebssysetmen installiert (siehe https://de.wikipedia.org/wiki/Minesweeper).
Ziel des Spieles ist es, auf einen virtuellen Minenfeld alle Minen zu markieren ohnen sie auszulösen. Dabei werden vom Spieler Felder aufgedeckt. Der Computer prüft, ob es sich um eine Mine handelt (in diesem Fall ist das Spiel beendet) oder wieviele Minen in den angrenzenden Feldern vorhanden sind. Diese Anzahl wird dann in dem aufgedeckten Feld angezweigt. Der Spieler kann auch ein Feld als Mine markieren. Hat er die richtige Anzahl von Minen markiert und diese sind auch an der richtigen Position, ist das Spiel erfolgreich beendet.

### Programmablauf
Schreiben Sie ein Programm mit dem **MineSweeper** gespielt werden kann.  
* Beim Programmstart wird die Dimension des quadratischen Spielfelds eingegeben. 
  Unterstützen sie Größen von 2 bis 20 Reihen und Spalten.
* Der Benutzer muss angeben, wieviele Minen versteckt werden sollen.  
  Es soll mindestens eine und maximal "Speielfeldgröße" Minen versteckt werden.  
* Anschließend wird das **Board** mit den eingegebenen Dimensionen und den zufällig versteckten Minen erstellt.  
Alle Felder sind nicht sichtbar - Im Board werden sie mit dem UniCodezeichen "\u2593" initialisiert.
* Der Benutzer gibt anschließend Kommandos ein. Die Eingabe wird solange wiederholt bis das Spiel beendet ist.
* Nachdem alle Minen gefunden wurden oder der Benutzer ein Feld mit einer Mine aufgedeckt hat, wird eine  Übericht des Minenfeldes angezeigt.

### Benutzer Eingaben

* Aufdecken eines Feldes
* Markieren eines Feldes als Mine
* Alle Minen sind markiert und das Spiel soll beedndet werden.

#### Aufdecken eines Feldes

#### Feld als Mine markieren
Ein Feld, egal welchen Status es zuvor hatte, wird als Mine markiert. Das Programm schreibt z.b. das Zeichen "\u25B6" in das Board an die entsprechende Stelle.

### Spielende

### Programmdesign

Achten Sie bei der Umsetzung auf ein sauberes Design Ihres Programms.  
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.  
Damit die Unittests ausgeführt werden können müssen sie folgende (Hilfs-)Methoden umsetzen:

* `int CountMinesAround(bool[,] mineField, int row, int col)`  
Die Mehtode berechnet an der gegebenen Reihe (row) und Spalte(col) die umgebenen Minen.
* `int CountMinesOnBoard(bool[,] mineField)`  
Die Anzahl der am Minenfeld verstechte Minen wird gezählt.

Testen Sie das Programm ausführlich. 

### Bildschirmausgabe

```
MineSweeper
===========
Size of (squared) board  [2..20]: 10
Count of mines  [1..100]: 10
Clear field with e.g.: 4,4
Set as mine with e.g.: *3,4
End game with !
=>4,4
=>7,4
=>*9,4
=>*9,5
=>!
Press enter to continue
```

![AGame](images/Screenshot1.png)

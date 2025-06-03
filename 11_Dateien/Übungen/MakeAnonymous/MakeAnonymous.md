c# Programmieren (c) HTL-Leonding

# Fussballmeisterschaft - Make Anonymous 

## Lehrziele

* Programmargumente
* Dateien - Lesen/Schreiben/Umbenennen
* Modularer Aufbau

## Aufgabenstellung

Das gesuchte Programm **MakeAnonymous** soll in einer Csv Datei (sie enthält die Spiele einer Fussball-Meisterschaft) die Teams (die Namen der Teams) anonymisieren. Dabei wird die gesamte Datei gelesen, im Speicher verändert und dann wieder geschrieben. Der Dateiname wird als erstes Argument optional übergeben.

### Programmablauf

Das Programm soll die folgenden Funktionalitäten aufweisen.

* Beim Programmstart wird geprüft, ob die richtige Anzahl von Argumente übergeben wurden.
* Das erste Argument (wenn angegeben) muss ein gültiger Dateiname **mit** der Erweiterung CSV sein.
  Bitte beachten Sie, die Datei muss auch existieren.  
* Das Programm liest anschließend alle Spiele aus der CSV Datei in eine interne Liste (=Array).
* Alle in den Spielen vorkommenden Teams werden anonymisiert.  
  Es wird z.B. aus "SV Horn" der neue Name "Team 1".  
* Geben sie *nach* der Anonymisierung eine Tabelle aus, wie die Teams verändert wurden:  

```
SV Horn                                  => Team 1
Union LUV Graz                           => Team 2
Wildcats 11teamsports Krottendorf        => Team 3
Sportunion Raiffeisen Geretsberg         => Team 4
FC Mohren Dornbirn Damen                 => Team 5
Carinthians LIWOdruck Hornets            => Team 6
RW Rankweil                              => Team 7
SV Fenastra Krenglbach                   => Team 8
USC Landhaus                             => Team 9
SC Neusiedl am See 1919                  => Team 10
FC Altera Porta                          => Team 11
SPG UNION Kleinmünchen/FC Blau-Weiß Linz => Team 12
Wiener Sport-Club                        => Team 13
```

* Die Spiele (das interne Array) werden in eine neue Datei gespeichert:

  * Zuerst wird eine Datei mit dem Originalnamen und der Erweiterung *$$$* erstellt.  
  * Die Originaldatei wird in *bak* umbenannt.  
    Eine eventuell vorhandene *bak* Datei wird zuvor gelöscht.  
  * Als letzter Schritt wird die *$$$* in *csv* verschoben.  

### Programmdesign

* Das Programm muss Modular aufgebaut sein.  
  Für jede Funktionalität ist eine Methode zu erstellen!  
* Bei einem Fehler (falsche Argumente) ist der Exit-Code der Main Methode zu verwenden.  

### Unittests
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.

### Bildschirmausgabe
Die Steuerung des Programms erfolgt über die Programm-Argumente. Eine Eingabe mit `Console.ReadLine()` wird daher **nicht** benötigt. Fehlermeldungen (z.B. falscher Dateiname) werden auf der Konsole ausgegeben.
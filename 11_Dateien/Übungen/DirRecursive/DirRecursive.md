c# Programmieren (c) HTL-Leonding

# Auflistung Dateien

## Lehrziele

* Programmargumente
* Dateisystem - Lesen der Inhaltsverzeichnisse

## Aufgabenstellung

Das gesuchte Programm **UpdateProductCsv** soll in einer Csv Datei (diese enthält Artikel mit je einem Verkaufspreis) Änderungen vornehmen können. Dabei wird die gesamte Datei gelesen, im Speicher verändert und dann wieder geschrieben. Der Dateiname wird als erstes Argument übergeben. Das zweite Argument wird als Prozentsatz interpretiert, mit dem die Verkaufspreise angepasst werden sollen.

### Programmablauf


### Programmdesign
* Achten Sie auf die richtigen Datentypen. Eine Währung (eine Zahl mit 2 Nachkommastellen) sollte als `decimal` gespeichert werden.
* In der CSV Datei ist der Verkaufspreis mit eimem Punkt als Dezimaltrennzeichen gespeichert. 

### Unittests
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.

### Bildschirmausgabe
Die Steuereung des Programms erfolgt über die Programm-Argumente. Eine Eingabe mit `Console.ReadLine()` wird daher **nicht** benötigt. Fehlermeldungen (z.B. falscher Dateiname) werden auf der Konsole ausgegeben.
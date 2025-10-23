c# Programmieren (c) HTL-Leonding

# GradeSummary-CSV

## Lehrziele

* Programmargumente
* Dateien - Lesen/Schreiben/Umbenennen
* Csv (Split, Join)
* Jagged Arrays
* Lokalisierung: Dezimalpunkt als Punkt und nicht als Komma.

## Aufgabenstellung

Das gesuchte Programm **GradeSummary** soll in einer Csv Datei (diese enthält Noten von Schülern) Änderungen vornehmen können. Dabei wird die gesamte Datei gelesen, im Speicher verändert und dann wieder geschrieben.

### Programmablauf

Das Programm soll die folgenden Funktionalitäten aufweisen:

* Beim Programmstart wird geprüft, ob als Parameter ein Dateiname angegeben wurde.
  Wird kein Parameter angegeben, wird als Dateiname der Wert **Pupils.csv** angenommen.  
* Der Dateiname muss mit der Erweiterung **CSV** angegeben sein.  
* Die Datei muss vorhanden sein.  
* Werden ungültige Parameter angegeben (zu viel, keine gültige Datei, keine CSV), wird das Programm nach einer entsprechenden Fehlermeldung mit einem ExitCode von 1 beendet.
* Das Programm liest anschließend alle Daten der CSV Datei in eine interne Liste (=Jagged-Array).
* In den Zeilen wird eine weitere Spalte aufgenommen. Diese enthält den Durchschnittswert aller in der Datei angegebenen Noten eines Schülers (Zeile).
* Die im vorherigen Punkt geänderte Liste wird in eine neue Datei gespeichert:

    * Zuerst wird eine Datei mit dem Originalnamen und der Erweiterung *$$$* erstellt.  
    * Die Originaldatei wird in *bak* umbenannt.  
      Eine eventuell vorhandene *bak* Datei wird zuvor gelöscht.  
    * Als letzter Schritt wird die *$$$* in *csv* verschoben.  

* ACHTUNG: Wenn die CSV Datei bereits eine Durchschnittsnote enthält, wird **keine** Änderung durchgeführt.

### Csv Datei

Die Csv Datei hat folgende Spalten:

```
LastName;FirstName;GradeGerman;GradeEnglish;GradeMath
Bennet;Marie;4;2;2
Bosse;Johannes;3;1;1
Bruno;Ben;4;1;3
```

* Die erste Zeile enthält die Überschriften der Spalten.  
* In den ersten beiden Spalten ist der Name des Schülers gespeichert (Vorname, Nachname).  
* Die weiteren Spalten enthalten die Noten der einzelnen Fächer.  Bitte beachten Sie, dass die Anzahl der Fächer (die Anzahl der Spalten) variieren kann.  
* Die Noten sind im Wertebereich [1..5] (Ganzzahl).

Nach einer erfolgreichen Ausführung des Programms hat die neue Csv Datei folgenden Inhalt:

```
LastName;FirstName;GradeGerman;GradeEnglish;GradeMath;Average
Bennet;Marie;4;2;2;2.67
Bosse;Johannes;3;1;1;1.67
Bruno;Ben;4;1;3;2.67
```

* Die Überschriftszeile enthält eine neue Spaltenbezeichnung: **Average**  
* Jeder Zeile (jeder Schüler) hat eine weitere Spalte. Diese enthält auf zwei Stellen gerundet (InvariantCulture) den Durchschnittswert der Noten aller Fächer.
* Bitte beachten Sie. Die Anzahl der Fächer ist variable.

### Unittests
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.

### Bildschirmausgabe
Die Steuerung des Programms erfolgt über die Programm-Argumente. Eine Eingabe mit `Console.ReadLine()` wird daher **nicht** benötigt. Fehlermeldungen (z.B. falscher Dateiname) werden auf der Konsole ausgegeben.  
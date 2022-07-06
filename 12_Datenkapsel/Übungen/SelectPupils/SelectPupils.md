c# Programmieren (c) HTL-Leonding

# Schülerauswahl

## Lehrziele

* Datenkapsel
* Csv Datei Lesen/Schreiben
* Wiederholung: Array
* Wiederholung: Sortieren
* Programm Kommandozeilen-Argumente.

## Aufgabenstellung

Die Aufnahme von Schülern an einer Schule soll unterstützt werden. Da es mehrere Kandidaten als Plätze gibt, muss eine Auswahl getroffen werden. Die Auswahl erfolgt nach einem Notenschnitt.  
Gesucht ist ein Programm, dass die in einer Csv Datei gespeicherten Kandidaten liest, für jeden Kandidaten den Notenschnitt berechnet und aufgrund dieses Notenschnittes die Kandidaten sortiert.  
Die sortierte Liste ist auszugeben und in einer neuen Csv Datei abzulegen.

### Programmablauf

Schreiben Sie ein Programm mit folgendem Ablauf.
  
* Der Name der Csv-Datei wird bestimmt.  
  Wird dem Programm ein Programmzeilenargument übergeben, wird dieser als Csv Dateiname verwendet. Ansonsten wird "Pupils.csv" angenommen.
* Der gesamte Inhalt der Csv Datei wird in ein Array der Datenkapsel **Pupil** geladen.
* Kandidaten mit einer negativen Note (5) in einem beliebigen Gegenstand werden bei der Aufnahme nicht berücksichtigt. Durch den Aufruf einer Methode werden aus den gelesenen Kandidaten alle aufnahmeberechtigte bestimmt.
* Das Programm sortiert anschließend die Liste (=Array) nach "Notenschnitt".  
  Der Notenschnitt errechnet sich nach **(Math*2 + Deutsch + Englisch) / 4.0**.
* Im nächsten Schritt gibt das Programm die sortierte Liste (=Array) der Kandidaten aus.  
  Siehe **Bildschirmausgabe**.
* Zum Abschluss speichert das Programm die sortierte Liste in die Datei mit dem Namen "SortedPupil.csv". In dieser Datei wird zusätzlich zu den vorhandenen Spalten die Spalte *GradeAverage* abgespeichert.

#### Csv-Datei (lesen)

```
LastName;FirstName;GradeGerman;GradeEnglish;GradeMath
Bennet;Marie;4;2;2
Bosse;Johannes;3;1;1
```

#### Csv-Datei (SortedPupil.csv)

```
LastName;FirstName;GradeGerman;GradeEnglish;GradeMath;GradeAverage
Eva;Max;1;1;1;1
Chiara;Laurin;2;1;1;1.25
Elvin;Adem;2;1;1;1.25
```

### Programmdesign

Achten Sie bei der Umsetzung auf ein sauberes Design Ihres Programms.  
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.  

Damit die Unittests ausgeführt werden können, müssen sie folgende (Hilfs-)Methoden umsetzen:

#### Program.cs

* `Pupil[] ReadPupilsFromCsv(string fileName)`  
  Alle Kandidaten werden in ein Array (Datenkapsel **Pupil**) geladen.
* `Pupil[] FilterByGrade(Pupil[] pupils)`  
  Die Methode liefert ein Array mit den Kandidaten, bei denen alle Noten positiv (also kein 5) sind.  
* `Pupil[] SortByGrade(Pupil[] pupils)`  
  Erstellt ein neues Array mit den nach dem Notenschnitt sortierten Kandidaten.
* `void WritePupilsToCsv(Pupil[] pupils, string fileName)`
  Mit dieser Methode werden die bereits sortierten Kandidaten in eine neue Csv Datei geschrieben. Eine zusätzlich Spalte **GradeAverage** wird in die Csv Datei aufgenommen.  

#### Datenkapsel **Pupil**

Die Datenkapsel **Pupil** hat die folgenden Eingenschaften (Properties):  

* `FirstName`
* `LastName`  
* `GradeEnglish`
* `GradeGerman`
* `GradeMath`

### Bildschirmausgabe

```
SelectPupils
=====================
LastName             FirstName            D E M Grade
Max                  Eva                  1 1 1     1
Laurin               Chiara               2 1 1  1,25
Adem                 Elvin                2 1 1  1,25
Salih                Shanaya              2 1 1  1,25
Konstantin           Ella                 1 3 1   1,5
Erik                 Anastasia            2 2 1   1,5
Eymen                Aylin                1 1 2   1,5

```

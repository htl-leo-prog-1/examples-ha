c# Programmieren (c) HTL-Leonding

# Fussballmeisterschaft

## Lehrziele

* Datenkapsel
* Csv Datei Lesen
* Wiederholung: Array
* Wiederholung: Sortieren
* Programm Kommandozeilen-Argumente.

## Aufgabenstellung

In einer Csv Datei sind alle Spiele einer Fussbalmeisterschaft gespeichert. Gesucht ist ein Programm zur Erstellung der Rangliste aus dieser Csv Datei.
Dabei sind die aktuellen Regeln des ÖFB's bei Punktegleichstand zweier oder mehrerer Teams zu berücksichtigen.  

### Programmablauf
Schreiben Sie ein Programm mit folgenden Eigenschaften.  
* Der Name der Csv-Datei wird bestimmt.  
  Wird dem Programm ein Programmzeilenargument übergeben, wird dieser als Csv Dateiname verwendet. Ansonsten wird "Games.csv" angenommen.   
* Der gesamte Inhalt der Csv Datei wird in ein Array der Datenkapsel **Game** geladen.  
* Aus diesem **Game** Array werden die Teams (eine Array mit der  Datenkapsel **Team**) bestimmt.
* Im nächsten Schritt sortiert das Programm die Teams. Hier sind die ÖFB Regeln anzuwenden.
* Als letzten Schritt gibt das Programm die fertige (sortierte) Liste (=Array) der Teams aus. 
 
### Programmdesign

Achten Sie bei der Umsetzung auf ein sauberes Design Ihres Programms.  
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.  
Damit die Unittests ausgeführt werden können, müssen sie folgende (Hilfs-)Methoden umsetzen:

#### Csv-Datei

```
Round;Date;HomeTeam;GuestTeam;Score;ScoreHalfTime
1;15.8.2021 15:00;SV Horn;Union LUV Graz;5:1;(2:0)
```

#### FussballMeisterschaft.cs

* `Game[] ReadGamesFromFile(string fileName)`  
  Alle Spiele werden in ein Array (Datenkapsel **Game**) geladen.
* `Game[] FilterGamesByTeam(Game[] games, string teamName1, string teamName2)`  
  Haben zwei Mannschaften die gleiche Punkteanzahl, müssen die Spiele gegeneinander analysiert werden.
  Mit dieser Methode werden aus dem übergebenen "games" die Spiele dieser beiden Mannschaften herausgesucht.  
* `void CountGoals(Game[] games, string teamName, out int goals, out int gotGoals)`  
  Berechnet die Tordifferenz für ein Team. In den "games" werden die Spiele verwendet, bei denen das Team als Heim- oder Gastmannschaft eingetragen ist. 
* `int CalculatePoints(Game[] games, string teamName)`  
  Berechnet die Punkte aufgrund der übergebenen Spieleliste. Ein Spiel wird nur berücksichtigt, wenn der übergebene Teamname entweder Heim- oder Gast ist.
* `int CountAwayGoals(Game[] games, string teamName)`  
  Zählt die "Auswärts-Tore". Ein Auswärtstor ist ein Tor, dass das Team als "Gast" erzielen konnte.
* `Team[] CreateListOfTeams(Game[] games)`   
  Erstellt eine Team-Liste(=Array) basierend auf den Spielen (Games). Alle Eigenschaften (=Properties) werden berechnet.  
  Die Team-Liste ist noch nicht sortiert.
* `Team[] SortByScore(Game[] games, Team[] teams)`  
  Sortiert die Teams nach "Erfolg".
* `bool IsBetterRanking(Game[] games, Team[] teams, int teamIdx1, int teamIdx2)`  
  Vergleicht zwei Teams, welches auf dem Meisterschaftsergebnis vor dem anderen liegt.  
  Vergleich:

  * Haben zwei oder mehr Mannschaften die gleiche Punkteanzahl, entscheidet die Anzahl der Punkte aus den direkten Spielen der betreffenden Teams gegeneinander über die Reihung.Ausnahme: Bei Strafverifizierungen erfolgt weiterhin eine automatische Rückreihung bei Punktegleichheit.
  * Bei gleicher Punkteanzahl aus den direkten Begegnungen entscheidet die bessere Tordifferenz aus den direkten Partien der betreffenden Teams.
  * Ist auch die Tordifferenz gleich, entscheidet die höhere Zahl an erzielten Toren.
  * Wenn auch die gleich ist, wird die Höhe der erzielten Auswärtstore herangezogen.
  * Erst wenn auch die gleich ist, entscheidet wie bisher die Tordifferenz aus allen Meisterschaftspartien.


#### Datenkapsel **Game**

Properties:
 * `Round`  
    Runde in der Meisterschaft
 * `Date`   
 * `HomeTeam`           
 * `GuestTeam`          
 * `GoalsHome`          
 * `GoalsGuest`         
 * `HalfTimeGoalsHome`  
 * `HalfTimeGoalsGuest`   

ReadOnly-Properties (diese können berechnet werden)
 * `HomePoints`  
   Bei Unentscheiden 1, wenn Heimmannschaft gewonnen 3, sonst 0
 * `GuestPoints`  
   Bei Unentscheiden 1, wenn Heimmannschaft gewonnen 0, sonst 3

#### Datenkapsel **Team**

Properties:
* `TeamName`      
* `WinCount`  
  Anzahl der Spiele, die das Team gewonnen hat.     
* `LossCount`     
  Anzahl der Spiele, die das Team verloren hat.
* `TieCount`      
  Anzahl der Spiele, die als Ergebnis "unentschieden" haben.
* `GoalsCount`    
* `GotGoalsCount` 

ReadOnly-Properties (diese können berechnet werden)
* `GameCount`  
  Gesamtanzahl der Spiele (Gewonnen+verloren+unentschieden)
* `Points`    
  Erreichte gesamtpunkte (Summe über alle Spiele) - Basis für den Platz.
* `GoalDiff`  
  Tordifferenz als absoluter Wert (Bekommene Tore zu erzielte Tore)
* `GoalVsGot`  
  Tordifferenz als Zeichenkette: z.B.: 35:45

### Bildschirmausgabe

```
Rank Team                                      SP   S   N   U   Tore    +/-   Pt
====================================================================================
   1 SPG UNION Kleinmünchen/FC Blau-Weiß Linz  23  17   3   3  89:30     59   54
   2 Wildcats 11teamsports Krottendorf         23  17   3   3  83:31     52   54
   3 FC Mohren Dornbirn Damen                  23  17   3   3  83:28     55   54
   4 SV Horn                                   23  14   5   4  60:26     34   46
   5 Union LUV Graz                            23  14   7   2  63:36     27   44
   6 Carinthians LIWOdruck Hornets             23  13   6   4  49:20     29   43
   7 RW Rankweil                               23  10   8   5  31:41    -10   35
   8 Sportunion Raiffeisen Geretsberg          23   9  12   2  40:52    -12   29
   9 Wiener Sport-Club                         23   8  11   4  59:60     -1   28
  10 USC Landhaus                              24   5  17   2  52:91    -39   17
  11 SV Fenastra Krenglbach                    23   4  18   1  43:79    -36   13
  12 SC Neusiedl am See 1919                   23   3  18   2  15:83    -68   11
  13 FC Altera Porta                           23   1  21   1 22:112    -90    4
  ```

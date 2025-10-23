---
fontsize: 12pt
---

# COVID-Registrierung

Du sollst für ein Restaurant eine Registrierungs-Software schreiben, bei der sich Gäste wegen der Corona Richtlinien anmelden können.

- Es soll gefragt werden, wie viele Gäste registriert werden sollen.
- Es soll von jedem Gast **Vorname**, **Nachname** und **Geburtsdatum** eingegeben werden. Die Informationen einer einzelnen Person sollen in einem `struct Person` oder einer `class Person` gekapselt und alle Personen in einem `Person`-Array gespeichert werden.
- das Datum darf als `string` gespeichert werden und muss kein bestimmtes Format haben (zB: `01.01.1900` oder `1900-01-01`).
- Das `struct Person` oder die `class Person` muss einen *Constructor* enthalten, der alle 3 Attribute übernimmt.
- Wenn alle Personen registriert sind, sollen die neuen Personen in das File *persons.csv* im folgenden Format gespeichert werden:
```
Vorname1,Nachname1,Geburtsdatum1
Vorname2,Nachname2,Geburtsdatum2
...
```
- Sollte das File noch nicht existieren, dann wird es neu erstellt. Sollte es jedoch schon existieren und sich schon Einträge in der Datei *persons.csv* befinden, dann sollen die neuen Personen darunter eingefügt werden.
- Du darfst dich darauf verlassen, dass das File, wenn es existiert, nur gültige Einträge im richtigen Format enthält.

\pagebreak

**Im Template findest du schon ein leeres** `struct Person` **, das gerne in eine** `class` **geändert werden darf. Außerdem sind auch schon ein paar Methoden-Header vordefiniert, welche folgende Aufgaben erfüllen sollen:**

```csharp
static Person PersonFromString(string line)
```
Diese Methode übernimmt einen `string` (zB: `"Alexander,Kornfellner,29.02.1999"`) und gibt ein `Person`-Objekt zurück.

```csharp
static string PersonToString(Person person)
```
Diese Methode übernimmt ein `Person`-Objekt und gibt einen `string` (zB: `"Alexander,Kornfellner,29.02.1999"`) zurück.

```csharp
static void SavePersons(Person[] persons)
```
Diese Methode übernimmt ein `Person`-Array und schreibt alle Personen in die *person.csv* Datei.


### Programmablauf Beispiel:

```
COVID - Registrierung
=====================

Wie viele Personen sollen registriert werden? 2

Person 1:
Vorname: Alexander 
Nachname: Kornfellner
Geburtsdatum: 29.02.1999

Person 2:
Vorname: Max
Nachname: Mustermann
Geburtsdatum: 01.01.1900
```

Anschließend soll der Inhalt der Datei *persons.csv* (wenn sie vorher leer war) so aussehen:

```
Alexander,Kornfellner,29.02.1999
Max,Mustermann,01.01.1900
```
c# Programmieren (c) HTL-Leonding

# Rational Number

## Lehrziele

* OO Basic
* Methoden und Properties

## Aufgabenstellung

Gesucht ist eine Klasse, die Rationale Zahlen unterstützt. Rationale Zahlen sind Zahlen, die sich durch einen Bruch darstellen lassen: siehe https://de.wikipedia.org/wiki/Rationale_Zahl

Die gesuchte Klasse muss folgende Funktinalitäten aufweisen:
* Der Eigenschaften **Nenner** ( `Numerator` ) und der **Zähler** ( `Denumerator` ) sind ganze Zahlen (Datentyp int). Sie lassen sich **nur** über den Konstruktor setzen. (Damit ist eine Instanz dieser Klasse unveränderbar = **immutable** ) 
* `Normalize`
  Mit dieser Methode wird eine neue Rationale Zahl angelelgt. 
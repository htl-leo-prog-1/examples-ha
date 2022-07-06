c# Programmieren (c) HTL-Leonding

# Roman Literals

## Lehrziele

* Datenkapsel (struct or class)

## Aufgabenstellung

Gesucht ist ein Programm, dass zwei Zahlen einliest - entweder römisch (z.B. *MXII*) oder arabisch (z.B.: 444) und die Summe als römiche Zahl ausgibt.  
Dazu müssen Zahlen in und aus dem römischen Format konvertiert werden können.

## Berechnungshinweis

### Konvertierung "arabisch" nach "römisch"

Bei der Konvertierung von z.B. 78 kann wie folgt vorgegangen werden:

 1. Wir beginnen mit *L* (=50) weil die Zahl größer als 50 ist.
 2. Wir ziehen von 78 den Wert 50 ab (weil wir *L* verwenden) und erhalten den (Rest-)Wert 28
 3. Mit *X* dürfen wir von 28 den Wert 10 abziehen und erhalten dadurch *LX* und den Restwert von 18
 4. Wir können noch einmal *X* abziehen und erhalten *LXX* und den Restwert 8
 5. Von 8 können wir *V* (Wert 5) abziehen und erhalten: *LXXV* und als Rest 3
 6. Von 3 können wir drei mal I (Wert: 1) abziehen und erhalten damit *LXXVIII* und Rest 0.
 7. Wenn wir keinen Rest mehr haben, sind wir fertig.
  
Die Werte, die von der zu konvertierenden Zahl abgezogen werden können, sind (unvollständig):

* X für 10
* IX für 9
* V für 5
* IV für 4
* I für 1

Diese Werte sind in einem Array von einer Datenkapsel (struct oder class) abzulegen. 

### Konvertierung "römisch" nach "arabisch"

Die Konvertierung funktioniert analog. Anstatt den Restwert zu vergleichen, werden die ersten Zeichen der römischen Zahl (=string) gesucht. Wird z.B. am Beginn der römichen Zahl ein *M* gefunden, kann 1000 addiert werden und die weitere Konverierung wird ohne dem *M* fortgesetzt.

Geprüft wird auf: M(=1000), CM(=900), ...

## Programmdesign

Achten Sie bei der Umsetzung auf ein sauberes Design Ihres Programms.  
In dem bereitgestellten Programm-Template sind Unittests vorhanden. Implementieren Sie die Methoden so, dass **alle** Unittests erfolgreich ausgeführt werden können. Änderungen an den *Unittests* sind nicht erlaubt.  

Damit die Unittests ausgeführt werden können, müssen sie folgende (Hilfs-)Methoden umsetzen:

## RomanNumerals.cs

* `string ConvertToRomanLiteral(int number)`  
  Die gegebene Zahl wird in eine römische Zahl (string) konvertiert. Kann die Zahl nicht konvertiert werden (z.B. >= 4000), liefert die Methode *null*.
* `int ConvertFromRomanLiteral(string roman)`  
  Von einer gegebenen römischen Zahl (string) wird der Wert berechnet. Bei einer ungültigen Zahl wird *-1* ausgegeben.  

## Bildschirmausgabe

```
Roman Numerals Adder
========================
Please enter first roman:  CDXLIV
Please enter second roman: CMXCIX
          CDXLIV
+         CMXCIX
=       MCDXLIII
```
oder (Eingabe von "arabischen" Zahlen)
```
Roman Numerals Adder
========================
Please enter first roman:  444
Please enter second roman: 999
          CDXLIV
+         CMXCIX
=       MCDXLIII

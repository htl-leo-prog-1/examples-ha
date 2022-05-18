c# Programmieren (c) HTL-Leonding

# Auflistung Dateien

## Lehrziele

* Programmargumente (Kommando-Zeilen-Parameter)
* Dateisystem - Lesen der Inhaltsverzeichnisse
* Rekursion

## Aufgabenstellung

Das gesuchte Programm **DirRecursive** soll alle Dateien in einem angegebenen Verzeichnis suchen und ausgeben. Zusätzlich werden auch die Unterverzeichnisse in die Suche mit eingeschlossen. Zur Steuerung des Programmverhaltens werden Kommando-Zeilen-Argumente übergeben:  
* Der erste Kommando-Zeilen-Parameter ist zwingend und definiert das Verzeichnis, ab welchem die Suche beginnen soll. Es sind absolute und relative Verzeichnisangaben erlaubt. Das Verzeichnis muss existieren - ansonsten wird eine Fehlermeldung ausgegeben und das Programm beendet.  
Bei der Ausgabe muss immer ein absoluter Pfad verwendet werde.
* Der zweite Parameter ist optional (er muss nicht angegeben werden).  Damit wird ein Filter festgelegt, welche Dateien in die Ausgabe aufgenommen werden sollen.  
Beispiel: Der Filter `*.cs` sucht alle c# Dateien (Endung `cs`).  
* Werden weitere Parameter angegeben, ist das Programm mit einer entsprechenden Fehlermeldung zu beenden.

Am Ende muss die Gesamtanzahl der gefundenen Dateien ausgegeben werden.
  
### Bildschirmausgabe
Die Steuereung des Programms erfolgt über die Programm-Argumente. Eine Eingabe mit `Console.ReadLine()` wird daher **nicht** benötigt. Fehlermeldungen (z.B. falscher Dateiname) werden auf der Konsole ausgegeben.

```
DirRecursive.exe c:\tmp\c# *.cs
c:\tmp\c#\DirRecursive\Solution\DirRecursive\DirRecursive.cs
c:\tmp\c#\FileWizard\Solution\FileWizard\Program.cs
c:\tmp\c#\FileWizard\Template\FileWizard\Program.cs
c:\tmp\c#\HarshadNumbers\HarshadNumbers.cs
c:\tmp\c#\IndexOf\StringIndexOfReplace.cs
c:\tmp\c#\UpdateProduct\Solution\UnitTests\CsvImport.cs
c:\tmp\c#\UpdateProduct\Solution\UnitTests\CsvImportBase.cs
c:\tmp\c#\UpdateProduct\Solution\UnitTests\Product.cs
c:\tmp\c#\UpdateProduct\Solution\UnitTests\UpdateProductCsvTests.cs
c:\tmp\c#\UpdateProduct\Solution\UpdateProductCsv\Product.cs
c:\tmp\c#\UpdateProduct\Solution\UpdateProductCsv\UpdateProductCsv.cs
c:\tmp\c#\UpdateProduct\Template\UnitTests\CsvImport.cs
c:\tmp\c#\UpdateProduct\Template\UnitTests\CsvImportBase.cs
c:\tmp\c#\UpdateProduct\Template\UnitTests\Product.cs
c:\tmp\c#\UpdateProduct\Template\UnitTests\UpdateProductCsvTests.cs
c:\tmp\c#\UpdateProduct\Template\UpdateProductCsv\Product.cs
c:\tmp\c#\UpdateProduct\Template\UpdateProductCsv\UpdateProductCsv.cs
total 17
```
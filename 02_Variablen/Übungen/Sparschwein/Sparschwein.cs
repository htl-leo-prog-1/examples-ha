using System;

/*
  Der Inhalt des Sparschweins soll berechnet werden. Dazu gibt der 
  Benutzer die Anzahl für Eineuro- , Zweiereuro- und Fünfzigcentmünzen
  ein. Anschließend berechnet der Computer das Ersparnis aus und gibt 
  dieses aus.  
*/
namespace EinfInProg
{
  class Sparschwein
  {
    static void Main(string[] args)
    {
      const double EINER_WERT = 1;
      const double ZWEIER_WERT = 2;
      const double FUENFZIGERL_WERT = 0.5;
      
      string input;
      double ersparnis;
      int einerAnzahl, zweierAnzahl, fuenfzigerlAnzahl;
      
      Console.WriteLine("Das Programm, welches dein Sparschwein entschlüsselt");
      Console.WriteLine("  von Prof. Gerhard Gehrer");
      Console.WriteLine();
      
      // Beginn: Eingabe der Berechnungsdaten (E)
      Console.Write("Wie viele Fünfziger? ");
      input = Console.ReadLine();
      fuenfzigerlAnzahl = Convert.ToInt32(input);

      Console.Write("Wie viele Eurostücke? ");
      input = Console.ReadLine();
      einerAnzahl = Convert.ToInt32(input);

      Console.Write("Wie viele Zweieurostücke? ");
      input = Console.ReadLine();
      zweierAnzahl = Convert.ToInt32(input);      
      // Ende: Eingabe
      
      // Beginn: Verarbeitung der Daten
      ersparnis = fuenfzigerlAnzahl * FUENFZIGERL_WERT
                + einerAnzahl * EINER_WERT
                + zweierAnzahl * ZWEIER_WERT;
      // Ende: Verarbeitung
      
      // Beginn: Ausgabe
      Console.WriteLine("Dein Sparschwein enthält: {0:f} EUR", ersparnis);
      // Ende: Ausgabe
    }
  }
}
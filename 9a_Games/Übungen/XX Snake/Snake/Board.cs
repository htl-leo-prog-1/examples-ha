using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Zugriffsklasse auf das Windows-Board
/// </summary>
public class Board
{
    static bool boardInitialized;  // Ist das Board bereits initialisiert
    int zeilen;
    int spalten;
    string title;
    FormBoard form;  // WindowsForm zur Darstellung in zweitem Thread
    private static Board instance = null;
    private static Thread formThread = null;  // Thread, in dem Windows-Board läuft

    /// <summary>
    /// Spielfeld mit zeilen/spalten anlegen
    /// </summary>
    /// <param name="zeilen"></param>
    /// <param name="spalten"></param>
    private Board(int zeilen, int spalten)
    {
        this.zeilen = zeilen;
        this.spalten = spalten;
    }

    /// <summary>
    /// Das Board wird in einem Fenster ausgegeben.
    /// </summary>
    /// <param name="zeilen"></param>
    /// <param name="spalten"></param>
    public static void Init(int zeilen, int spalten, string title)
    {
        boardInitialized = false;
        instance = new Board(zeilen, spalten);
        instance.title = title;
        formThread = new Thread(new ThreadStart(Board.Run));
        formThread.IsBackground = true;
        formThread.Start();
        while (!boardInitialized)  // Warten, bis das Board fertig initialisiert ist
        {
            System.Threading.Thread.Sleep(100);
        }

    }

    /// <summary>
    /// Board schließen ==> Windows-Anwendung schließen
    /// </summary>
    public static void Exit()
    {
        Application.Exit();
    }


    /// <summary>
    /// Titel des Spielfeldes lesen 
    /// </summary>
    public static string Title
    {
        get { return instance.title; }
    }

    ///// <summary>
    ///// Spaltenüberschriften setzen
    ///// </summary>
    ///// <param name="header">Array of Strings mit den Spaltenüberschriften</param>
    //public void SetColumnHeader(string[] header)
    //{
    //    int cols = Math.Min(header.Length, spalten); // mehr Headerspalten gehen nicht
    //    for (int col = 0; col < cols; col++)
    //    {
    //        columnHeader[col].Text = header[col];
    //    }
    //}


    ///// <summary>
    ///// Zeilenbezeichner setzen.
    ///// </summary>
    ///// <param name="header">Je Zeile ein Bezeichner</param>
    //public void SetRowHeader(string[] header)
    //{
    //    // Zuerst Platz schaffen, indem eine Zeile (Panel) für
    //    // den Header angelegt wird und dieses Panel eingefügt wird
    //    int rows = Math.Min(header.Length, zeilen); 
    //    for (int row = 0; row < rows; row++)
    //    {
    //        rowHeader[row].Text = header[row];
    //    }
    //}



    /// <summary>
    /// Die Methode Run startet das Zeichenfenster unter einem eigenen Thread. Dadurch wird eine 
    /// Entkoppelung von der eigentlichen Anwendung erreicht.
    /// </summary>
    private static void Run()
    {
        instance.form = new FormBoard(instance.zeilen, instance.spalten, instance.title);
        boardInitialized = true;
        Application.Run(instance.form);
    }

    /// <summary>
    /// Text im Board setzen. Farbe mit "Red", "Green" und "Black" setzen
    /// </summary>
    public static void SetText(int zeile, int spalte, string text, string color)
    {
        if (instance == null) return;
        instance.form.SetText(zeile, spalte, text, color);
    }

    /// <summary>
    /// Text im Board setzen. 
    /// </summary>
    public static void SetText(int zeile, int spalte, string text)
    {
        if (instance == null) return;
        instance.form.SetText(zeile, spalte, text);
    }

    /// <summary>
    /// Text aus dem Board zurücklesen
    /// </summary>
    /// <param name="zeile"></param>
    /// <param name="spalte"></param>
    /// <returns>String der jeweiligen Zelle</returns>
    public static string GetText(int zeile, int spalte)
    {
        if (instance == null) return null;
        return instance.form.GetText(zeile, spalte);
    }

    /// <summary>
    /// Inhalte des Boards löschen
    /// </summary>
    public static void Clear()
    {
        if (instance == null) return;
        for (int i = 0; i < instance.zeilen; i++)
        {
            for (int j = 0; j < instance.spalten; j++)
            {
                SetText(i, j, "");
            }
        }

    }
}

/// <summary>
/// WindowsBoard wird in einem zweiten Thread gestartet.
/// Der Zugriff auf die Elemente erfolgt über Invoke im Kontext des Windows-Threads
/// </summary>
public class FormBoard : Form
{
    const int CellHeight = 22;
    const int CellWidth = 22;
    private TextBox[,] board;
    private TextBox[] columnHeader;
    private TextBox[] rowHeader;
    private Panel panelBrett;
    private Panel panelAll;
    private Panel panelColumnHeader = null; // null ==> existiert noch nicht
    private Panel panelRowHeader = null;
    private int zeilen;
    private int spalten;

    public FormBoard(int zeilen, int spalten, string title)
    {
        this.zeilen = zeilen;
        this.spalten = spalten;
        InitializeComponent();
        Text = title;
    }


    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Textboxen programmgesteuert auf dem Panel positionieren
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "FormBoard";
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        ClientSize = new System.Drawing.Size(292, 266);
        ControlBox = false;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Location = new System.Drawing.Point(600, 200);
        Name = "FormBoard";
        Text = "FormBoard";
        board = new TextBox[zeilen, spalten];
        panelAll = new Panel();
        Controls.Add(panelAll);
        panelBrett = new Panel();
        panelBrett.Width = spalten * CellWidth;
        panelBrett.Height = zeilen * CellHeight;
        panelAll.Controls.Add(panelBrett);
        TextBox textBox;
        // ColumnHeader
        panelColumnHeader = new Panel();
        columnHeader = new TextBox[spalten];
        panelColumnHeader.Height = CellHeight;
        panelColumnHeader.Width = spalten * CellWidth;
        for (int col = 0; col < spalten; col++)
        {
            textBox = erzeugeTextBox(Color.SkyBlue, col.ToString());
            columnHeader[col] = textBox;
            textBox.Location = new System.Drawing.Point(col * CellWidth, 0);
            panelColumnHeader.Controls.Add(textBox);
        }
        panelAll.Controls.Add(panelColumnHeader);
        panelColumnHeader.Location = new System.Drawing.Point(CellWidth, 0);
        // Row-Header
        panelRowHeader = new Panel();
        panelRowHeader.Height = zeilen * CellHeight;
        rowHeader = new TextBox[zeilen];
        panelRowHeader.Width = CellWidth;
        for (int row = 0; row < zeilen; row++)
        {
            textBox = erzeugeTextBox(Color.SkyBlue, row.ToString());
            rowHeader[row] = textBox;
            textBox.Location = new System.Drawing.Point(0, row * CellHeight);
            panelRowHeader.Controls.Add(textBox);
        }
        panelAll.Controls.Add(panelRowHeader);
        panelRowHeader.Location = new System.Drawing.Point(0, CellHeight);
        Text = "";
        erzeugeFelder(zeilen, spalten);
        panelBrett.Location = new System.Drawing.Point(CellWidth, CellHeight);
        panelAll.Width = panelBrett.Width + CellWidth;
        panelAll.Height = panelBrett.Height + CellHeight;
        ClientSize = new System.Drawing.Size(panelAll.Width, panelAll.Height);
        StartPosition = FormStartPosition.Manual;
        SetDesktopLocation(800, 50);

    }

    /// <summary>
    /// Delegate als Parameter zum Verändern der Texte im WinForm
    /// </summary>
    /// <param name="zeile"></param>
    /// <param name="spalte"></param>
    /// <param name="text"></param>
    /// <param name="color"></param>
    private delegate void setTextDelegate(int zeile, int spalte, string text, string color);

    private void setText2ZelleDelegate(int zeile, int spalte, string text, string color)
    {
        board[zeile, spalte].Text = text;
        board[zeile, spalte].ForeColor = formsColor(color);
    }

    /// <summary>
    /// Text in Zeile und Spalte schreiben. In Context des Windows-Threads umschalten.
    /// </summary>
    /// <param name="zeile"></param>
    /// <param name="spalte"></param>
    /// <param name="text"></param>
    public void SetText(int zeile, int spalte, string text)
    {
        board[zeile, spalte].Invoke(new setTextDelegate(setText2ZelleDelegate), zeile, spalte, text, "Black");
    }

    /// <summary>
    /// Text in Zeile und Spalte in der entsprechenden Farbe ausgeben
    /// </summary>
    /// <param name="zeile"></param>
    /// <param name="spalte"></param>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public void SetText(int zeile, int spalte, string text, string color)
    {
        board[zeile, spalte].Invoke(new setTextDelegate(setText2ZelleDelegate), zeile, spalte, text, color);
    }

    /// <summary>
    /// Auslesen der Zelle an der gegebenen Position
    /// </summary>
    /// <param name="zeile"></param>
    /// <param name="spalte"></param>
    /// <returns></returns>
    public string GetText(int zeile, int spalte)
    {
        return board[zeile, spalte].Text;
    }

    /// <summary>
    /// Die Felder für das Spielfeld werden erzeugt.
    /// </summary>
    /// <param name="zeilen"></param>
    /// <param name="spalten"></param>
    private void erzeugeFelder(int zeilen, int spalten)
    {
        for (int zeile = 0; zeile < zeilen; zeile++)
            for (int spalte = 0; spalte < spalten; spalte++)
                erzeugeFeld(zeile, spalte);
    }

    /// <summary>
    /// Ein Feld wird erzeugt. Die Position ergibt sich aus Zeile und Spalte. 
    /// </summary>
    /// <param name="zeile"></param>
    /// <param name="spalte"></param>
    private void erzeugeFeld(int zeile, int spalte)
    {
        TextBox textBox = erzeugeTextBox(Color.White, "");
        board[zeile, spalte] = textBox;
        textBox.Location = new System.Drawing.Point(spalte * CellWidth, zeile * CellHeight);
        panelBrett.Controls.Add(textBox);
    }

    /// <summary>
    /// Eine Textbox wird erzeugt
    /// </summary>
    /// <param name="backGround">Hintergrundfarbe</param>
    /// <param name="text">Anzuzeigender Text</param>
    /// <returns></returns>
    private TextBox erzeugeTextBox(Color backGround, string text)
    {
        TextBox textBox = new TextBox();
        textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        textBox.Size = new System.Drawing.Size(CellWidth, CellHeight);
        textBox.TabStop = false;
        textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        textBox.BackColor = backGround;
        textBox.ReadOnly = true;
        textBox.Text = text;
        textBox.BorderStyle = BorderStyle.Fixed3D;
        return textBox;
    }

    /// <summary>
    /// Umwandlung des Farbtextes in die entsprechende Forms-Farbe
    /// </summary>
    /// <param name="textColor">Text für die vorgegebenen Farben</param>
    /// <returns></returns>
    private Color formsColor(string textColor)
    {
        switch (textColor)
        {
            case "Black": return Color.Black;
            case "Red": return Color.Red;
            case "Green": return Color.Green;
            default: return Color.Black;
        }
    }
}


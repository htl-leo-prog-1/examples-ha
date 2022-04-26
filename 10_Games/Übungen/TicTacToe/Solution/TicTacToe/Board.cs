// HTL Leonding utility class for providing a simple playing field
// !!! Do NOT change anything in this file !!!

#region Board code - do not change

using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/// <summary>
///     Zugriffsklasse auf das Windows-Board
/// </summary>
public class Board
{
    private static bool _boardInitialized; // Ist das Board bereits initialisiert
    private static Board _staticBoard = default!;
    private readonly int _cols;
    private FormBoard _form; // WindowsForm zur Darstellung in zweitem Thread
    private readonly int _rows;
    private string _title;

    /// <summary>
    ///     Spielfeld mit _rows/_cols anlegen
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="cols"></param>
    private Board(int rows, int cols)
    {
        this._rows = rows;
        this._cols = cols;
        this._title = default!;
        this._form = default!;
    }


    /// <summary>
    ///     Titel des Spielfeldes lesen
    /// </summary>
    public static string Title => _staticBoard._title;

    /// <summary>
    ///     Das Board wird in der gewünschten Größe initialisiert.
    /// </summary>
    /// <param name="rows">Anzahl der gewünschten Zeilen</param>
    /// <param name="cols">Anzahl der Spalten</param>
    /// <param name="title">Text in Titelleiste</param>
    public static void Init(int rows, int cols, string title)
    {
        _boardInitialized = false;
        if (rows < 0)
        {
            rows = 0;
        }

        if (cols < 0)
        {
            cols = 0;
        }

        _staticBoard = new(rows, cols) { _title = title };
        Thread formThread = new(Run) { IsBackground = true };
        formThread.Start();
        while (!_boardInitialized) // Warten, bis das Board fertig initialisiert ist
        {
            Thread.Sleep(100);
        }
    }

    /// <summary>
    ///     Board schließen ==> Windows-Anwendung schließen
    /// </summary>
    public static void Exit()
    {
        Application.Exit();
    }

    /// <summary>
    ///     Die Methode Run startet das Zeichenfenster unter einem eigenen Thread. Dadurch wird eine
    ///     Entkoppelung von der eigentlichen Anwendung erreicht.
    /// </summary>
    private static void Run()
    {
        _staticBoard._form = new(_staticBoard._rows, _staticBoard._cols, _staticBoard._title);
        _boardInitialized = true;
        Application.Run(_staticBoard._form);
    }

    /// <summary>
    ///     Possible colors: Red, Green, Black, LightGrey
    /// </summary>
    public static void SetText(int row, int col, string text, string color)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (_staticBoard == null)
        {
            return;
        }

        if (row < 0 || row >= _staticBoard._rows || col < 0 || col >= _staticBoard._cols)
        {
            return;
        }

        _staticBoard._form.SetText(row, col, text, color);
    }

    /// <summary>
    ///     Text im Board setzen.
    /// </summary>
    public static void SetText(int row, int col, string text)
    {
        SetText(row, col, text, "Black");
    }

    /// <summary>
    ///     Text aus dem Board zurücklesen
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>String der jeweiligen Zelle</returns>
    public static string GetText(int row, int col)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (_staticBoard == null)
        {
            return null;
        }

        if (row < 0 || row >= _staticBoard._rows || col < 0 || col >= _staticBoard._cols)
        {
            return null;
        }

        return _staticBoard._form.GetText(row, col);
    }

    /// <summary>
    ///     Inhalte des Boards löschen
    /// </summary>
    public static void Clear()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (_staticBoard == null)
        {
            return;
        }

        for (var i = 0; i < _staticBoard._rows; i++)
        {
            for (var j = 0; j < _staticBoard._cols; j++)
            {
                SetText(i, j, "");
            }
        }
    }

    /// <summary>
    ///     Entsprechend der Methode GetLength bei Arrays kann auch hier
    ///     die Dimension des Boards (0=>Zeilen, 1=>Spalten) abgefragt werden.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public static int GetLength(int dimension)
    {
        return dimension switch
        {
            < 0 or >= 2 => -1,
            0 => _staticBoard._rows,
            _ => _staticBoard._cols
        };
    }
}


/// <summary>
///     WindowsBoard wird in einem zweiten Thread gestartet.
///     Der Zugriff auf die Elemente erfolgt über Invoke im Kontext des Windows-Threads
/// </summary>
public class FormBoard : Form
{
    private const int CELL_HEIGHT = 22;
    private const int CELL_WIDTH = 22;
    private readonly int _cols;
    private readonly int _rows;
    private TextBox[,] _board = default!;
    private TextBox[] _columnHeader = default!;
    private Panel _panelAll = default!;
    private Panel _panelBoard = default!;
    private Panel _panelColumnHeader = default!; // null ==> existiert noch nicht
    private Panel _panelRowHeader = default!;
    private TextBox[] _rowHeader = default!;


    /// <summary>
    ///     Required designer variable.
    /// </summary>
    private IContainer components = null!;

    public FormBoard(int rows, int cols, string title)
    {
        this._rows = rows;
        this._cols = cols;
        InitializeComponent();
        Text = title;
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    /// <summary>
    ///     Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.components.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    ///     Textboxen programmgesteuert auf dem Panel positionieren
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new Container();
        AutoScaleMode = AutoScaleMode.Font;
        Text = "FormBoard";
        AutoScaleBaseSize = new(5, 13);
        ClientSize = new(292, 266);
        ControlBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Location = new(600, 200);
        Name = "FormBoard";
        Text = "FormBoard";
        this._board = new TextBox[this._rows, this._cols];
        this._panelAll = new();
        Controls.Add(this._panelAll);
        this._panelBoard = new()
        {
            Width = this._cols * CELL_WIDTH + 10,
            Height = this._rows * CELL_HEIGHT + 10
        };
        this._panelAll.Controls.Add(this._panelBoard);
        TextBox textBox;
        // ColumnHeader
        this._panelColumnHeader = new();
        this._columnHeader = new TextBox[this._cols];
        this._panelColumnHeader.Height = CELL_HEIGHT;
        this._panelColumnHeader.Width = this._cols * CELL_WIDTH;
        for (var col = 0; col < this._cols; col++)
        {
            textBox = CreateTextBox(Color.SkyBlue, col.ToString());
            this._columnHeader[col] = textBox;
            textBox.Location = new(col * CELL_WIDTH, 0);
            this._panelColumnHeader.Controls.Add(textBox);
        }

        this._panelAll.Controls.Add(this._panelColumnHeader);
        this._panelColumnHeader.Location = new(CELL_WIDTH, 0);
        // Row-Header
        this._panelRowHeader = new();
        this._panelRowHeader.Height = this._rows * CELL_HEIGHT;
        this._rowHeader = new TextBox[this._rows];
        this._panelRowHeader.Width = CELL_WIDTH;
        for (var row = 0; row < this._rows; row++)
        {
            textBox = CreateTextBox(Color.SkyBlue, row.ToString());
            this._rowHeader[row] = textBox;
            textBox.Location = new(0, row * CELL_HEIGHT);
            this._panelRowHeader.Controls.Add(textBox);
        }

        this._panelAll.Controls.Add(this._panelRowHeader);
        this._panelRowHeader.Location = new(0, CELL_HEIGHT);
        Text = "";
        CreateCells(this._rows, this._cols);
        this._panelBoard.Location = new(CELL_WIDTH, CELL_HEIGHT);
        this._panelAll.Width = this._panelBoard.Width + CELL_WIDTH;
        this._panelAll.Height = this._panelBoard.Height + CELL_HEIGHT;
        ClientSize = new(this._panelAll.Width, this._panelAll.Height);
        StartPosition = FormStartPosition.Manual;
        SetDesktopLocation(800, 50);
    }

    private void SetTextToCellDelegate(int row, int col, string text, string color)
    {
        this._board[row, col].Text = text;
        this._board[row, col].ForeColor = GetFormsColor(color);
    }

    /// <summary>
    ///     Text in Zeile und Spalte schreiben. In Context des Windows-Threads umschalten.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    public void SetText(int row, int col, string text)
    {
        this._board[row, col].Invoke(new SetTextDelegate(SetTextToCellDelegate), row, col, text, "Black");
    }

    /// <summary>
    ///     Text in Zeile und Spalte in der entsprechenden Farbe ausgeben
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public void SetText(int row, int col, string text, string color)
    {
        this._board[row, col].Invoke(new SetTextDelegate(SetTextToCellDelegate), row, col, text, color);
    }

    /// <summary>
    ///     Auslesen der Zelle an der gegebenen Position
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public string GetText(int row, int col)
    {
        return this._board[row, col].Text;
    }

    /// <summary>
    ///     Die Felder für das Spielfeld werden erzeugt.
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="cols"></param>
    private void CreateCells(int rows, int cols)
    {
        for (var row = 0; row < rows; row++)
        for (var col = 0; col < cols; col++)
        {
            CreateCell(row, col);
        }
    }

    /// <summary>
    ///     Ein Feld wird erzeugt. Die Position ergibt sich aus Zeile und Spalte.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void CreateCell(int row, int col)
    {
        var textBox = CreateTextBox(Color.White, "");
        this._board[row, col] = textBox;
        textBox.Location = new(col * CELL_WIDTH, row * CELL_HEIGHT);
        this._panelBoard.Controls.Add(textBox);
    }

    /// <summary>
    ///     Eine Textbox wird erzeugt
    /// </summary>
    /// <param name="backGround">Hintergrundfarbe</param>
    /// <param name="text">Anzuzeigender Text</param>
    /// <returns></returns>
    private static TextBox CreateTextBox(Color backGround, string text)
    {
        var textBox = new TextBox();
        textBox.Font = new("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox.Size = new(CELL_WIDTH, CELL_HEIGHT);
        textBox.TabStop = false;
        textBox.TextAlign = HorizontalAlignment.Center;
        textBox.BackColor = backGround;
        textBox.ReadOnly = true;
        textBox.Text = text;
        textBox.BorderStyle = BorderStyle.Fixed3D;
        return textBox;
    }

    /// <summary>
    ///     Umwandlung des Farbtextes in die entsprechende Forms-Farbe
    /// </summary>
    /// <param name="textColor">Text für die vorgegebenen Farben</param>
    /// <returns></returns>
    private static Color GetFormsColor(string textColor)
    {
        return textColor switch
        {
            "Black" => Color.Black,
            "Red" => Color.Red,
            "Green" => Color.Green,
            "LightGrey" => Color.LightGray,
            _ => Color.Black
        };
    }

    /// <summary>
    ///     Delegate als Parameter zum Verändern der Texte im WinForm
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    /// <param name="color"></param>
    private delegate void SetTextDelegate(int row, int col, string text, string color);
}

# endregion
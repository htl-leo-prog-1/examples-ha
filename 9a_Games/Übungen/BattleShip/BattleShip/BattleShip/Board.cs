using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

    /// <summary>
    /// Zugriffsklasse auf das Windows-Board
    /// </summary>
    public class Board
    {
        static bool _boardInitialized;  // Ist das Board bereits initialisiert
        int _rows;
        int _cols;
        string _title;
        FormBoard _form;  // WindowsForm zur Darstellung in zweitem Thread
        private static Board _staticBoard;

        /// <summary>
        /// Spielfeld mit _rows/_cols anlegen
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        private Board(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
        }

        /// <summary>
        /// Das Board wird in der gewünschten Größe initialisiert.
        /// </summary>
        /// <param name="rows">Anzahl der gewünschten Zeilen</param>
        /// <param name="cols">Anzahl der Spalten</param>
        /// <param name="title">Text in Titelleiste</param>
        public static void Init(int rows, int cols, string title)
        {
            Thread formThread;  // Thread, in dem Windows-Board läuft
            _boardInitialized = false;
            if (rows < 0)
            {
                rows = 0;
            }
            if (cols < 0)
            {
                cols = 0;
            }
            _staticBoard = new Board(rows, cols) {_title = title};
            formThread = new Thread(Run) {IsBackground = true};
            formThread.Start();
            while (!_boardInitialized)  // Warten, bis das Board fertig initialisiert ist
            {
                Thread.Sleep(100);
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
            get { return _staticBoard._title; }
        }

        /// <summary>
        /// Die Methode Run startet das Zeichenfenster unter einem eigenen Thread. Dadurch wird eine 
        /// Entkoppelung von der eigentlichen Anwendung erreicht.
        /// </summary>
        private static void Run()
        {
            _staticBoard._form = new FormBoard(_staticBoard._rows, _staticBoard._cols, _staticBoard._title);
            _boardInitialized = true;
            Application.Run(_staticBoard._form);
        }

        /// <summary>
        /// Text im Board setzen. Farbe mit "Red", "Green" und "Black" setzen
        /// </summary>
        public static void SetText(int row, int column, string text, string color)
        {
            if (_staticBoard == null)
            {
                return;
            }              
            if (row < 0 || row >= _staticBoard._rows 
                || column < 0 || column >= _staticBoard._cols)
            {
                return;
            }
            _staticBoard._form.SetText(row, column, text, color);
        }

        /// <summary>
        /// Text im Board setzen. 
        /// </summary>
        public static void SetText(int row, int column, string text)
        {
            SetText(row, column, text, "Black");
        }

        /// <summary>
        /// Text aus dem Board zurücklesen
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>String der jeweiligen Zelle</returns>
        public static string GetText(int row, int column)
        {
            if (_staticBoard == null) return null;
            if (row < 0 || row >= _staticBoard._rows || column < 0 || column >= _staticBoard._cols) { return null; }
            return _staticBoard._form.GetText(row, column);
        }

        /// <summary>
        /// Inhalte des Boards löschen
        /// </summary>
        public static void Clear()
        {
            if (_staticBoard == null) return;
            for (int y = 0; y < _staticBoard._rows; y++)
            {
                for (int x = 0; x < _staticBoard._cols; x++)
                {
                    SetText(y, x, "");
                }
            }
        }

        /// <summary>
        /// Entsprechend der Methode GetLength bei Arrays kann auch hier
        /// die Dimension des Boards (0=>Zeilen, 1=>Spalten) abgefragt werden.
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static int GetLength(int dimension)
        {
            if (dimension < 0 || dimension >= 2) { return -1; }
            if (dimension == 0)
            {
                return _staticBoard._rows;
            }
            else
            {
                return _staticBoard._cols;
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
        private TextBox[,] _board;
        private TextBox[] _columnHeader;
        private TextBox[] _rowHeader;
        private Panel _panelBoard;
        private Panel _panelAll;
        private Panel _panelColumnHeader; // null ==> existiert noch nicht
        private Panel _panelRowHeader;
        private readonly int _rows;
        private readonly int _cols;

        public FormBoard(int rows, int cols, string title)
        {
            _rows = rows;
            _cols = cols;
            InitializeComponent();
            Text = title;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Textboxen programmgesteuert auf dem Panel positionieren
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            Text = "FormBoard";
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(292, 266);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(600, 200);
            Name = "FormBoard";
            Text = "FormBoard";
            _board = new TextBox[_rows, _cols];
            _panelAll = new Panel();
            Controls.Add(_panelAll);
            _panelBoard = new Panel
            {
                Width = _cols*CellWidth +10,
                Height = _rows*CellHeight+10
            };
            _panelAll.Controls.Add(_panelBoard);
            TextBox textBox;
            // ColumnHeader
            _panelColumnHeader = new Panel();
            _columnHeader = new TextBox[_cols];
            _panelColumnHeader.Height = CellHeight;
            _panelColumnHeader.Width = _cols * CellWidth;
            for (int col = 0; col < _cols; col++)
            {
                textBox = CreateTextBox(Color.SkyBlue, col.ToString());
                _columnHeader[col] = textBox;
                textBox.Location = new Point(col * CellWidth, 0);
                _panelColumnHeader.Controls.Add(textBox);
            }
            _panelAll.Controls.Add(_panelColumnHeader);
            _panelColumnHeader.Location = new Point(CellWidth, 0);
            // Row-Header
            _panelRowHeader = new Panel();
            _panelRowHeader.Height = _rows * CellHeight;
            _rowHeader = new TextBox[_rows];
            _panelRowHeader.Width = CellWidth;
            for (int row = 0; row < _rows; row++)
            {
                textBox = CreateTextBox(Color.SkyBlue, row.ToString());
                _rowHeader[row] = textBox;
                textBox.Location = new Point(0, row * CellHeight);
                _panelRowHeader.Controls.Add(textBox);
            }
            _panelAll.Controls.Add(_panelRowHeader);
            _panelRowHeader.Location = new Point(0, CellHeight);
            Text = "";
            CreateCells(_rows, _cols);
            _panelBoard.Location = new Point(CellWidth, CellHeight);
            _panelAll.Width = _panelBoard.Width + CellWidth;
            _panelAll.Height = _panelBoard.Height + CellHeight;
            ClientSize = new Size(_panelAll.Width, _panelAll.Height);
            StartPosition = FormStartPosition.Manual;
            SetDesktopLocation(800, 50);

        }

        /// <summary>
        /// Delegate als Parameter zum Verändern der Texte im WinForm
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        private delegate void SetTextDelegate(int row, int col, string text, string color);

        private void SetTextToCellDelegate(int row, int col, string text, string color)
        {
            _board[row, col].Text = text;
            _board[row, col].ForeColor = GetFormsColor(color);
        }

        /// <summary>
        /// Text in Zeile und Spalte schreiben. In Context des Windows-Threads umschalten.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="text"></param>
        public void SetText(int row, int col, string text)
        {
            _board[row, col].Invoke(new SetTextDelegate(SetTextToCellDelegate), row, col, text, "Black");
        }

        /// <summary>
        /// Text in Zeile und Spalte in der entsprechenden Farbe ausgeben
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void SetText(int row, int col, string text, string color)
        {
            _board[row, col].Invoke(new SetTextDelegate(SetTextToCellDelegate), row, col, text, color);
        }

        /// <summary>
        /// Auslesen der Zelle an der gegebenen Position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public string GetText(int row, int col)
        {
            return _board[row, col].Text;
        }

        /// <summary>
        /// Die Felder für das Spielfeld werden erzeugt.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        private void CreateCells(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    CreateCell(row, col);
        }

        /// <summary>
        /// Ein Feld wird erzeugt. Die Position ergibt sich aus Zeile und Spalte. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void CreateCell(int row, int col)
        {
            TextBox textBox = CreateTextBox(Color.White, "");
        textBox.Click += (sender, e) => { Console.WriteLine($"Clicked at {row}/{col}"); };
        _board[row, col] = textBox;
            textBox.Location = new Point(col * CellWidth, row * CellHeight);
            _panelBoard.Controls.Add(textBox);
        }

        /// <summary>
        /// Eine Textbox wird erzeugt
        /// </summary>
        /// <param name="backGround">Hintergrundfarbe</param>
        /// <param name="text">Anzuzeigender Text</param>
        /// <returns></returns>
        private TextBox CreateTextBox(Color backGround, string text)
        {
            TextBox textBox = new TextBox();
            textBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            textBox.Size = new Size(CellWidth, CellHeight);
            textBox.TabStop = false;
            textBox.TextAlign = HorizontalAlignment.Center;
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
    private Color GetFormsColor(string textColor)
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


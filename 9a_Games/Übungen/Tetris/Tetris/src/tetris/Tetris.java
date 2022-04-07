package tetris;

import at.wima.grafx.Grafx;
import at.wima.grafx.GrafxException;
import java.awt.Color;
import java.util.Scanner;

public class Tetris {

    // Konstanten noch erklären
    static final int ROWS = 6;
    static final int COLS = 5;
    static final int CELL_SIZE = 50;

    public static void main(String[] args) throws GrafxException, InterruptedException {
        int[][] board = new int[ROWS][COLS];  // 0 ==> frei
        int stoneColor;  // 1 Blau, 2 Rot, 3 Grün
        int column;
        int counter = 0;

        Scanner scanner = new Scanner(System.in);
        Grafx.createDrawing(COLS * CELL_SIZE, ROWS * CELL_SIZE, Color.white);
        //Grafx.addEllipse("xxx", 0, 0, CELL_SIZE, CELL_SIZE, Color.red, true);

        System.out.println("Tetris");
        System.out.println("======");
        drawGrid();
        do {
                counter++;
        } while (throwsDownStone(board, counter));  // Spalte, in die Stein geworfen wird ist oben noch frei
        System.out.println("Score: " + counter);
    }

    /**
     * Zeichnet das Gitter für das Spielfeld
     */
    private static void drawGrid() throws GrafxException {
        for (int row = 1; row < ROWS; row++) {
            Grafx.addLine(0, CELL_SIZE * row, COLS * CELL_SIZE - 1, CELL_SIZE * row, Color.black);
        }
        for (int col = 1; col < COLS; col++) {
            Grafx.addLine(CELL_SIZE * col, 0, CELL_SIZE * col, CELL_SIZE * ROWS - 1, Color.black);
        }
        Grafx.refresh();

    }

    /**
     * *
     * Der Stein wird in Zeile 0 eingeworfen. Er fällt "langsam" Zeile für Zeile
     * nach unten, bis er auf einen anderen Stein fällt oder am Boden landet.
     * Der Benutzer kann über die Cursortasten die Spalte des Steins verändern.
     * Die zufällige Spalte wird in der Methode erzeugt.
     * Die Steinnummer wird benötigt, um den Stein eindeutig benennen zu können.
     *
     * @param board aktuelle Belegung des Spielfeldes
     * @param stoneNumber Steinnummer zur eindeutigen Identifizierung
     */
    private static boolean throwsDownStone(int[][] board, int stoneNumber) throws GrafxException, InterruptedException {
        int colorNumber = (int) (Math.random() * 3 + 1);
        int column = (int) (Math.random() * COLS);
        int row = 0;
        Color color = null;
        String name = "" + stoneNumber;
        // wenn Spalte nicht voll ==> Stein einwerfen
        if (board[0][column] == 0) {
            stoneNumber++;
            switch (colorNumber) {
                case 1:
                    color = Color.blue;
                    break;
                case 2:
                    color = Color.red;
                    break;
                case 3:
                    color = Color.green;
                    break;
            }
            // Stein setzen und nach unten fallen lassen
            do {
                //überprüfen, ob eine Taste gedrückt ist
                //kontrollieren ob Zielposition frei ist
                //Spalte entsprechend setzen
                char ch = Grafx.getLastKeyDownNoWait();
                if (ch == 'd' && column +1 < COLS && board[row][column+1] == 0){
                    column++;
                }
                if (ch == 's' && column > 0 && board[row][column-1] == 0){
                    column--;
                }
                Grafx.addEllipse(name, CELL_SIZE * column +1, CELL_SIZE * row +1, CELL_SIZE -2, CELL_SIZE-2, color, true);
                Grafx.refresh();
                row++;
                Thread.sleep(500);
            } while (row < ROWS && board[row][column] == 0);
            
            board[row-1][column]= colorNumber;
            
            return true; // Stein wurde gesetzt
        }
        else{
            return false; // Spalte war schon komplett belegt
        }

    }

}

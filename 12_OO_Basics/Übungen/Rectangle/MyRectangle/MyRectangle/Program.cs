using System;

namespace MyRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle[] rectangles = new Rectangle[5];
            rectangles[0] = new Rectangle(4, 2, ConsoleColor.Blue, 5, 5);
            rectangles[1] = new Rectangle(5, 3, ConsoleColor.Red, 16, 10);
            rectangles[2] = new Rectangle(8, 5, ConsoleColor.Cyan, 50, 8);
            rectangles[3] = new Rectangle(4, 4, ConsoleColor.White, 48, 7);
            rectangles[4] = new Rectangle(10, 7, ConsoleColor.Green, 50, 8);

            Draw(rectangles);

            string input = GetInput();
            while (input != "")
            {
                switch (input.ToLower())
                {
                    case ("r"):
                        for (int i = 0; i < rectangles.Length; i++)
                        {
                            rectangles[i].Rotate();
                        }
                        break;
                    case ("s"):
                        for (int i = 0; i < rectangles.Length; i++)
                        {
                            rectangles[i].Scale(2);
                        }
                        break;

                    case ("sort"):
                        Sort(rectangles);
                        break;
                    default: break;
                }
                Draw(rectangles);
                input = GetInput();
            }
         }

        private static string GetInput()
        {
            Console.SetCursorPosition(0, 24);
            Console.Write("Skalieren (s), Rotieren (r), Sortieren (sort)? ");
            string input = Console.ReadLine();
            return input;
        }

        private static void Draw(Rectangle[] rect)
        {
            Console.Clear();
            for (int i = 0; i < rect.Length; i++)
            {
                rect[i].Draw();
            }
        }

        private static void Sort(Rectangle[] rect)
        {
            for (int left = 0; left < rect.Length - 1; left++)
            {
                for (int right = left + 1; right < rect.Length; right++)
                {
                    if (rect[left].CompareTo(rect[right]) == -1)
                    {
                        Rectangle temp = rect[left];
                        rect[left] = rect[right];
                        rect[right] = temp;
                    }
                }
            }
        }
    }
}


namespace Tetris
{
	internal class Program
	{
		//static bool isPieceLanded = false;
		static int xLine = 12;
		static int yLine = 8;
		static char pieceSymbol = 'X';
		static List<int> fullLines = [];
		static int score = 0;
		static ConsoleKeyInfo input;
		static char[,] field = new char[xLine, yLine];
		static Piece piece;

		static void Main(string[] args)
		{
			Console.WriteLine("Hello, Tetris!");

			Console.CursorVisible = false;
			var random = new Random();

			piece = new(1, random.Next(1, yLine - 1));

			CreateMatrixBase();

			Task.Run(() => InputListener());

			while (true)
			{
				if (field[piece.Xposition + 1, piece.Yposition] == '*' || field[piece.Xposition + 1, piece.Yposition] == pieceSymbol)
				{
					//isPieceLanded = true;
					GetFullLines();
					piece = new(1, random.Next(1, yLine - 1));
					//isPieceLanded = false;
					if (fullLines.Count > 0)
					{
						DeleteLines();
						fullLines = [];
					}
				}
				else
				{
					field[piece.Xposition, piece.Yposition] = ' ';
					piece.Xposition++;
				}

				FillMatrix();
				PrintMatrix();
				Console.WriteLine($"SCORE: {score}");

				Console.SetCursorPosition(0, 1);

				Task.Delay(500).Wait();
			}
		}

		private static void InputHandler()
		{
			if (input.Key == ConsoleKey.LeftArrow && piece.Yposition > 1)
			{
				field[piece.Xposition, piece.Yposition] = ' ';
				piece.Yposition = piece.Yposition - 1;
			}
			if (input.Key == ConsoleKey.RightArrow && piece.Yposition < yLine - 2)
			{
				field[piece.Xposition, piece.Yposition] = ' ';
				piece.Yposition = piece.Yposition + 1;
			}
			if (input.Key == ConsoleKey.DownArrow && piece.Xposition < xLine - 2)
			{
				field[piece.Xposition, piece.Yposition] = ' ';
				piece.Xposition = piece.Xposition + 1;
			}
			
			FillMatrix();
			PrintMatrix();
			
			Console.SetCursorPosition(0, 1);
			//Task.Delay(50).Wait();
		}

		private static void FillMatrix()
		{
			field[piece.Xposition, piece.Yposition] = pieceSymbol;
		}

		private static void DeleteLines()
		{
			foreach (var line in fullLines)
			{
				for (int i = 1; i < yLine - 1; i++)
				{
					field[line, i] = ' ';
				}
				score += 50;
				MoveOtherPiecesDown(line - 1);
			}
		}

		private static void MoveOtherPiecesDown(int line)
		{
			for (int x = line; x > 0; x--)
			{
				for (int y = 0; y < yLine; y++)
				{
					if (field[x, y] == pieceSymbol)
					{
						field[x + 1, y] = pieceSymbol;
						field[x, y] = ' ';
					}
				}
			}
		}

		private static void GetFullLines()
		{
			for (int i = 1; i < xLine - 1; i++)
			{
				bool[] result = new bool[yLine - 2];
				for (int y = 1; y < yLine - 1; y++)
				{
					if (field[i, y] == pieceSymbol)
					{
						result[y - 1] = true;
					}
					else
					{
						break;
					}
				}

				if (result.All(r => r))
				{
					fullLines.Add(i);
				}
			}
		}

		private static void CreateMatrixBase()
		{
			for (int x = 0; x < xLine; x++)
			{
				for (int y = 0; y < yLine; y++)
				{
					if (x == 0 || x == xLine - 1)
					{
						field[x, y] = '*';
					}
					else
					{
						field[x, y] = y == 0 || y == yLine - 1 ? '*' : ' ';
					}
				}
			}
		}		

		private static void PrintMatrix()
		{
			// Print the populated matrix
			for (int i = 0; i < field.GetLength(0); i++)
			{
				for (int j = 0; j < field.GetLength(1); j++)
				{
					Console.Write(field[i, j]); // Print each element
				}
				Console.WriteLine(); // New line after each row
			}
		}

		static void InputListener()
		{
			while (true)
			{
				// Get input
				input = Console.ReadKey(true);
				InputHandler(); // Call InputHandler
				input = new ConsoleKeyInfo();
			}
		}


		private class Piece(int x, int y)
		{
			public int Xposition { get; set; } = x;
			public int Yposition { get; set; } = y;
		}

		//private static void PopulateMatrix(Piece piece)
		//{
		//	char prevXValue = field[piece.Xposition - 1, piece.Yposition];
		//	field[piece.Xposition - 1, piece.Yposition] = prevXValue == '*' ? '*' : ' ';
		//	field[piece.Xposition, piece.Yposition] = pieceSymbol;
		//	char nextXValue = field[++piece.Xposition, piece.Yposition];

		//	isPieceLanded = nextXValue == '*' || nextXValue == pieceSymbol;
		//}

	}
}

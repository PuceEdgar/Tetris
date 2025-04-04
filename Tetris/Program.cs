


namespace Tetris
{
	internal class Program
	{
		static bool isPieceLanded = false;
		static int xLine = 12;
		static int yLine = 8;
		static char pieceSymbol = 'X';


		static char[,] field = new char[xLine, yLine];
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, Tetris!");


			Console.CursorVisible = false;
			var random = new Random();

			Piece piece = new(1, random.Next(1, yLine-1));

			CreateMatrixBase();

			Timer gameTimer = new Timer(x =>
			{
				if (isPieceLanded)
				{
					piece = new(1, random.Next(1, yLine-1));
					isPieceLanded = false;
				}

				PopulateMatrix(ref piece);
				PrintMatrix(field);
				Console.SetCursorPosition(0, 1);


			}, null, 1000, 1000);




			Console.ReadLine();
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

		private static void PopulateMatrix(ref Piece piece)
		{
			char prevXValue = field[piece.Xposition - 1, piece.Yposition];
			field[piece.Xposition - 1, piece.Yposition] = prevXValue == '*' ? '*' : ' ';
			field[piece.Xposition, piece.Yposition] = pieceSymbol;
			char nextXValue = field[++piece.Xposition, piece.Yposition];

			isPieceLanded = nextXValue == '*' || nextXValue == pieceSymbol;

			//else
			//{
			//	field[piece.Xposition, piece.Yposition] = piece.Symbol;
			//}
		}

		private static void PrintMatrix(char[,] field)
		{
			// Print the populated matrix
			for (int i = 0; i < field.GetLength(0); i++)
			{
				for (int j = 0; j < field.GetLength(1); j++)
				{
					Console.Write(field[i, j]); // Print each element with tab separation
				}
				Console.WriteLine(); // New line after each row
			}
		}


		private struct Piece(int x, int y)
		{
			public int Xposition { get; set; } = x;
			public int Yposition { get; set; } = y;
		}

	}
}


global using static Tetris.Constants;

namespace Tetris
{
	internal class Program
	{
		static bool isPieceLanded = false;
		static int xLine = 15;
		static int yLine = 10;
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

			piece = new(1, 6, GetShape(random.Next(6, 6)));

			CreateMatrixBase();

			Task.Run(() => InputListener());

			while (true)
			{
				//|| field[piece.Xposition + 1, piece.Yposition] == landedPieceSymbol
				if (IsDownCollision())
				{
					isPieceLanded = true;
					GetFullLines();
					//piece = new(1, random.Next(1, yLine - 1), new OShape());
					
					if (fullLines.Count > 0)
					{
						DeleteLines();
						fullLines = [];
					}

					//FillMatrix();
					//PrintMatrix();
					//Console.WriteLine($"SCORE: {score}");
					piece = new(1, 6, GetShape(random.Next(6, 6)));
					//Console.SetCursorPosition(0, 1);
				}
				else
				{
					isPieceLanded= false;
					//field[piece.Xposition, piece.Yposition] = ' ';
					//piece.Xposition++;
					MoviePieceDown();

					
				}

				FillMatrix();
				PrintMatrix();
				Console.WriteLine($"SCORE: {score}");

				Console.SetCursorPosition(0, 1);

				Task.Delay(500).Wait();
			}
		}

		private static bool IsDownCollision()
		{
			bool isCollision = false;
			for (int i = 0; i < piece.Shape.CurrentShape.GetLength(0); i++)
			{
				for (int j = 0; j < piece.Shape.CurrentShape.GetLength(1); j++)
				{
					if (field[piece.Xposition + i, piece.Yposition + j] != EmptySpace && (
						field[piece.Xposition + i + 1, piece.Yposition + j] == LandedPiecePattern 
						|| field[piece.Xposition + i + 1, piece.Yposition + j] == Border)
						)
					{
						isCollision = true;
						break;
					}
					//if (field[piece.Xposition + piece.Shape.CurrentShape.GetLength(0), piece.Yposition] == '*' 
					//	|| field[piece.Xposition + piece.Shape.CurrentShape.GetLength(0), piece.Yposition] == landedPieceSymbol						
					//	)
					//{
					//	isCollision = true;
					//	break;
					//}
				}
			}
			//return field[piece.Xposition + piece.Shape.CurrentShape.Rank, piece.Yposition] == '*' || field[piece.Xposition + piece.Shape.CurrentShape.Rank, piece.Yposition] == landedPieceSymbol;

			return isCollision;
		}

		private static void MoviePieceDown()
		{
			ClearPreviousPosition();
			piece.Xposition++;
		}

		private static void ClearPreviousPosition()
		{
			for (int i = 0; i < piece.Shape.CurrentShape.GetLength(0); i++)
			{
				for (int j = 0; j < piece.Shape.CurrentShape.GetLength(1); j++)
				{
					field[piece.Xposition + i, piece.Yposition + j] = ' ';
				}
			}
		}

		private static void InputHandler()
		{

			if (input.Key == ConsoleKey.LeftArrow && field[piece.Xposition, piece.Yposition - 1] == ' ')
			{
				ClearPreviousPosition();
				//field[piece.Xposition, piece.Yposition] = ' ';
				piece.Yposition = piece.Yposition - 1;
			}
			if (input.Key == ConsoleKey.RightArrow && field[piece.Xposition, piece.Yposition + piece.Shape.CurrentShape.GetLength(1)] == ' ')
			{
				ClearPreviousPosition();
				//field[piece.Xposition, piece.Yposition] = ' ';
				piece.Yposition = piece.Yposition + 1;
			}
			if (input.Key == ConsoleKey.DownArrow && field[piece.Xposition + piece.Shape.CurrentShape.GetLength(0), piece.Yposition] == ' ')
			{
				ClearPreviousPosition();
				//field[piece.Xposition, piece.Yposition] = ' ';
				piece.Xposition = piece.Xposition + 1;
			}
			if (input.Key == ConsoleKey.R)
			{
				ClearPreviousPosition();
				piece.Shape.Direction = NextDirection();
			}

			//FillMatrix();
			//PrintMatrix();

			//Console.SetCursorPosition(0, 1);

			//Task.Delay(50).Wait();
		}

		private static PieceDirection NextDirection()
		{
			PieceDirection newDirection = PieceDirection.UP;
			switch (piece.Shape.Direction)
			{
				case PieceDirection.UP:
					newDirection =  PieceDirection.LEFT;
					break;
				case PieceDirection.LEFT:
					newDirection = PieceDirection.DOWN;
					break;
				case PieceDirection.DOWN:
					newDirection = PieceDirection.RIGHT;
					break;
				case PieceDirection.RIGHT:
					newDirection = PieceDirection.UP;	
					break;
			}
			return newDirection;
		}

		private static void FillMatrix()
		{
			for (int i = 0; i < piece.Shape.CurrentShape.GetLength(0); i++)
			{				
				for (int j = 0; j < piece.Shape.CurrentShape.GetLength(1); j++)
				{
					if (isPieceLanded)
					{
						
							field[piece.Xposition + i, piece.Yposition + j] = 
							piece.Shape.CurrentShape[i, j] == MovingPiecePattern ? LandedPiecePattern : 
							field[piece.Xposition + i, piece.Yposition + j] == LandedPiecePattern ? LandedPiecePattern : EmptySpace;
						
						
					}
					else
					{
						
							field[piece.Xposition + i, piece.Yposition + j] = field[piece.Xposition + i, piece.Yposition + j] == EmptySpace ? piece.Shape.CurrentShape[i, j] : field[piece.Xposition + i, piece.Yposition + j];
						
							
					}
					
				}
			}
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
					if (field[x, y] == LandedPiecePattern)
					{
						field[x + 1, y] = LandedPiecePattern;
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
					if (field[i, y] == LandedPiecePattern)
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


		private class Piece(int x, int y, IPieceShape pieceShape)
		{
			public int Xposition { get; set; } = x;
			public int Yposition { get; set; } = y;
			public IPieceShape Shape { get; set; } = pieceShape;
		}

		//private static void PopulateMatrix(Piece piece)
		//{
		//	char prevXValue = field[piece.Xposition - 1, piece.Yposition];
		//	field[piece.Xposition - 1, piece.Yposition] = prevXValue == '*' ? '*' : ' ';
		//	field[piece.Xposition, piece.Yposition] = landedPieceSymbol;
		//	char nextXValue = field[++piece.Xposition, piece.Yposition];

		//	isPieceLanded = nextXValue == '*' || nextXValue == landedPieceSymbol;
		//}

	}
}

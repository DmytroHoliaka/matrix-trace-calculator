namespace MatrixTrace
{
    public class Program
    {
        public static void Main(string[] _)
        {
            try
            {
                (int rows, int columns) = GetMatrixDemention();

                MatrixHandler m = new(rows, columns);
                m.FillMatrix();
                Console.WriteLine();

                m.PrintMatrix();
                Console.WriteLine();

                Console.WriteLine($"[Matrix trace] {m.GetMatrixTrace()}");
                Console.WriteLine($"[Matrix snail] {SnailMatrixFinder.GetMatrixSnail(m.Matrix)}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"[ArgumentNullException] {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[ArgumentOutOfRangeException] {ex.Message}");
            }
        }

        private static (int, int) GetMatrixDemention()
        {
            Console.Write("Enter amount of rows: ");
            int rows = DataParser.GetPositiveInt(Console.ReadLine());

            Console.Write("Enter amount of columns: ");
            int columns = DataParser.GetPositiveInt(Console.ReadLine());

            return (rows, columns);
        }
    }
}
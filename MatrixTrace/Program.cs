namespace MatrixTrace
{
    public class Program
    {
        public static void Main(string[] _)
        {
            try
            {
                MatrixHandler m = new();
                m.FillMatrix();
                Console.WriteLine();

                m.PrintMatrix();
                Console.WriteLine();

                Console.WriteLine($"[Matrix trace] {MatrixTraceFinder.GetMatrixTrace(m.Matrix)};");
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
    }
}
namespace Labs2;

class PrintMatrix
{
    static void Main(string[] args)
    {
        float[,] coff = new float[,]
        {
            { 5, 2.833333f, 1 },
            { 3, 1.7f, 7 },
            { 1, 8, 1 }
        };
        float[,] b = new float[,]
        {
            { 11.666666f },
            { 13.4f },
            { 18 }
        };
        float[,] coff1 = new float[,]
        {
            { 1, 1, 15 },
            { 15, 0, 1 },
            { 4, 15, 1 }
        };
        float[,] b1 = new float[,]
        {
            { 17 },
            { 16 },
            { 20 }
        };
        float[,] coff1Mod =
        {
            { 15f, 0, 1f },
            { 4, 15, 1f },
            { 1f, 1f, 15f }
        };

        float[,] b1Mod = { { 16 }, { 20 }, { 17 } };
        float[,] coff2 = new float[,]
        {
            { 6.25f, -1, 0.5f },
            { -1, 5, 2.12f },
            { 0.5f, 2.12f, 3.6f }
        };
        float[,] b2 = new float[,]
        {
            { 7.5f },
            { -8.68f },
            { -0.24f }
        };
        float[,] coff3 = new float[,]
        {
            { 5, 3, 0 },
            { 4, 3, 1 },
            { 0, 1, 2 }
        };
        float[,] b3 = new float[,]
        {
            { 2 },
            { 8 },
            { 10 }
        };
        float[,] coff4 = new float[,]
        {
            { 2, 4, 8, 16, 32 },
            { 4, 16, 64, 256, 1024 },
            { 5, 25, 125, 625, 3125 },
            { 6, 36, 216, 1296, 7776 },
            { 7, 49, 343, 2401, 16807 }
        };
        float[,] b4 = new float[,]
        {
            { 6 },
            { 6 },
            { 1 },
            { -1 },
            { 11 }
        };
        //GaussianMethod gaussianMethod = new GaussianMethod();
        GaussianMethodWithMainElement gaussianMethodWithMainElement = new GaussianMethodWithMainElement();
        Print(gaussianMethodWithMainElement.FindRoot(coff4, b4));
        //     SimpleIterationMethod simpleIterationMethod = new SimpleIterationMethod(0.00001f);
        //     ThreeDiagonalMatrixAlgorithm threeDiagonalMatrixAlgorithm = new ThreeDiagonalMatrixAlgorithm();
        //     try
        //     {
        //         PrintMatrix(gaussianMethod.FindRoot(coff, b));
        //         PrintMatrix(simpleIterationMethod.FindRoot(coff, b));
        //     }
        //     catch (DivideByZeroException e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //     PrintMatrix(gaussianMethodWithMainElement.FindRoot(coff,b));
        //     try
        //     {
        //         PrintMatrix(gaussianMethod.FindRoot(coff1, b1));
        //         PrintMatrix(simpleIterationMethod.FindRoot(coff1Mod,b1Mod));
        //     }
        //     catch (DivideByZeroException e)
        //     {
        //         Console.WriteLine(e);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //     PrintMatrix(gaussianMethodWithMainElement.FindRoot(coff1,b1));
        //     PrintMatrix(gaussianMethodWithMainElement.FindRoot(coff2,b2));
        //     // PrintMatrix(simpleIterationMethod.FindRoot(coff2,b2));
        //     // PrintMatrix(gaussianMethodWithMainElement.FindRoot(coff3,b3));
        //     PrintMatrix(coff3);
        //     PrintMatrix(threeDiagonalMatrixAlgorithm.FindRoot(coff3,b3));
        // }
    }

    public static void Print(float[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(String.Format("{0,20:0.0000000}",matrix[i,j])+"   ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("_________________________________________________________________________________________");
    }
}
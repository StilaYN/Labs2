namespace Labs2;

public class GaussianMethodWithMainElement
{
    public float[,] FindRoot(float[,] coefficientsMatrix, float[,] b)
    {
        var matrix = new float[coefficientsMatrix.GetLength(0), coefficientsMatrix.GetLength(1) + 1];
        for (int i = 0; i < coefficientsMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < coefficientsMatrix.GetLength(1); j++)
            {
                matrix[i, j] = coefficientsMatrix[i, j];
            }
            matrix[i, coefficientsMatrix.GetLength(1)] = b[i, 0];
        }
        FindDiagonalMatrix(matrix);
        return FindRootMatrix(matrix);
    }
    private float[,] FindRootMatrix(float[,] diagonalMatrix)
    {
        float[,] rootMatrix = new float[diagonalMatrix.GetLength(0),1];
        for (int i = rootMatrix.GetLength(0)-1; i>=0; i--)
        {
            float summ = 0;
            for (int j = i+1; j < rootMatrix.GetLength(0); j++)
            {
                summ += diagonalMatrix[i, j]*rootMatrix[j,0];
            }
            rootMatrix[i, 0] = diagonalMatrix[i, diagonalMatrix.GetLength(1) - 1]-summ;

        }
        return rootMatrix;
    }
    private void FindDiagonalMatrix(float[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Swipe(matrix,i,FindIndexRowWithMaxElement(matrix,i,i));
            ExcludeUnknown(matrix,i,i);
        }
    }

    private void ExcludeUnknown(float[,] matrix,int startRowIndex, int startColumnIndex)
    {
        var first = matrix[startRowIndex, startColumnIndex];
        for (int j = startColumnIndex; j < matrix.GetLength(1); j++)
        {
            matrix[startRowIndex, j] /= first;
        }
        for (var i = startRowIndex + 1; i < matrix.GetLength(0); i++)
        {
            float coefficient = matrix[i, startColumnIndex];
            for (int j = startColumnIndex; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] -= coefficient * matrix[startRowIndex, j];
            }
        }
    }

    private void Swipe(float[,] matrix, int indexFirstRow, int indexSecondRow)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            (matrix[indexFirstRow, i], matrix[indexSecondRow, i]) = (matrix[indexSecondRow, i], matrix[indexFirstRow, i]);
        }
    }

    private int FindIndexRowWithMaxElement(float[,] matrix, int startRowIndex, int startColumnIndex)
    {
        int indexRow = startRowIndex;
        float maxElement = matrix[startRowIndex, startColumnIndex];
        for (int i = startRowIndex; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, startColumnIndex] > maxElement)
            {
                indexRow = i;
                maxElement = matrix[i, startColumnIndex];
            }
        }

        return indexRow;
    }
}
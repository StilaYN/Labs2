namespace Labs2;

public class SimpleIterationMethod
{
    private float _e;

    public SimpleIterationMethod(float e = 0.001f)
    {
        _e = e;
    }

    public float[,] FindRoot(float[,] coefficientsMatrix, float[,] b)
    {
        if (!CanMethodUsed(coefficientsMatrix))
            throw new Exception("Метод простых итераций не применим, не соблюдены условия сходимости\n" +
                                "_________________________________________________________________________________________");
        var modifiedCoefficientMatrix = new float[coefficientsMatrix.GetLength(0), coefficientsMatrix.GetLength(1)];
        var modifiedBetaMatrix = new float[b.GetLength(0), b.GetLength(1)];
        var rootMatrix = new float[b.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < coefficientsMatrix.GetLength(0); i++)
        {
            var coefficient = coefficientsMatrix[i, i];
            for (int j = 0; j < coefficientsMatrix.GetLength(1); j++)
            {
                if (i != j) modifiedCoefficientMatrix[i, j] = -coefficientsMatrix[i, j] / coefficient;
                else modifiedCoefficientMatrix[i,j] = 0;
            }
            modifiedBetaMatrix[i, 0] = b[i, 0] / coefficient;
            rootMatrix[i, 0] = modifiedBetaMatrix[i, 0];
        }

        return FindRootMatrix(modifiedCoefficientMatrix, modifiedBetaMatrix,
            rootMatrix);
    }

    private float[,] FindRootMatrix(float[,] modifiedCoefficientsMatrix,
        float[,] modifiedBetaMatrix, float[,] oldRootMatrix)
    {
        var newRootMatrix = new float[oldRootMatrix.GetLength(0), oldRootMatrix.GetLength(1)];

        while (true)
        {
            for (int i = 0; i < modifiedCoefficientsMatrix.GetLength(0); i++)
            {
                var sum = modifiedBetaMatrix[i, 0];
                for (int j = 0; j < modifiedCoefficientsMatrix.GetLength(1); j++)
                {
                    sum += modifiedCoefficientsMatrix[i, j] * oldRootMatrix[j, 0];
                }

                newRootMatrix[i, 0] = sum;
            }

            if (IsEnd(oldRootMatrix, newRootMatrix)) break;
            else
            {
                for (int i = 0; i < oldRootMatrix.GetLength(0); i++)
                {
                    oldRootMatrix[i, 0] = newRootMatrix[i, 0];
                }
            }
        }

        return newRootMatrix;
    }

    private bool CanMethodUsed(float[,] coefficientsMatrix)
    {
        bool canUsedByRow = true;
        bool canUsedByColumm = true;
        for (int i = 0; i < coefficientsMatrix.GetLength(0); i++)
        {
            float sum = 0;
            for (int j = 0; j < coefficientsMatrix.GetLength(1); j++)
            {
                if (i != j) sum+=coefficientsMatrix[i,j];
            }

            if (sum > Math.Abs(coefficientsMatrix[i, i])) canUsedByRow = false;
        }
        for (int i = 0; i < coefficientsMatrix.GetLength(0); i++)
        {
            float sum = 0;
            for (int j = 0; j < coefficientsMatrix.GetLength(1); j++)
            {
                if (i != j) sum+=coefficientsMatrix[j,i];
            }

            if (sum > Math.Abs(coefficientsMatrix[i, i])) canUsedByColumm = false;
        }
        return canUsedByRow||canUsedByColumm;
    }

    private bool IsEnd(float[,] oldRootMatrix, float[,] newRootMatrix)
    {
        for (int i = 0; i < oldRootMatrix.GetLength(0); i++)
        {
            if (Math.Abs(oldRootMatrix[i, 0] - newRootMatrix[i, 0]) > _e) return false;
        }

        return true;
    }
}
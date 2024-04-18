namespace Labs2;

public class ThreeDiagonalMatrixAlgorithm
{
    public float[,] FindRoot(float[,] coefficientsMatrix, float[,] b)
    {
        (float[,] directCourseMatrix, float[,] directCourseBetaMatrix) = DirectCourse(coefficientsMatrix, b);
        return ReverseCourse(coefficientsMatrix,directCourseMatrix, directCourseBetaMatrix);
    }

    private (float[,], float[,]) DirectCourse(float[,] coefficientsMatrix, float[,] b)
    {
        float alfaOld = coefficientsMatrix[0,1]/coefficientsMatrix[0,0];
        float betaOld = b[0,0]/coefficientsMatrix[0,0];
        var directCourseMatrix = new float[coefficientsMatrix.GetLength(0), coefficientsMatrix.GetLength(1)];
        var directCourseBetaMatrix = new float[b.GetLength(0), b.GetLength(1)];
        directCourseMatrix[0, 0] = coefficientsMatrix[0, 0];
        directCourseBetaMatrix[0, 0] = b[0, 0];
        for (var i = 1; i < coefficientsMatrix.GetLength(0)-1; i++)
        {
            directCourseMatrix[i, i] = coefficientsMatrix[i, i] - coefficientsMatrix[i, i - 1]*alfaOld;
            directCourseBetaMatrix[i, 0] = b[i, 0] - coefficientsMatrix[i, i - 1] * betaOld;
            alfaOld = coefficientsMatrix[i, i + 1] / directCourseMatrix[i, i];
            betaOld = directCourseBetaMatrix[i, 0] / directCourseMatrix[i, i];
        }
        directCourseMatrix[coefficientsMatrix.GetLength(0)-1, coefficientsMatrix.GetLength(0)-1] = 
            coefficientsMatrix[coefficientsMatrix.GetLength(0)-1, coefficientsMatrix.GetLength(0)-1]
            - coefficientsMatrix[coefficientsMatrix.GetLength(0)-1, coefficientsMatrix.GetLength(0)-1 - 1]*alfaOld;
        directCourseBetaMatrix[coefficientsMatrix.GetLength(0)-1, 0] =
            b[coefficientsMatrix.GetLength(0)-1, 0] 
            - coefficientsMatrix[coefficientsMatrix.GetLength(0)-1, coefficientsMatrix.GetLength(0)-1 - 1] * betaOld;
        return (directCourseMatrix, directCourseBetaMatrix);
    }

    private float[,] ReverseCourse(float[,] coefficientMatrix, float[,] directMatrix, float[,] b)
    {
        float x = b[b.GetLength(0)-1,0]/directMatrix[directMatrix.GetLength(0)-1,directMatrix.GetLength(0)-1];
        var roots = new float[b.GetLength(0), b.GetLength(1)];
        roots[b.GetLength(0)-1, 0] = x;
        for (int i = b.GetLength(0)-2; i >= 0; i--)
        {
            roots[i, 0] = b[i, 0]/directMatrix[i,i] - x * coefficientMatrix[i, i + 1]/directMatrix[i,i];
            x = roots[i, 0];
        }
        return roots;
    }

}
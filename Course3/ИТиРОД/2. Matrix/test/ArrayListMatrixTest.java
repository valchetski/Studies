import matrix.ArrayListMatrix;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;


public class ArrayListMatrixTest
{

    //lOGGER -- класс для работы логами
    private static Logger logger = Logger.getLogger(ArrayListMatrix.class);
    private ArrayListMatrix identityMatrix;
    private ArrayListMatrix zeroMatrix;
    private ArrayListMatrix randomMatrix;
    private ArrayListMatrix largeMatrix1;
    private ArrayListMatrix largeMatrix2;

    @Before
    public void Initialize()
    {
        int size = 3;
        identityMatrix = createIdentityMatrix(size);//единичная матрица
        zeroMatrix = ArrayListMatrix.GetZeroMatrix(size, size); //нулевая матрица
        randomMatrix = new ArrayListMatrix(size, size);//произвольная матрица
        largeMatrix1 = new ArrayListMatrix(100, 10);//произвольная матрица
        largeMatrix2 = new ArrayListMatrix(10, 100);//произвольная матрица
    }

    @Test
    public void testMultiplyMatrix() throws Throwable
    {
        logger.info("Test started: Multiplication ArrayListMatrix");
        try
        {
            //умножаю нулевую матрицу на рандомную
            logger.info(String.format("\n%s\n*\n%s\n=\n%s", zeroMatrix, randomMatrix, zeroMatrix.Multiplication(randomMatrix)));
            Assert.assertEquals(zeroMatrix, zeroMatrix.Multiplication(randomMatrix));

            //умножаю единичную матрицу на рандомную
            logger.info(String.format("\n%s\n*\n%s\n=\n%s", identityMatrix, randomMatrix, identityMatrix.Multiplication(randomMatrix)));
            Assert.assertEquals(randomMatrix, identityMatrix.Multiplication(randomMatrix));

            logger.info(String.format("\n%s\n*\n%s\n=\n%s", largeMatrix1, largeMatrix2, largeMatrix1.Multiplication(largeMatrix2)));
            logger.info("Test passed\n");
        }
        catch (Throwable e)
        {
            logger.error("Test failed. " + e.toString());
            throw e;
        }

    }

    private ArrayListMatrix createIdentityMatrix(int size)
    {
        ArrayListMatrix result = ArrayListMatrix.GetZeroMatrix(size, size);
        for (int i = 0; i < size; i++)
        {
            result.get(i).set(i, 1.0);
        }
        return result;
    }
}

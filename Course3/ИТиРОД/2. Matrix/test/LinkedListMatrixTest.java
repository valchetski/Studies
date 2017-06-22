import matrix.LinkedListMatrix;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class LinkedListMatrixTest
{
    private static Logger logger = Logger.getLogger(LinkedListMatrix.class);
    private LinkedListMatrix identityMatrix;
    private LinkedListMatrix zeroMatrix;
    private LinkedListMatrix randomMatrix;
    private LinkedListMatrix largeMatrix1;
    private LinkedListMatrix largeMatrix2;

    //этод метод будет выполнятся перед тестами. тут происходит инициализация матриц
    @Before
    public void Initialize()
    {
        int size = 3;
        identityMatrix = createIdentityMatrix(size);//единичная матрица
        zeroMatrix = LinkedListMatrix.GetZeroMatrix(size, size); //нулевая матрица
        randomMatrix = new LinkedListMatrix(size, size);//произвольная матрица
        largeMatrix1 = new LinkedListMatrix(100, 10);//произвольная матрица
        largeMatrix2 = new LinkedListMatrix(10, 100);//произвольная матрица
    }


    @Test
    public void testMultiplyMatrix()
    {
        try
        {
            logger.info("Test started: Multiplication LinkedListMatrix");

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

    private LinkedListMatrix createIdentityMatrix(int size)
    {
        LinkedListMatrix result = LinkedListMatrix.GetZeroMatrix(size, size);
        for (int i = 0; i < size; i++)
        {
            result.get(i).set(i, 1.0);
        }
        return result;
    }
}

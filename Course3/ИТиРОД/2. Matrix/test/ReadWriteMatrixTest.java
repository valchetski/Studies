import matrix.ArrayListMatrix;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.io.File;

public class ReadWriteMatrixTest
{
    private static Logger logger = Logger.getLogger(ArrayListMatrix.class);
    private ArrayListMatrix testMatrix;

    @Before
    public void Initialize()
    {
        testMatrix = ArrayListMatrix.GetZeroMatrix(3, 3);
        testMatrix.get(0).set(0, 2.0);
        testMatrix.get(1).set(2, 5.0);
        testMatrix.get(2).set(1, 7.0);
    }

    @Test
    public void testMatrixReader()
    {
        String tempFilePath = "testMatrix.txt";
        testMatrix.Save(tempFilePath);
        logger.info("Test started: Read matrix from file");
        try
        {
            logger.info("Source matrix: \n" + testMatrix);
            logger.info("Matrix from file: \n" + ArrayListMatrix.ReadFromFile(tempFilePath));
            Assert.assertEquals(testMatrix, ArrayListMatrix.ReadFromFile(tempFilePath));
            logger.info("Test passed");
        }
        catch (Throwable e)
        {
            logger.error("Test failed" + e.toString());
            throw e;
        }
        finally
        {
            new File(tempFilePath).delete();
        }
    }
}

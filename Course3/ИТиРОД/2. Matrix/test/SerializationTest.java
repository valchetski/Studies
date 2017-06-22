import matrix.ArrayListMatrix;
import matrix.LinkedListMatrix;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.io.File;

public class SerializationTest
{
    private static Logger logger = Logger.getLogger(ArrayListMatrix.class);
    private LinkedListMatrix testMatrix;

    @Before
    public void Initialize()
    {
        testMatrix = LinkedListMatrix.GetZeroMatrix(3, 3);
        testMatrix.get(0).set(0, 2.0);
        testMatrix.get(1).set(2, 5.0);
        testMatrix.get(2).set(1, 7.0);
    }

    @Test
    public void testMatrixSerialize()
    {
        logger.info("Test started: Serialization of matrix");
        String tempFilePath = "testMatrix.txt";
        try
        {
            logger.info("Source matrix: \n" + testMatrix);
            testMatrix.Serialize(tempFilePath);
            LinkedListMatrix matrixFromFile = testMatrix.Deserialize(tempFilePath);
            Assert.assertEquals(testMatrix, matrixFromFile);

            logger.info("Deserialized matrix: \n" + matrixFromFile);
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

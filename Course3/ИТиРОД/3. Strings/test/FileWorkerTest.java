import file.FileWorker;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.io.File;
import java.io.FileWriter;
import java.util.HashMap;
import java.util.Map;

public class FileWorkerTest
{
    private static Logger logger = Logger.getLogger(FileWorker.class);
    private final String tempFilePath = "tempFile.txt";
    private Map<Character, Integer> textStatistics;

    @Before
    public void createTextFile()
    {
        textStatistics = new HashMap<Character, Integer>();
        textStatistics.put('a', 3);
        textStatistics.put('b', 2);
        textStatistics.put('c', 1);

        try
        {
            String text = createTextFromStatistic();

            FileWriter f = new FileWriter(tempFilePath);
            f.write(text);
            f.close();
        }
        catch (Exception e)
        {
            logger.error("Fail before test: can not create temp file");
        }
    }

    @Test
    public void testFile() throws Throwable {
        logger.info("Test started: Get statistic of letters usage");
        try
        {
            logger.info("Source text: \n" + createTextFromStatistic());
            HashMap<Character, Integer> statisticFromFile = FileWorker.GetStatisticInHashMap(tempFilePath);
            Assert.assertEquals(textStatistics, statisticFromFile);
            logger.info("Statistics: \n" + FileWorker.GetStatistic(tempFilePath));
            logger.info("Test passed");
        }
        catch (Throwable e)
        {
            logger.error("Test failed");
            throw e;
        }
        finally
        {
            new File(tempFilePath).delete();
        }

    }

    private String createTextFromStatistic() {
        String result = "";
        for (Map.Entry<Character, Integer> entry: textStatistics.entrySet())
        {
            for (int i = 0; i < entry.getValue(); i++)
            {
                result += entry.getKey();
            }
        }
        return result;
    }
}

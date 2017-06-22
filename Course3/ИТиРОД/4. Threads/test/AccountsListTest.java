import bank.Account;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import main.AccountsList;

import java.math.BigDecimal;
import java.util.UUID;

public class AccountsListTest
{

    private static final Logger LOGGER = Logger.getLogger(AccountsListTest.class);

    private Account testAccount;
    private AccountsList accountsList;

    @Before
    public void Initialize() throws Exception
    {
        testAccount = new Account(UUID.randomUUID());
        accountsList = new AccountsList();
        accountsList.addNewAccount(testAccount);
    }

    @Test
    public void ReadingTest()
    {
        LOGGER.info("Test started: Reading test");
        try {
            Account accountFromRepository = accountsList.get(testAccount.getId());
            Assert.assertEquals(testAccount.getId(), accountFromRepository.getId());
            Assert.assertEquals(testAccount.getBalance(), accountFromRepository.getBalance());
            LOGGER.info("Test passed");
        }
        catch (Throwable e)
        {
            LOGGER.info("Test failed. " + e.toString());
            throw e;
        }
    }

    @Test
    public void testUpdating() throws Exception {
        LOGGER.debug("Test started: Updating test");
        try
        {
            testAccount.addMoney(new BigDecimal(1000));
            accountsList.update(testAccount);
            Account accountFromRepository = accountsList.get(testAccount.getId());
            Assert.assertEquals(accountFromRepository.getBalance(), testAccount.getBalance());
            LOGGER.info("Test passed");
        }
        catch (Exception e)
        {
            LOGGER.info("Test failed. " + e);
            throw e;
        }
    }

    @Test
    public void testDeleting() throws Exception {
        LOGGER.info("Test started: Deleting test");
        try
        {
            accountsList.delete(testAccount.getId());
            Account deletedAccount = accountsList.get(testAccount.getId());

            Assert.assertEquals(null, deletedAccount);
            LOGGER.info("Test passed");
        }
        catch (Exception e)
        {
            LOGGER.info("Test failed. " + e.toString());
            throw e;
        }

    }
}

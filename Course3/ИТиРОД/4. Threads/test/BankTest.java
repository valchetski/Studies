import bank.Account;
import bank.Bank;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import java.math.BigDecimal;
import java.util.UUID;

public class BankTest
{
    private static final Logger LOGGER = Logger.getLogger(BankTest.class);

    private UUID[] testAccountsId;

    @Before
    public void Initialize() throws Exception
    {
        Bank.empty();

        testAccountsId = new UUID[2];
        testAccountsId[0] = Bank.createAccount();
        testAccountsId[1] = Bank.createAccount();

        Bank.addMoney(testAccountsId[0], new BigDecimal(3000));
        Bank.addMoney(testAccountsId[1], new BigDecimal(5000));
    }

    @Test
    public void testTakingMoney() throws Throwable {
        LOGGER.info("Test started: Taking money");
        BigDecimal balanceBefore = calculateBalance();
        Bank.addMoney(testAccountsId[0], new BigDecimal(4000));
        Bank.addMoney(testAccountsId[1], new BigDecimal(1000));
        Bank.takeMoney(testAccountsId[0], new BigDecimal(2000));
        Bank.takeMoney(testAccountsId[1], new BigDecimal(1000));

        BigDecimal expectedBalance = balanceBefore.add(new BigDecimal(2000));
        BigDecimal balance = calculateBalance();
        try
        {
            Assert.assertEquals(expectedBalance, balance);
            LOGGER.info("Test passed");
        }
        catch (Throwable throwable)
        {
            LOGGER.error("Test failed. " + throwable.toString());
            throw throwable;
        }
    }

    @Test
    public void testTransfer() throws Throwable {
        LOGGER.info("Test started: Transfer money");
        BigDecimal balanceBefore = calculateBalance();
        BigDecimal transfer = BigDecimal.ZERO;
        BigDecimal balance1Before = Bank.getAccount(testAccountsId[0]).getBalance();
        BigDecimal balance2Before = Bank.getAccount(testAccountsId[1]).getBalance();

        Bank.transfer(testAccountsId[0], testAccountsId[1], transfer);
        BigDecimal balance = calculateBalance();
        BigDecimal balance1 = Bank.getAccount(testAccountsId[0]).getBalance();
        BigDecimal balance2 = Bank.getAccount(testAccountsId[1]).getBalance();
        try
        {
            Assert.assertEquals(balanceBefore, balance);
            Assert.assertEquals(balance1Before.subtract(transfer), balance1);
            Assert.assertEquals(balance2Before.add(transfer), balance2);
            LOGGER.info("Test passed");
        }
        catch (Throwable throwable)
        {
            LOGGER.error("Test failed. " + throwable.toString());
            throw throwable;
        }
    }

    private BigDecimal calculateBalance()
    {
        BigDecimal balance = BigDecimal.ZERO;
        for (Account account : Bank.getAccountsList())
        {
            balance = balance.add(account.getBalance());
        }
        return balance;
    }
}

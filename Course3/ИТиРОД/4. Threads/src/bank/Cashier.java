package bank;

import java.math.BigDecimal;
import java.util.UUID;

public final class Cashier
{
    private UUID accountId;

    public void startOperation(UUID accountId)
    {
        if (this.accountId != null)
        {
            throw new IllegalStateException("Cashier is busy.");
        }
        this.accountId = accountId;
        Bank.getBroker().beginTakingMoney(accountId);
    }

    public void endOperation()
    {
        if (accountId != null)
        {
            Bank.getBroker().endTakingMoney(accountId);
            accountId = null;
        }
    }

    public BigDecimal getBalance() throws Exception
    {
        return Bank.getAccount(this.accountId).getBalance();
    }

    public void transfer(UUID toAccountId, BigDecimal amount) throws Exception {
        Bank.transfer(accountId, toAccountId, amount);
    }

    public void addMoney(BigDecimal amount) throws Exception {
        Bank.addMoney(accountId, amount);
    }

    public void takeMoney(BigDecimal amount) throws Exception {
        Bank.takeMoney(accountId, amount);
    }
}

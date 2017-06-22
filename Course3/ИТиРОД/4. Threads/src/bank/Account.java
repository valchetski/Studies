package bank;

import java.math.BigDecimal;
import java.util.UUID;

public class Account
{
    //region id
    private final UUID id;

    public UUID getId() {
        return id;
    }
    //endregion

    //region balance
    private BigDecimal balance;

    public BigDecimal getBalance() {
        return balance;
    }
    //endregion

    //region constructors

    public Account(UUID uuid)
    {
        this(uuid, new BigDecimal(0));
    }

    public Account(UUID id, BigDecimal balance)
    {
        this.id = id;
        this.balance = balance;
    }

    //endregion

    //добавление денег на счет
    public synchronized void addMoney(BigDecimal sum)
    {
        if(sum.compareTo(BigDecimal.ZERO) == 1)
        {
            balance = balance.add(sum);
        }

    }

    //снятие денег со счета
    public synchronized void takeMoney(BigDecimal sum) throws Exception
    {
        if (sum.compareTo(getBalance()) == 1)
        {
            throw new Exception("User attempted to transfer more more money then it is on account.");
        }
        balance = balance.subtract(sum);
    }
}

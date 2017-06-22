package bank;

import main.AccountsList;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Random;
import java.util.UUID;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.atomic.AtomicLong;

public final class Bank
{
    private static final int usersCount = 30;
    private static final int accountsCount = 35;
    private static final int allNumberOfMoney = 15000000;
    public static final AtomicLong transactionCount = new AtomicLong();


    //region Accounts list
    private static AccountsList accountsList;

    public static AccountsList getAccountsList()
    {
        return accountsList;
    }

    //endregion


    //region Cashiers list
    private static BlockingQueue<Cashier> cashiers;

    public static BlockingQueue<Cashier> getCashiers()
    {
        return cashiers;
    }

    //endregion

    private static ArrayList<User> usersThreads;

    //region Broker

    private static Broker broker;

    public static Broker getBroker()
    {
        return broker;
    }

    //endregion

    //аналог статического конструктора
    static
    {
        try
        {
            accountsList = new AccountsList();
            for (int i = 0; i < accountsCount; i++)
            {
                Account testAccount =
                        new Account(UUID.randomUUID(), new BigDecimal((double) allNumberOfMoney / (double) accountsCount));
                accountsList.addNewAccount(testAccount);
            }
        }
        catch (Exception ignored) {  }

        cashiers = new ArrayBlockingQueue<>(usersCount);
        for (int i = 0; i < usersCount; i++)
        {
            cashiers.add(new Cashier());
        }

        usersThreads = new ArrayList<>(usersCount);
        for (int i = 0; i < usersCount; i++)
        {
            User clientThread = new User("", "");
            usersThreads.add(clientThread);
            clientThread.start();
        }

        broker = new Broker();
    }

    //используется в тестах
    public static void empty()
    {
        try
        {
            accountsList = new AccountsList();
        }
        catch (Exception ignored) {accountsList = null;  }

        cashiers = null;
        usersThreads = new ArrayList<>();
        broker = new Broker();
    }


    public static Account getAccount(UUID accountId) throws Exception
    {
        Account account = accountsList.get(accountId);
        if (account == null)
        {
            throw new Exception(String.format("Account with id %s not found.", accountId));
        }
        return account;
    }

    public static UUID getRandomAccountFromList()
    {
        Random random = new Random();
        return accountsList.get(random.nextInt(accountsList.size() - 1)).getId();
    }

    public static BigDecimal calculateBalance()
    {
        BigDecimal balance = BigDecimal.ZERO;
        for (Account account : accountsList)
        {
            UUID accountId = account.getId();
            broker.lockForChecking(accountId);
            balance = balance.add(account.getBalance());
            broker.setAccountChecked(accountId);
        }
        return balance;
    }

    public static UUID createAccount() throws Exception
    {
        UUID newAccountUUID = UUID.randomUUID();
        Account newAccount = new Account(newAccountUUID);
        accountsList.addNewAccount(newAccount);
        return newAccountUUID;
    }

    public static void transfer(UUID fromAccountUUID, UUID toAccountUUID, BigDecimal amount) throws Exception
    {
       boolean transactionStarted = false;
        try
        {
            broker.beginTransaction(fromAccountUUID, toAccountUUID);
            broker.beginTakingMoney(fromAccountUUID);
            transactionStarted = true;
            //LOGGER.debug(String.format("Transaction was started. From %s to %s.", fromAccountUUID, toAccountUUID));
            Account fromAccount = accountsList.get(fromAccountUUID);
            Account toAccount = accountsList.get(toAccountUUID);
            fromAccount.takeMoney(amount);
            toAccount.addMoney(amount);
            accountsList.update(fromAccount, toAccount);
        }
        finally
        {
            if (transactionStarted)
            {
                //LOGGER.debug(String.format("Transaction was finished. From %s to %s.", fromAccountUUID, toAccountUUID));
                broker.endTakingMoney(fromAccountUUID);
                broker.endTransaction(fromAccountUUID, toAccountUUID);
            }
        }
    }

    public static void addMoney(UUID toAccountUUID, BigDecimal amount) throws Exception {
        try {
            broker.beginTransaction(toAccountUUID);
            Account toAccount = accountsList.get(toAccountUUID);
            toAccount.addMoney(amount);
            accountsList.update(toAccount);
        } finally {
            broker.endTransaction(toAccountUUID);
        }
    }

    public static void takeMoney(UUID fromAccountUUID, BigDecimal amount) throws Exception {
        try {
            broker.beginTransaction(fromAccountUUID);
            broker.beginTakingMoney(fromAccountUUID);
            Account fromAccount = accountsList.get(fromAccountUUID);
            fromAccount.takeMoney(amount);
            accountsList.update(fromAccount);
        } finally {
            broker.endTakingMoney(fromAccountUUID);
            broker.endTransaction(fromAccountUUID);
        }
    }

    public static void close() throws InterruptedException
    {
        for (User clientThread : usersThreads)
        {
            clientThread.endWorking();
            clientThread.join();
        }
    }
}

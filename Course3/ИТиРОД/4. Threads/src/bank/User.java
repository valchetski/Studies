package bank;

import java.math.BigDecimal;
import java.util.Objects;
import java.util.Random;
import java.util.UUID;

public class User extends Thread {
    //region firstName
    private String firstName;

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    //endregion

    //region lastName
    private String lastName;

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }
    //endregion

    private static boolean isWorking;

    public User(String firstName, String lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        isWorking = true;
    }

    public void endWorking()
    {
        isWorking = false;
    }

    @Override
    public void run()
    {
        super.run();

        while (isWorking)
        {
            Cashier cashier = null;
            try
            {
                UUID fromAccount = Bank.getRandomAccountFromList();
                UUID toAccount;
                do {
                    toAccount = Bank.getRandomAccountFromList();
                } while (toAccount.equals(fromAccount));
                cashier = Bank.getCashiers().take();
                cashier.startOperation(fromAccount);
                BigDecimal balance = cashier.getBalance();
                if (balance.compareTo(BigDecimal.ZERO) == 1)
                {
                    BigDecimal transferAmount = balance.divide(new BigDecimal(5));

                    Random random = new Random();
                    Thread.sleep(random.nextInt(1000));

                    cashier.transfer(toAccount, transferAmount);
                    Bank.transactionCount.incrementAndGet();
                }
            } catch (Exception e) {
                if (Objects.equals(e.getMessage(), "User attempted to transfer more money then it is on account.")) {
                    System.out.println("User attempted to transfer more more money then it is on account.");
                } else {
                    System.out.println("Transaction was not finished. " + e.getMessage());
                }
            } finally {
                if (cashier != null) {
                    cashier.endOperation();
                }
                try {
                    Bank.getCashiers().put(cashier);
                } catch (InterruptedException ignored) {

                }
            }
        }
    }
}

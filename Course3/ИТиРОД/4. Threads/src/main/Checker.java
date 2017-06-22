package main;

import bank.Bank;
import java.math.BigDecimal;
import java.math.RoundingMode;

public final class Checker extends Thread
{
    private final int checkingPeriod;
    private boolean isWorking;
    private final BigDecimal initialDeposit;

    public Checker(int checkingPeriod)
    {
        isWorking = true;
        this.checkingPeriod = checkingPeriod;
        this.initialDeposit = Bank.calculateBalance();
        this.setDaemon(true);
    }

    @Override
    public void run()
    {
        super.run();

        while (isWorking)
        {
            Bank.getBroker().resetChecking();
            BigDecimal currentBalance = Bank.calculateBalance().setScale(2, RoundingMode.HALF_UP);
            BigDecimal expectedBalance = initialDeposit.setScale(2, RoundingMode.HALF_UP);
            if(currentBalance.compareTo(BigDecimal.ZERO) > -1)
            {
                if (currentBalance.equals(expectedBalance))
                {
                    System.out.println(String.format("Checking succeed. expected sum - %s, real sum - %s.",
                            expectedBalance, currentBalance));
                } else {
                    System.out.println(String.format("Checking failed. Expected - %s, actual - %s.",
                            expectedBalance, currentBalance));
                }
                try
                {
                    Thread.sleep(checkingPeriod);
                } catch (InterruptedException e) {
                    //do nothing
                }
            }
            else
            {
                System.out.println("Error. Sum is less than zero");
            }
        }
    }

    public void close()
    {
       isWorking = false;
    }
}

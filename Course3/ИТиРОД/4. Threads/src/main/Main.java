package main;

import bank.Bank;
import java.io.IOException;

public class Main
{
    public static void main(String[] args) throws Exception
    {
        System.out.println("Work started.");
        System.out.print("Input \"0\" and press Enter to exit: ");

        int checkingPeriod = 250;
        Checker checker = new Checker(checkingPeriod);
        checker.start();

        int key = '0';
        do
        {
            try
            {
                key = System.in.read();
            } catch (IOException ignored)
            {

            }
        } while (key != '0' && key != -1);
        try
        {
            checker.close();
            Bank.close();
        } catch (InterruptedException ignored) {

        }
        System.out.println(String.format("Transactions count = %s.", Bank.transactionCount));
        System.out.println("Work finished.");
    }
}

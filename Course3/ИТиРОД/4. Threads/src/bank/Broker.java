package bank;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Map;
import java.util.UUID;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;


public class Broker
{
    private final Map<UUID, Lock> lockedForTransaction = new ConcurrentHashMap<>();
    private final Map<UUID, Lock> lockedForTakingMoney = new ConcurrentHashMap<>();
    private final Map<UUID, Lock> lockedForChecking = new ConcurrentHashMap<>();
    private ArrayList<UUID> checkedAccounts = new ArrayList<>();
    private final ReadWriteLock allowNewCheckingCycleLock = new ReentrantReadWriteLock();

    //region TakingMoney

    public void beginTakingMoney(UUID accountId)
    {
        Lock lock = new ReentrantLock();
        Lock lockOrNull = lockedForTakingMoney.putIfAbsent(accountId, lock);
        lock = lockOrNull != null ? lockOrNull : lock;
        lock.lock();
    }

    public void endTakingMoney(UUID accountID)
    {
        lockedForTakingMoney.get(accountID).unlock();
    }

    //endregion

    //region Checking

    public void resetChecking()
    {
        try
        {
            allowNewCheckingCycleLock.writeLock().lock();
            checkedAccounts = new ArrayList<>();
        } finally
        {
            allowNewCheckingCycleLock.writeLock().unlock();
        }
    }

    private boolean isAccountsHaveSameCheckingState(UUID... transactionObjects)
    {
        boolean isFirstChecked = isAccountChecked(transactionObjects[0]);
        for (int i = 1; i < transactionObjects.length; i++)
        {
            if (isFirstChecked != isAccountChecked(transactionObjects[i]))
            {
                return false;
            }
        }
        return true;
    }

    private boolean isAccountChecked(UUID accountId)
    {
        return checkedAccounts.contains(accountId);
    }

    private void waitChecked(UUID accountId)
    {
        while (!checkedAccounts.contains(accountId))
        {

        }
    }

    public void lockForChecking(UUID accountID) {
        Lock newLock = new ReentrantLock();
        Lock lockOrNull = lockedForChecking.putIfAbsent(accountID, newLock);
        Lock lock = lockOrNull != null ? lockOrNull : newLock;
        lock.lock();
    }

    private void unlockForChecking(UUID accountID) {
        Lock lock = lockedForChecking.getOrDefault(accountID, null);
        if (lock != null) {
            lock.unlock();
        }
    }

    public void setAccountChecked(UUID accountId)
    {
        if(!checkedAccounts.contains(accountId))
        {
            checkedAccounts.add(accountId);
        }
        unlockForChecking(accountId);
    }
    //endregion

    //region Transaction

    public void beginTransaction(UUID... transactionObjects)
    {
        Arrays.sort(transactionObjects);
        for (UUID id : transactionObjects)
        {
            lockForTransaction(id);
        }
        for (UUID id : transactionObjects)
        {
            lockForChecking(id);
        }
        allowNewCheckingCycleLock.readLock().lock();
        boolean haveSameState = isAccountsHaveSameCheckingState(transactionObjects);
        if (!haveSameState)
        {
            for (UUID id : transactionObjects)
            {
                unlockForChecking(id);
            }
            for (UUID id : transactionObjects)
            {
                waitChecked(id);
            }
            for (UUID id : transactionObjects)
            {
                lockForChecking(id);
            }
        }
        allowNewCheckingCycleLock.readLock().unlock();
    }



    public void endTransaction(UUID... transactionObjects) {
        for (UUID id : transactionObjects)
        {
            Lock lock = lockedForTransaction.get(id);
            lock.unlock();

            unlockForChecking(id);
        }
    }

    private void lockForTransaction(UUID accountId)
    {
        Lock lock = new ReentrantLock();
        Lock lockOrNull = lockedForTransaction.putIfAbsent(accountId, lock);
        lock = lockOrNull != null ? lockOrNull : lock;
        lock.lock();
    }

    //endregion
}
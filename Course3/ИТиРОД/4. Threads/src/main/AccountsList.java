package main;

import bank.Account;

import java.util.*;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public final class AccountsList extends ArrayList<Account>
{
    private final ReentrantReadWriteLock readWriteLock;

    //region constructors

    public AccountsList() throws Exception
    {
        this(new ArrayList<>());
    }

    public AccountsList(ArrayList<Account> accounts) throws Exception
    {
        for (Account account : accounts)
        {
            this.addNewAccount(account);
        }
        readWriteLock = new ReentrantReadWriteLock();
    }

    //endregion

    public void addNewAccount(Account account) throws Exception
    {
        try
        {
            readWriteLock.writeLock().lock();
            if (find(account.getId()) != null)
            {
                throw new Exception(String.format("Entity with id %s already exists.", account.getId()));
            }
            this.add(account);
        }
        finally
        {
            readWriteLock.writeLock().unlock();
        }

    }

    public Account get(UUID id)
    {
        try
        {
            readWriteLock.readLock().lock();
            return find(id);
        }
        finally
        {
            readWriteLock.readLock().unlock();
        }

    }

   public final void update(Account... entities) throws Exception
    {
        try
        {
            readWriteLock.writeLock().lock();
            for (Account entity : entities)
            {
                Account oldEntity = find(entity.getId());
                if (oldEntity == null)
                {
                    throw new Exception(String.format("Entity with id %s not found.", entity.getId()));
                }
                this.set(this.indexOf(oldEntity), entity);
            }
        }
        finally
        {
            readWriteLock.writeLock().unlock();
        }
    }

    public void delete(UUID id) throws Exception
    {
        try
        {
            readWriteLock.writeLock().lock();
            readWriteLock.readLock().lock();
            Account entity = get(id);
            if (entity == null)
            {
                throw new Exception(String.format("Entity with id %s not found.", id));
            }
            this.remove(entity);
        } finally
        {
            readWriteLock.readLock().unlock();
            readWriteLock.writeLock().unlock();
        }
    }

    private Account find(UUID id)
    {
        Account entity = null;
        for (Account t : this)
        {
            if(id.equals(t.getId()))
            {
                entity = t;
                break;
            }
        }
        return entity;
    }
}

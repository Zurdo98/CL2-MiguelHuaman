using System.Security.Principal;
using CL2_MiguelHuaman.Exceptions;
using CL2_MiguelHuaman.Models;
using Microsoft.EntityFrameworkCore;

namespace CL2_MiguelHuaman.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly CL2Context dbContext;

        public AccountRepository(CL2Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                return false;
            }
            dbContext.Accounts.Remove(account);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Account>> GetAccount()
        {
            return await dbContext.Accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccount(int page, int size)
        {
            var result = await dbContext.Accounts
           .Skip(page * size)
           .Take(size)
           .ToListAsync();
            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundExceptions("Account list is empty");
            }
            return result;
        }

        public async Task<Account> GetAccountById(int id)
        {
            var account = await dbContext.Accounts.Where(a => a.Id== id).FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundExceptions($"Account not found with ID{id}");
            }
            return account;
        }

        public async Task<Account> GetAccountByNumber(string an)
        {
            var account = await dbContext.Accounts.Where(a => a.AccountNumber == an).FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundExceptions($"Account not found with account number{an}");
            }
            return account;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            dbContext.Accounts.Update(account);
            await dbContext.SaveChangesAsync();
            return account;
        }
    }
}

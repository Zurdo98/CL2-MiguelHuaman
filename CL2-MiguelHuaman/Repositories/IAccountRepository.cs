using CL2_MiguelHuaman.Models;

namespace CL2_MiguelHuaman.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccount();
        Task<IEnumerable<Account>> GetAccount(int page, int size);
        Task<Account> GetAccountById(int id);
        Task<Account> GetAccountByNumber(string an);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
    }
}

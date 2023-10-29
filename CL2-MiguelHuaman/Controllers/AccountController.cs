using CL2_MiguelHuaman.Models;
using CL2_MiguelHuaman.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CL2_MiguelHuaman.Controllers
{
    [ApiController]

    [Route("api/cl2/[controller]")]
    public class AccountController:ControllerBase

    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpGet]
        [Route("GetAccount")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccount());
        }
        [HttpGet]
        [Route("GetAccount/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccount(page, size));
        }

        [HttpGet]
        [Route("GetAccountById/{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {   
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccountById(id));
        }
        [HttpGet]
        [Route("GetAccountByNumber/{an}")]
        public async Task<ActionResult<Account>> GetAccountByNumber(string an)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccountByNumber(an));
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            return StatusCode(StatusCodes.Status201Created,
                await accountRepository.CreateAccount(account));
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<ActionResult<Account>> UpdateAccount(Account account)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.UpdateAccount(account));
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<ActionResult<bool>> DeleteAccount(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.DeleteAccount(id));
        }
    }
}

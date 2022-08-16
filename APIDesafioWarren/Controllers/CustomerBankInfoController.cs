using Application;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace APIDesafioWarren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersBankInfoController : ControllerBase
    {
        private readonly ICustomerBankInfoAppService _customerBankInfoAppService;

        public CustomersBankInfoController(ICustomerBankInfoAppService customerBankInfoAppService)
        {
            _customerBankInfoAppService = customerBankInfoAppService ?? throw new ArgumentNullException(nameof(customerBankInfoAppService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return SafeAction(() =>
            {
                var findAccounts = _customerBankInfoAppService.GetAll();

                return findAccounts.Count() is 0
                    ? NotFound()
                    : Ok(findAccounts);
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var bankInfo = _customerBankInfoAppService
                    .GetBy(x => x.Id.Equals(id));

                return bankInfo is null
                    ? NotFound($"Customer not found! for id: {id}")
                    : Ok(bankInfo);
            });
        }

        [HttpGet("account/{account}")]
        public IActionResult GetByAccount(string account)
        {
            return SafeAction(() =>
            {
                var bankInfo = _customerBankInfoAppService
                    .GetAll(c => c.Account.Equals(account));

                return bankInfo.Count() is 0
                    ? NotFound($"Customer not found for this FullName: {account}")
                    : Ok(bankInfo);
            });
        }

        [HttpGet("accountbalance/{accountBalance}")]
        public IActionResult GetByEmail(decimal accountBalance)
        {
            return SafeAction(() =>
            {
                var customer = _customerBankInfoAppService
                        .GetBy(c => c.AccountBalance.Equals(accountBalance));

                return customer is null
                    ? NotFound($"Customer not found for this email: {accountBalance}")
                    : Ok(customer);
            });
        }
     

        [HttpPost]
        public IActionResult Post(CreateCustomerBankInfoRequest createCustomerBankInfoRequest)
        {
            return SafeAction(() =>
            {
                var bankInfoId = _customerBankInfoAppService.Add(createCustomerBankInfoRequest);

                return bankInfoId is 0
                ? BadRequest()
                : Created("~api/customer", $"Customer succefully registered! Your ID is: {bankInfoId}");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCustomerBankInfoRequest updateCustomerBankInfoRequest)
        {
            return SafeAction(() =>
            {
                return !_customerBankInfoAppService.Update(id, updateCustomerBankInfoRequest)
                ? NotFound($"Customer not found for Id: {id}")
                : Ok("Customer sucessfully updated!");
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                return !_customerBankInfoAppService.Remove(id)
                 ? NotFound($"Customer not found for Id: {id}")
                 : NoContent();
            });
        }

        private IActionResult SafeAction(Func<IActionResult> action)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is not null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
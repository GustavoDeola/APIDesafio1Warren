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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return SafeAction(() =>
            {
                var findCustomers = _customerAppService.GetAll();

                return findCustomers.Count() is 0
                    ? NotFound()
                    : Ok(findCustomers);
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetBy(x => x.Id.Equals(id));

                return customer is null
                    ? NotFound($"Customer not found! for id: {id}")
                    : Ok(customer);
            });
        }

        [HttpGet("full-name/{fullname}")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetAll(c => c.FullName == fullName);

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                        .GetAll(c => c.Email == email);

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetBy(c => c.Cpf.Equals(cpf));

                return customer is null
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpPost]
        public IActionResult Post(CreateCustomerRequest createCustomerRequest)
        {
            return SafeAction(() =>
            {
                var customerId = _customerAppService.Add(createCustomerRequest);

                return customerId == -1
                ? BadRequest()
                : Created("~api/customer", $"Customer succefully registered! Your ID is: {customerId}");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.Update(id, updateCustomerRequest)
                ? NotFound($"Customer not found for Id: {id}")
                : Ok("Customer sucessfully updated!");
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.Remove(id)
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
using App.Services;
using Application.Models.DTOs;
using AppServices;
using AutoMapper;
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

        public CustomersController(ICustomerAppService appServices, IMapper mapper)
        {
            _customerAppService = appServices ?? throw new ArgumentNullException(nameof(appServices));
            
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
        public IActionResult GetByFullName(string fullname)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetAll(c => c.FullName == fullname);

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Byemail/{email}")]
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

        [HttpGet("Bycpf/{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetAll(c => c.Equals(cpf));

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpPost]
        public IActionResult Post(CreateCustomerRequest createCustomerRequest)
        {
            return SafeAction(() =>
            {
                var idcustomer = _customerAppService.Add(createCustomerRequest);

                return Created("~api/customer", $"Customer succefully registered! Your ID is: {idcustomer}");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerResponse customerResponseUpdated)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.Update(customerResponseUpdated)
                ? NotFound($"Customer not found for Id: {id}")
                : Ok(customerResponseUpdated);
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






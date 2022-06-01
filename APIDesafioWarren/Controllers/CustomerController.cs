
using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
using APIDesafioWarren.Validations;
using Application.Models.DTOs;
using AppServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIDesafioWarren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        private readonly IMapper _mapper;

        public CustomersController(ICustomerAppService appServices, IMapper mapper)
        {
            _customerAppService = appServices ?? throw new ArgumentNullException(nameof(appServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return SafeAction(() =>
            {
                var findCustomers = _customerAppService.GetAll();

                return findCustomers.Count() is 0
                    ? NotFound()
                    : Ok(_mapper.Map<IEnumerable<CustomerDTO>>(findCustomers));
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetBy(x => x.Id.Equals(id));

                var customerDTO = _mapper.Map<CustomerDTO>(customer);

                return customer is null
                    ? NotFound($"Customer not found! for id: {id}")
                    : Ok(customerDTO);
            });
        }

        [HttpGet("Byfullname/{fullname}")]
        public IActionResult GetByfullname(string fullname)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetAll(c => c.FullName == fullname);

                var customerDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customer);

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customerDTO);
            });
        }

        [HttpGet("Byemail/{email}")]
        public IActionResult GetByemail(string email)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                        .GetAll(c => c.Email == email);

                var customerDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customer);

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customerDTO);
            });
        }

        [HttpGet("Bycpf/{cpf}")]
        public IActionResult GetBycpf(string cpf)
        {
            return SafeAction(() =>
            {
                var customer = _customerAppService
                    .GetAll(c => c.Equals(cpf));

                var customerDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customer);

                return customer.Count() is 0
                    ? NotFound("Customer not found!")
                    : Ok(customerDTO);
            });
        }

        [HttpPost]
        public IActionResult Post(CustomerDTO model)
        {
            return SafeAction(() =>
            { 
                    _customerAppService.Add(model);

                    return Created("~api/customer", $"Customer succefully registered! Your ID is: {model.Id}");

                return BadRequest("Email invalid");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            return SafeAction(() =>
            {
                return !_customerAppService.Update(id, customer)
                ? NotFound($"Customer not found for Id: {id}")
                : Ok(customer);
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






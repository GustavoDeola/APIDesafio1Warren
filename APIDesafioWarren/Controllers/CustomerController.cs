using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
using APIDesafioWarren.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioWarren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices database)
        {
            _customerServices = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerServices.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                    .GetBy(x => x.Id.Equals(id));

                return customer is null 
                    ? NotFound($"Customer not found! for id: {id}")
                    : Ok(customer);
            });
        }

        [HttpGet("Byfullname/{fullname}")]
        public IActionResult GetByfullname(string fullname)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                    .GetAll(c => c.FullName == fullname);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Byemail/{email}")]
        public IActionResult GetByemail(string email)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                        .GetAll(c => c.Email == email);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Bybirthdate/{birthdate}")]
        public IActionResult GetBybirthdate(DateTime birthdate)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                   .GetAll(c => c.Birthdate == birthdate);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Bycpf/{cpf}")]
        public IActionResult GetBycpf(string cpf)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                    .GetAll(c => c.Equals(cpf));

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Bycellphone/{cellphone}")]
        public IActionResult GetBycellphone(string cellphone)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                    .GetAll(c => c.Cellphone == cellphone);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("ByemailSms/{emailSms}")]
        public IActionResult GetByemailsms(bool emailSms)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                     .GetAll(c => c.EmailSms == emailSms);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Bywhatsapp/{whatsapp}")]
        public IActionResult GetBywhatsapp(bool whatsapp)
        {
            return SafeAction(() =>
           {
               var customer = _customerServices
                      .GetAll(c => c.Whatsapp == whatsapp);

               return customer.Count is 0
                    ? NotFound("Customer not found!")
                    : Ok(customer);
           });
        }

        [HttpGet("Bycountry/{country}")]

        public IActionResult GetBycountry(string country)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                        .GetAll(c => c.Country == country);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Bycity/{city}")]
        public IActionResult GetBycity(string city)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                        .GetAll(c => c.City == city);

                return customer.Count is 0 
                    ? NotFound ("Customer not found!!")
                    : Ok(customer);
            });
        }

        [HttpGet("Bypostalcode/{postalcode}")]
        public IActionResult GetBypostalcode(string postalcode)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                        .GetAll(c => c.PostalCode == postalcode);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpGet("Byadress/{adress}")]

        public IActionResult GetByadress(string adress)
        {
            var customer = _customerServices
                    .GetAll(c => c.Address == adress);

            return customer.Count is 0 
                    ? NotFound("Customer not found!!")
                    : Ok(customer);
        }

        [HttpGet("Bynumber/{number}")]
        public IActionResult GetBynumber(int number)
        {
            return SafeAction(() =>
            {
                var customer = _customerServices
                        .GetAll(c => c.Number == number);

                return customer.Count is 0 
                    ? NotFound("Customer not found!")
                    : Ok(customer);
            });
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return SafeAction(() =>
            {
                if (CustomerValidator.ValidEmail(customer))
                {
                    _customerServices.Add(customer);

                    return Created("~api/customer", "Customer succefully registered! Your ID is: " + customer.Id);
                }

                return BadRequest("Email invalid");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            return SafeAction(() =>
            {
                var cli = _customerServices
                        .GetBy(c => c.Id == id);

                if (cli is null)
                {
                    return NotFound("Customer not found!");
                }
                _customerServices.Update(customer, cli);
                return Ok(cli);
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                var cli = _customerServices
                        .GetBy(c => c.Id == id);

                if (cli is null)
                {
                    return NotFound("Customer not found!");
                }
                _customerServices.Remove(cli);
                return Ok("Customer removed!");
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






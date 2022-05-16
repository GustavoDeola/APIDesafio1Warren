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
        private readonly ICustomerServices _dataBase;

        public CustomersController(ICustomerServices database)
        {
            _dataBase = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataBase.Registers);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                    .Find(x => x.Id.Equals(id));

                if (customer is null) return NotFound($"Customer not found! for id: {id}");

                return Ok(customer);
            });
        }
        [HttpGet("Byfullname/{fullname}")]
        public IActionResult GetByfullname(string fullname)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                    .FindAll(c => c.FullName == fullname);
                
                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpGet("Byemail/{email}")]
        public IActionResult GetByemail(string email)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                        .FindAll(c => c.Email == email);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpGet("Bybirthdate/{birthdate}")]
        public IActionResult GetBybirthdate(DateTime birthdate)
        {
           return SafeAction(() =>
           { 
                var customer = _dataBase.Registers
                    .FindAll(c => c.Birthdate == birthdate);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
           });
        }

        [HttpGet("Bycpf/{cpf}")]
        public IActionResult GetBycpf(string cpf)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase
                    .GetAll(Equals(cpf));


                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpGet("Bycellphone/{cellphone}")]
        public IActionResult GetBycellphone(string cellphone)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                    .FindAll(c => c.Cellphone == cellphone);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpGet("ByemailSms/{emailSms}")]
        public IActionResult GetByemailsms(bool emailSms)
        {
             return SafeAction(() =>
             { 
                var customer = _dataBase.Registers
                    .FindAll(c => c.EmailSms == emailSms);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
             });
        }

        [HttpGet("Bywhatsapp/{whatsapp}")]
        public IActionResult GetBywhatsapp(bool whatsapp)
        {
            return SafeAction(() =>
           {
               var customer = _dataBase.Registers
                      .FindAll(c => c.Whatsapp == whatsapp);

               if (customer.Capacity == 0) return NotFound("Customer not found!");

               return Ok(customer);
           });
        }

        [HttpGet("Bycountry/{country}")]

        public IActionResult GetBycountry(string country)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                        .FindAll(c => c.Country == country);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpGet("Bycity/{city}")]
        public IActionResult GetBycity(string city)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                        .FindAll(c => c.City == city);

                if (customer.Capacity == 0) return NotFound("Customer not found!!");

                return Ok(customer);
            });
        }

        [HttpGet("Bypostalcode/{postalcode}")]
        public IActionResult GetBypostalcode(string postalcode)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                        .FindAll(c => c.PostalCode == postalcode);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpGet("Byadress/{adress}")]

        public IActionResult GetByadress(string adress)
        {
            var customer = _dataBase.Registers
                    .FindAll(c => c.Address == adress);

            if (customer.Capacity == 0) return NotFound("Customer not found!!");
            
            return Ok(customer);
        }

        [HttpGet("Bynumber/{number}")]
        public IActionResult GetBynumber(int number)
        {
            return SafeAction(() =>
            {
                var customer = _dataBase.Registers
                        .FindAll(c => c.Number == number);

                if (customer.Capacity == 0) return NotFound("Customer not found!");

                return Ok(customer);
            });
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (CustomerValidator.ValidEmail(customer))
            {       
              _dataBase.Add(customer); 
            
              return Created("~api/customer", "Customer succefully registered! Your ID is: " + customer.Id);
            }

             return BadRequest("Email invalid");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            var cli = _dataBase.Registers
                    .FirstOrDefault(c => c.Id == id);

            if (cli is null)
            {
                return NotFound("Customer not found!");
            }
                _dataBase.Update(customer, cli);
                return Ok(cli);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cli = _dataBase.Registers
                    .FirstOrDefault(c => c.Id == id);

            if (cli is null)
            {
                return NotFound("Customer not found!");
            }
                _dataBase.Remove(cli);
                return Ok("Customer removed!");
        }
        private IActionResult SafeAction(Func<IActionResult> action)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}






using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
using APIDesafioWarren.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioWarren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IDataBase _dataBase;

        public ClientController(IDataBase database)
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

            var client = _dataBase.Registers.FindAll(c => c.Id == id);
            
            if (client.Capacity == 0) return NotFound("Client not found!"); 

            return Ok(client);


        }

        [HttpGet("Byfullname/{fullname}")]

        public IActionResult GetByfullname(string fullname)
        {
            var client = _dataBase.Registers.FindAll(c => c.fullName == fullname);
            if (client.Capacity == 0) return NotFound("Client not found!");

            return Ok(client);

        }

        [HttpGet("Byemail/{email}")]

        public IActionResult GetByemail(string email)
        {
            var client = _dataBase.Registers.FindAll(c => c.email == email);
            if (client.Capacity == 0) return NotFound("Client not found!");

            return Ok(client);

        }



        [HttpGet("Bybirthdate/{birthdate}")]

        public IActionResult GetBybirthdate(DateTime birthdate)
        {
            var client = _dataBase.Registers.FindAll(c => c.birthdate == birthdate);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);
        }

        [HttpGet("Bycpf/{cpf}")]

        public IActionResult GetBycpf(string cpf)
        {
            var client = _dataBase.Registers.FindAll(c => c.cpf == cpf);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);

        }

        [HttpGet("Bycellphone/{cellphone}")]

        public IActionResult GetBycellphone(string cellphone)
        {
            var client = _dataBase.Registers.FindAll(c => c.cellphone == cellphone);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);

        }
        [HttpGet("ByemailSms/{emailSms}")]
        public IActionResult GetByemailsms(bool emailSms)
        {
            var client = _dataBase.Registers.FindAll(c => c.emailSms == emailSms);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);

        }


        [HttpGet("Bywhatsapp/{whatsapp}")]

        public IActionResult GetBywhatsapp(bool whatsapp)
        {
            var client = _dataBase.Registers.FindAll(c => c.Whatsapp == whatsapp);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);

        }

        [HttpGet("Bycountry/{country}")]

        public IActionResult GetBycountry(string country)
        {
            var client = _dataBase.Registers.FindAll(c => c.country == country);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");

            }

            return Ok(client);

        }

        [HttpGet("Bycity/{city}")]

        public IActionResult GetBycity(string city)
        {
            var client = _dataBase.Registers.FindAll(c => c.city == city);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!!");
            }
            return Ok(client);

        }

        [HttpGet("Bypostalcode/{postalcode}")]

        public IActionResult GetBypostalcode(string postalcode)
        {
            var client = _dataBase.Registers.FindAll(c => c.postalCode == postalcode);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }

            return Ok(client);

        }

        [HttpGet("Byadress/{adress}")]

        public IActionResult GetByadress(string adress)
        {
            var client = _dataBase.Registers.FindAll(c => c.address == adress);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!!");
            }
            return Ok(client);

        }

        [HttpGet("Bynumber/{number}")]

        public IActionResult GetBynumber(string number)
        {
            var client = _dataBase.Registers.FindAll(c => c.number == number);
            if (client.Capacity == 0)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Post(ClientRegister client)
        {
            if (ClientValidator.validEmail(client))
            {   
                _dataBase.add(client);
                return Created("~api/client", "Client succefully registered! Your ID is: " + client.Id);
            }
            return BadRequest("Email invalid");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, ClientRegister client)
        {
            var cli = _dataBase.Registers.FirstOrDefault(c => c.Id == id);

            if (cli == null)
            {
                return NotFound("Client not found!");
            }

            _dataBase.refresh(client,cli);

            return Ok(cli);

        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var cli = _dataBase.Registers.FirstOrDefault(c => c.Id == id);

            if (cli == null)
            {
                return NotFound("Client not found!");
            }
            _dataBase.remove(cli);
            return Ok("Client removed!");
        }
    }
}






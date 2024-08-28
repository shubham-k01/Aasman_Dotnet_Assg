using Insurance_customer_api.Dtos;
using Insurance_customer_api.Models;
using Insurance_customer_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_customer_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepo _customerRepo;


        public CustomerController(CustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            List<Customer> customers = _customerRepo.GetCustomers();
            return Ok(customers);
        }


        [HttpPost]
        public IActionResult AddCustomer(CreateCustomerDTO customerDTO)
        {
            _customerRepo.AddCustomer(customerDTO);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCustomer(int id,CreateCustomerDTO customerDTO)
        {
            _customerRepo.UpdateCustomer(id,customerDTO);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCustomer(int id){
            _customerRepo.DeleteCustomer(id);
            return Ok();
        }


    }
}

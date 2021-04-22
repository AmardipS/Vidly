using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _contex;

        public CustomersController()
        {
            _contex = new ApplicationDbContext();
        }


        // GET: Api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _contex.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET: Api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST: Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _contex.Customers.Add(customer);
            _contex.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto); 
        }

        // PUT: Api/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _contex.SaveChanges();
        }

        // DELETE: Api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _contex.Customers.Remove(customer);
            _contex.SaveChanges();
        }
    }
}

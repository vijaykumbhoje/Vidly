﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext(); 
        }
        [HttpGet]
        public IEnumerable<CustomerDtos> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDtos>) ;
        }

        [HttpGet]
        public CustomerDtos GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDtos>(customer);
        }

        [HttpPost]

        public CustomerDtos CreateCustomer(CustomerDtos customerDtos)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDtos, Customer>(customerDtos);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDtos.Id = customer.Id;
            return customerDtos;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDtos customerDtos)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDtos, customerInDb);
           
            _context.SaveChanges();            
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(CustomerInDb);
            _context.SaveChanges();
        }
    }
}

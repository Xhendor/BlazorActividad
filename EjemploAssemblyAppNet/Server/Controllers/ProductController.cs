using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploAssemblyAppNet.Server.Service;
using EjemploAssemblyAppNet.Shared;

namespace EjemploAssemblyAppNet.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductServices service;


        public ProductController() { 
            service = new ProductServices();
        }



        [HttpGet]
        public async Task<List<Product>> Get() {
        
            return await service.GetProductAsync();
        
        }


        [HttpGet("{id}")]
        public async Task<Product> GetByID(int id)
        {
            Product p = new Product();
            p.Id = id;
            return await service.GetProductAsync(p);

        }



    }
}

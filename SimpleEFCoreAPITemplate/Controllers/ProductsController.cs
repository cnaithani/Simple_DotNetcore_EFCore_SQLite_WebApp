using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleEFCoreAPITemplate.Data;
using SimpleEFCoreAPITemplate.Data.Interfaces;
using SimpleEFCoreAPITemplate.DTOs;
using SimpleEFCoreAPITemplate.Models;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleEFCoreAPITemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var product = _unitOfWork.ProductRepository.GetAll();
            var productDetail = _unitOfWork.ProductDetailRepository.GetAll();
            var products = from p in product
                           join d in productDetail
                           on p.Id equals d.ProductId into j
                           from f in j.DefaultIfEmpty()
                           select new ProductDTO
                           {
                               Id = f.ProductId,
                               Name = p.Name,
                               Description = p.Description,
                               BasePrice = p.BasePrice,
                               ImageUrl = p.ImageUrl,
                               Dimentions = string.Concat(f.Length.ToString(), "*", f.Width.ToString(), "*", f.Height.ToString())
                           };

            return (products).ToList(); ;
        }

        //// GET api/<ProductsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

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
                               Id = p.Id,
                               Name = p.Name,
                               Description = p.Description,
                               BasePrice = p.BasePrice,
                               ImageUrl = p.ImageUrl,
                               Length = f.Length,
                               Width = f.Width,
                               Height = f.Height,
                               Dimentions = string.Concat(f.Length.ToString(), "*", f.Width.ToString(), "*", f.Height.ToString())
                           };

            return (products).ToList(); ;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] ProductDTO productParam)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productParam.Id);
            if (product == null)
            {
                product = new Product
                {
                    Name = productParam.Name,
                    Description = productParam.Description,
                    BasePrice = productParam.BasePrice,
                };
            }
            else
            {
                product.Name = productParam.Name;
                product.Description = productParam.Description;
                product.BasePrice = productParam.BasePrice;
                
            }


            var productDet = await _unitOfWork.ProductDetailRepository.GetAsync(x=>x.ProductId == productParam.Id);
            if (productDet == null)
            {
                productDet = new ProductDetail
                {
                    Length = productParam.Length,
                    Width = productParam.Width,
                    Height = productParam.Height,
                };
            }
            else
            {
                productDet.Length = productParam.Length;
                productDet.Width = productParam.Width;
                productDet.Height = productParam.Height;

            }


            await _unitOfWork.CommitAsync();

            return true;
        }


    }
}

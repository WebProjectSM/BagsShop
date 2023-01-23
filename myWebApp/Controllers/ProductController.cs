using AutoMapper;
using BusinessLayer;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DataLayer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductBL _bl;
         readonly IMapper _mapper;
        readonly IRatingDL _rating;
        public HttpContext context;
        public ProductController(IProductBL bl, IMapper mapper,IRatingDL rating )
        {
            _bl = bl;
            _mapper = mapper;
            
         
        }


        // GET: api/<HomeController>
        

        //public async Task<IEnumerable<Product>> Get()
        //{
        //    return await _bl.getAllProducts();

        //}
        
        [HttpGet]
        
        public async Task<List<ProductDTO>> Get([FromQuery]int position, [FromQuery]int skip,[FromQuery] string? desc, [FromQuery]int? minPrice,[FromQuery] int? maxPrice, [FromQuery]int?[] categories)
        {
           
           
            List<Product> products = await _bl.getProducts(position, skip, desc, minPrice, maxPrice, categories);
            List<ProductDTO> prodDTO = _mapper.Map<List<Product>,List<ProductDTO>>(products);
            return prodDTO;
           
         
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
           
            Product product =await _bl.getProductById(id);
           ProductDTO prodDTO = _mapper.Map<Product,ProductDTO>(product);
            if (prodDTO != null)
                return prodDTO;
            return null;

        }
       
    }
}

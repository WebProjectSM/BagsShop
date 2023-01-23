using AutoMapper;
using BusinessLayer;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryBL _bl;
        readonly IMapper _mapper;
        public CategoryController(ICategoryBL bl, IMapper mapper)
        {
            _bl = bl;
            _mapper = mapper;
        }
       

        // GET: api/<HomeController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            IEnumerable<Category> categories= await _bl.getAllCategories();
            IEnumerable<CategoryDTO> categoriesDTO=_mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }


        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDTO> Get(int id)
        {
           
            Category Category =await _bl.getCategoryById(id);
           CategoryDTO categoriesDTO = _mapper.Map<Category, CategoryDTO>(Category);
          if (categoriesDTO != null)
              return categoriesDTO;
          
            return null;

        }

      
    }
}

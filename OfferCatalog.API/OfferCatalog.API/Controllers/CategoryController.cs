using Microsoft.AspNetCore.Mvc;
using OfferCatalog.API.Models;
using OfferCatalog.API.Services;

namespace OfferCatalog.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        //public List<Task<ActionResult<Category>>> GetAllCategories()
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var res = await _categoryService.GetAllCategories();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById([FromRoute] int id)
        {
            if (id == null|| id == 0)
            {
                return BadRequest("Category Id is Not valid");
            }
            var res = await _categoryService.GetCategoryById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryNew category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var res = await _categoryService.AddCategory(category);
            return Ok(res);
        }

        [HttpPut]
        public string UpdateCategory(Category category)
        {
            return "UPdate Category";
        }

        [HttpPost]
        [Route("Department")]
        public async Task<ActionResult<string>> AddDepartment(DepartmentNew department)
        {
            if(department == null)
            {
                return BadRequest("Department infoarmaiton is required.");
            }
            var res = await _categoryService.AddDepartment(department);
            return Ok(res);
        }

        [HttpGet]
        [Route("Department")]
        public async Task<ActionResult<List<Department>>> GetAllDepartment()
        {
            var res = await _categoryService.GetAllDepartments();
            return Ok(res);
        }

        [HttpGet]
        [Route("Department/{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById ([FromRoute]int id)
        {
            if(id  == 0 || id == null)
            {
                return BadRequest("department Id is not valid");
            }
            var res = _categoryService.GetDepartmentById(id);
            return Ok(res);
        }
    }
}

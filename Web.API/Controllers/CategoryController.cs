using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.API;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IBaseService<EventCategory> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IBaseService<EventCategory> categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<EventCategory>(request);

            var response = await _categoryService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _categoryService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleCategoryResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _categoryService.GetAllAsync(token);

            var response = new GetAllCategoriesResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleCategoryResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            EventCategory entity = _mapper.Map<EventCategory>(request);

            await _categoryService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleCategoryResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _categoryService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Category with ID {id} not found.");
        }
    }
}



//using Application.Services;
//using AutoMapper;
//using Contracts.Requests;
//using Contracts.Responses;
//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace Web.API.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly IBaseService<EventCategory> _categoryService;
//        private readonly IMapper _mapper;


//        public CategoryController(IMapper mapper, IBaseService<EventCategory> CategoryService)
//        {
//            _categoryService = CategoryService;
//            _mapper = mapper;
//        }

//        //[HttpPost(ApiEndpoints.EventMethod.Create)]
//        //public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token)
//        //{
//        //    var Category = _mapper.Map<EventCategory>(request);

//        //    var response = await _categoryService.CreateAsync(Category, token);
//        //    return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

//        //}

//        //[HttpGet(ApiEndpoints.EventMethod.Get)]
//        //public async Task<IActionResult> Get(Guid id, CancellationToken token)
//        //{
//        //    var CategoryExist = await _categoryService.GetAsync(id);

//        //    if (CategoryExist == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var response = _mapper.Map<SingleCategoryResponse>(CategoryExist);

//        //    return response == null ? NotFound() : Ok(response);
//        //}
//    }
//}

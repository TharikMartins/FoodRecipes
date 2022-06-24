namespace FoodRecipe.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using FoodRecipe.Application.Interfaces;
    using AutoMapper;
    using FoodRecipe.Application.Response;
    using FoodRecipe.Application.Request;
    using FoodRecipe.Domain;

    [ApiController]
    [Route("[controller]")]
    public class FoodRecipeController : ControllerBase
    {
        private readonly IRecipeService _service;
        private readonly IMapper _mapper;

        public FoodRecipeController(IRecipeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFoodRecipeResponse>>> Get()
        {
            var response = _mapper.Map<IEnumerable<GetFoodRecipeResponse>>(await _service.Get());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFoodRecipeResponse>> Get(int id)
        {
            var response = _mapper.Map<GetFoodRecipeResponse>(await _service.Get(id));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> Post(InsertFoodRecipeRequest request)
        {
            bool result = await _service.Insert(_mapper.Map<FoodRecipeModel>(request));

            return Ok(new TransactionResponse(success: result));
        }

        [HttpPut]
        public async Task<ActionResult<TransactionResponse>> Put(UpdateFoodRecipeRequest request)
        {
            FoodRecipeModel? foodRecipeModel = await _service.Get(request.Id);

            if (foodRecipeModel is null) return NotFound();

            bool result = await _service.Update(_mapper.Map<FoodRecipeModel>(request));

            return Ok(new TransactionResponse(success: result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _service.Delete(id);

            return result ? NoContent() : NotFound();
        }
    }
}
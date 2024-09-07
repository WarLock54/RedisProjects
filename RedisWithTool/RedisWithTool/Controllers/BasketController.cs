using Microsoft.AspNetCore.Mvc;

namespace RedisWithTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
            [HttpGet("{id}")]
        public async Task<ActionResult<UserBasket>> GetBasket(string id)
        {
            // if the basket not found create new Basket and return it 
            var basket = await _basketRepository.GetBasketAsync(id);

            return basket ?? new UserBasket(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserBasket>> UpdateOrCreateBasket(UserBasket basket)
        {
            var createdOrUpdatedBasket = await _basketRepository.UpdateBasketAsync(basket);

            if (createdOrUpdatedBasket is null) return BadRequest("Failed TO Save");

            return createdOrUpdatedBasket;
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string basketId)
        {
            var result = await _basketRepository.DeleteBasketAsync(basketId);

            if (result)
                return Ok("The Basket Has Been Deleted");

            return BadRequest("Failed To Delete Basket");
        }
    }
}

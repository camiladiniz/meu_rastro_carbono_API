using MeuRastroCarbonoAPI.Infra;
using MeuRastroCarbonoAPI.Models.Entities;
using MeuRastroCarbonoAPI.Models.Payload;
using MeuRastroCarbonoAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuRastroCarbonoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DbContextClass _context;
        private readonly IConfiguration _configuration;

        public AccountController(DbContextClass context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPayload user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var userEntity = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

            if(userEntity is null || userEntity.Password != user.Password)
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new LoginResponse { Token = tokenString, Name = userEntity.Name, UserId = userEntity.Id });
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<AccountPayload>> Register(AccountPayload payload)
        {
            var userEntity = new UserEntity(){
                Email = payload.Email,
                Name= payload.Name,
                Password = payload.Password,
                Birthdate= payload.Birthdate
            };

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //[HttpGet]
        //[Route("ProductsList")]
        //public async Task<ActionResult<IEnumerable<Product>>> Get()
        //{
        //    var productCache = new List<Product>();
        //    productCache = _cacheService.GetData<List<Product>>("Product");
        //    if (productCache == null)
        //    {
        //        var product = await _context.Products.ToListAsync();
        //        if (product.Count > 0)
        //        {
        //            productCache = product;
        //            var expirationTime = DateTimeOffset.Now.AddMinutes(3.0);
        //            _cacheService.SetData("Product", productCache, expirationTime);
        //        }
        //    }
        //    return productCache;
        //}

        //[HttpGet]
        //[Route("ProductDetail")]
        //public async Task<ActionResult<Product>> Get(int id)
        //{
        //    var productCache = new Product();
        //    var productCacheList = new List<Product>();
        //    productCacheList = _cacheService.GetData<List<Product>>("Product");
        //    productCache = productCacheList.Find(x => x.ProductId == id);
        //    if (productCache == null)
        //    {
        //        productCache = await _context.Products.FindAsync(id);
        //    }
        //    return productCache;
        //}

        //[HttpPost]
        //[Route("CreateProduct")]
        //public async Task<ActionResult<Product>> POST(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();
        //    _cacheService.RemoveData("Product");
        //    return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
        //}

        //[HttpPost]
        //[Route("DeleteProduct")]
        //public async Task<ActionResult<IEnumerable<Product>>> Delete(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Products.Remove(product);
        //    _cacheService.RemoveData("Product");
        //    await _context.SaveChangesAsync();
        //    return await _context.Products.ToListAsync();
        //}

        //[HttpPost]
        //[Route("UpdateProduct")]
        //public async Task<ActionResult<IEnumerable<Product>>> Update(int id, Product product)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return BadRequest();
        //    }
        //    var productData = await _context.Products.FindAsync(id);
        //    if (productData == null)
        //    {
        //        return NotFound();
        //    }
        //    productData.ProductCost = product.ProductCost;
        //    productData.ProductDescription = product.ProductDescription;
        //    productData.ProductName = product.ProductName;
        //    productData.ProductStock = product.ProductStock;
        //    _cacheService.RemoveData("Product");
        //    await _context.SaveChangesAsync();
        //    return await _context.Products.ToListAsync();
        //}
    }
}
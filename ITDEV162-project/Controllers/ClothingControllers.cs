using ClothingBrandApi.Data;
using ClothingBrandApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingBrandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClothingItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clothingitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingItem>>> GetClothingItems()
        {
            return await _context.ClothingItems.ToListAsync();
        }

        //Get: api/clothingitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingItem>> GetClothingItem(int id)
        {
            var clothingItem = await _context.ClothingItems.FindAsync(id);

            if(clothingItem == null) 
            {
                return NotFound();
            }

            return clothingItem;
        }

        //POST: api.clothingItems

        public async Task<ActionResult<ClothingItem>> PostClothingItem(ClothingItem clothingItem)
        {
            _context.ClothingItems.Add(clothingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClothingItem), new { id = clothingItem.Id }, clothingItem);
        }

        
    }
}
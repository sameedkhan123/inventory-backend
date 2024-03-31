using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventroyManagement.Models;
using System.Collections.Generic;
using System.Linq;
using InventroyManagement.Models.DTO;

namespace InventroyManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IventroyDbContext _context;

        public PurchaseController(IventroyDbContext context)
        {
            _context = context;
        }

       /* [HttpGet]*/
        /*        public async Task<ActionResult<IEnumerable<PurchaseWithNamesDto>>> GetPurchases()
                {
                    // return await _context.Purchases.ToListAsync();
                    var purchasesWithNames = await _context.Purchases
               .Include(p => p.Product) // Include the Product navigation property
               .Include(p => p.Supplier) // Include the Supplier navigation property
               .Select(purchase => new
               {
                   purchase.PurchaseId,
                   purchase.PurchaseDate,
                   purchase.Quantity,
                   ProductName = purchase.Product.ProductName,
                   SupplierName = purchase.Supplier.Name
               })
               .ToListAsync();

                    // You may need to map the result to a specific DTO or return it directly depending on your requirements
                    // For example:
                    // var purchases = purchasesWithNames.Select(p => new PurchaseDto { PurchaseId = p.PurchaseId, PurchaseDate = p.PurchaseDate, Quantity = p.Quantity, ProductName = p.ProductName, SupplierName = p.SupplierName }).ToList();

                    return purchasesWithNames;
                }*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseWithNamesDto>>> GetPurchases()
        {
            var purchasesWithNames = await _context.Purchases
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .Select(purchase => new PurchaseWithNamesDto
                {
                    PurchaseId = purchase.PurchaseId,
                    PurchaseDate = purchase.PurchaseDate,
                    Quantity = purchase.Quantity,
                    ProductName = purchase.Product.ProductName,
                    SupplierName = purchase.Supplier.Name
                })
                .ToListAsync();

            return purchasesWithNames;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetPurchase", new { id = purchase.PurchaseId }, purchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseId == id);
        }
    }
}

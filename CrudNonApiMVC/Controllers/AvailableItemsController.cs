using CrudNonApiMVC.Data;
using CrudNonApiMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNonApiMVC.Controllers
{
    public class AvailableItemsController : Controller
    {
        private readonly GroceryStoreContext _context;

        public AvailableItemsController(GroceryStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _context.AvailableItems.ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ItemName,ItemGenre,ItemPrice")] AvailableItem availableItem)
        {
            if(ModelState.IsValid)
            {
                _context.AvailableItems.Add(availableItem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(availableItem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.AvailableItems.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,ItemGenre,ItemPrice")] AvailableItem availableItem)
        {
            if (id != availableItem.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(availableItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(availableItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.AvailableItems.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")] //garefer jud ni sya sa below na controller,, ang kanang delete kay mao ng name sa forms na asp-action

        //note na bawal the same name ang function ug same parameter, okay lang sila na same name pero dapat different ang parameter
        public async Task<IActionResult> DeletionConfirmed(int id)
        {
            var item = await _context.AvailableItems.FindAsync(id);
            if(item != null)
            {
                _context.AvailableItems.Remove(item); //mas specific lang ang _context.object.remove na style nya general lang ang diretso na like _context.remove
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


    }
}

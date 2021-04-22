using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using YamlDeploymentWeb.Models;
using YamlDeploymentWeb.Services;

namespace YamlDeploymentWeb.Controllers
{
    public class BikesController : Controller
    {
        private readonly IBikesService bikesService;

        public BikesController(IBikesService bikesService)
        {
            this.bikesService = bikesService;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
            var bikes = await bikesService.GetBikes();
            return View(bikes);
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikes = await bikesService.GetBikes();
            var bike = bikes.FirstOrDefault(m => m.Id == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Available,RentedUntil")] BikeDto bike)
        {
            if (ModelState.IsValid)
            {
                await bikesService.AddBike(bike);
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikes = await bikesService.GetBikes();
            var bike = bikes.Single(x => x.Id == id);
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Available,RentedUntil")] BikeDto bike)
        {
            if (id != bike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await bikesService.UpdateBike(bike);
                }
                catch (Exception)
                {
                    if (!await BikeExists(bike.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikes = await bikesService.GetBikes();
            var bike = bikes.Single(x => x.Id == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bikes = await bikesService.GetBikes();
            var bike = bikes.Single(x => x.Id == id);
            await bikesService.RemoveBike(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BikeExists(int id)
        {
            var bikes = await bikesService.GetBikes();
            return bikes.Any(e => e.Id == id);
        }
    }
}

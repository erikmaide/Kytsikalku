using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KytsiKalku.Data;
using KytsiKalku.Models;

namespace KytsiKalku.Controllers
{
    public class FuelDatasController : Controller
    {
        private readonly KytsiKalkuFuelContext _context;

        public FuelDatasController(KytsiKalkuFuelContext context)
        {
            _context = context;
        }

        // GET: FuelDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelData.ToListAsync());
        }

        // GET: FuelDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelData = await _context.FuelData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelData == null)
            {
                return NotFound();
            }

            return View(fuelData);
        }

        // GET: FuelDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TripName,DriveDate,TripStart,TripEnd")] FuelData fuelData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelData);
        }

        // GET: FuelDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelData = await _context.FuelData.FindAsync(id);
            if (fuelData == null)
            {
                return NotFound();
            }
            return View(fuelData);
        }

        // POST: FuelDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TripName,DriveDate,TripStart,TripEnd")] FuelData fuelData)
        {
            if (id != fuelData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelDataExists(fuelData.Id))
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
            return View(fuelData);
        }

        // GET: FuelDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelData = await _context.FuelData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelData == null)
            {
                return NotFound();
            }

            return View(fuelData);
        }

        // POST: FuelDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelData = await _context.FuelData.FindAsync(id);
            _context.FuelData.Remove(fuelData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelDataExists(int id)
        {
            return _context.FuelData.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Models;

namespace DotNetCoreBoilerplate.Controllers.SalesOrders
{
    public class SalesOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesOrders.Include(s => s.Customer).Include(s => s.SalesChannel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesOrders == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrders
                .Include(s => s.Customer)
                .Include(s => s.SalesChannel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // GET: SalesOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["SalesChannelId"] = new SelectList(_context.SalesChannels, "Id", "Id");
            return PartialView();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Description,SalesGroup,OrderDate,CustomerId,SalesChannelId,SubTotal,Discount,BeforeTax,TaxAmount,Total,OtherCharge,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", salesOrder.CustomerId);
            ViewData["SalesChannelId"] = new SelectList(_context.SalesChannels, "Id", "Id", salesOrder.SalesChannelId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesOrders == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", salesOrder.CustomerId);
            ViewData["SalesChannelId"] = new SelectList(_context.SalesChannels, "Id", "Id", salesOrder.SalesChannelId);
            return View(salesOrder);
        }

        // POST: SalesOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Description,SalesGroup,OrderDate,CustomerId,SalesChannelId,SubTotal,Discount,BeforeTax,TaxAmount,Total,OtherCharge,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] SalesOrder salesOrder)
        {
            if (id != salesOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderExists(salesOrder.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", salesOrder.CustomerId);
            ViewData["SalesChannelId"] = new SelectList(_context.SalesChannels, "Id", "Id", salesOrder.SalesChannelId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesOrders == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrders
                .Include(s => s.Customer)
                .Include(s => s.SalesChannel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // POST: SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalesOrders'  is null.");
            }
            var salesOrder = await _context.SalesOrders.FindAsync(id);
            if (salesOrder != null)
            {
                _context.SalesOrders.Remove(salesOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderExists(int id)
        {
            return _context.SalesOrders.Any(e => e.Id == id);
        }
    }
}

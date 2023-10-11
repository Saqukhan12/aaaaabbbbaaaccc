using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Models;

namespace DotNetCoreBoilerplate
{
    public class InvoicePaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicePaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InvoicePayments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InvoicePayments.Include(i => i.CashBank).Include(i => i.Invoice);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InvoicePayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvoicePayments == null)
            {
                return NotFound();
            }

            var invoicePayment = await _context.InvoicePayments
                .Include(i => i.CashBank)
                .Include(i => i.Invoice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoicePayment == null)
            {
                return NotFound();
            }

            return View(invoicePayment);
        }

        // GET: InvoicePayments/Create
        public IActionResult Create()
        {
            ViewData["CashBankId"] = new SelectList(_context.CashBanks, "Id", "Id");
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
            return View();
        }

        // POST: InvoicePayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceId,Number,Description,SalesGroup,PaymentDate,CashBankId,InvoiceAmount,PaymentAmount,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] InvoicePayment invoicePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoicePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CashBankId"] = new SelectList(_context.CashBanks, "Id", "Id", invoicePayment.CashBankId);
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoicePayment.InvoiceId);
            return View(invoicePayment);
        }

        // GET: InvoicePayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvoicePayments == null)
            {
                return NotFound();
            }

            var invoicePayment = await _context.InvoicePayments.FindAsync(id);
            if (invoicePayment == null)
            {
                return NotFound();
            }
            ViewData["CashBankId"] = new SelectList(_context.CashBanks, "Id", "Id", invoicePayment.CashBankId);
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoicePayment.InvoiceId);
            return View(invoicePayment);
        }

        // POST: InvoicePayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceId,Number,Description,SalesGroup,PaymentDate,CashBankId,InvoiceAmount,PaymentAmount,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] InvoicePayment invoicePayment)
        {
            if (id != invoicePayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoicePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicePaymentExists(invoicePayment.Id))
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
            ViewData["CashBankId"] = new SelectList(_context.CashBanks, "Id", "Id", invoicePayment.CashBankId);
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", invoicePayment.InvoiceId);
            return View(invoicePayment);
        }

        // GET: InvoicePayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvoicePayments == null)
            {
                return NotFound();
            }

            var invoicePayment = await _context.InvoicePayments
                .Include(i => i.CashBank)
                .Include(i => i.Invoice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoicePayment == null)
            {
                return NotFound();
            }

            return View(invoicePayment);
        }

        // POST: InvoicePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvoicePayments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InvoicePayments'  is null.");
            }
            var invoicePayment = await _context.InvoicePayments.FindAsync(id);
            if (invoicePayment != null)
            {
                _context.InvoicePayments.Remove(invoicePayment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicePaymentExists(int id)
        {
          return _context.InvoicePayments.Any(e => e.Id == id);
        }
    }
}

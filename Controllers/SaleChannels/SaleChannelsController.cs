using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Models;
using System.Linq.Dynamic.Core;

namespace DotNetCoreBoilerplate.Controllers.SaleChannels
{
    public class SaleChannelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleChannelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleChannels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesChannels.ToListAsync());
        }
        [HttpPost]
        public IActionResult GetSalesChannel()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction ( asc ,desc)
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)
            var searchValue = Request.Form["search[value]"].FirstOrDefault().Trim();
            //var Id  = Request.Form["Id"].FirstOrDefault()?.Trim();
            ////int RankIdInt = RankId != null && RankId != "" ? Convert.ToInt32(RankId) : 0;          
            //Paging Size (10,20,50,100)
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            int FilteredTotal = 0;

            var ListForIndexofSelectedOject = _context.SalesChannels
                .Select(c => new SalesChannelDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    //Description = c.Description,

                })
            .AsQueryable();

            #region SearchRegion
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                ListForIndexofSelectedOject = ListForIndexofSelectedOject.OrderBy(sortColumn + " " + sortColumnDirection);
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                ListForIndexofSelectedOject = ListForIndexofSelectedOject.Where(m => m.Name.Contains(searchValue));
            }
            #endregion
            //total number of rows count 
            recordsTotal = ListForIndexofSelectedOject.Count();
            FilteredTotal = ListForIndexofSelectedOject.Count();
            var data = ListForIndexofSelectedOject.Skip(skip).Take(pageSize).ToList();
            var MyDate = new List<SalesChannelDTO>();
            foreach (var item in data)
            {
                string Button = "";

                Button = $"<a  title='Add Contacts' onclick='AddCustomerContact({item.Id})' href='#' title='Add' data-bs-toggle='modal' data-bs-target='#kt_modal_generic'><i class='fas fa-plus text-success icon-custom' style='color:Dark'></i></a> <a onclick='CustomerDetail({item.Id})' href='#' class='mr-2' title='Details'><i class='fas fa-book icon-custom' data-bs-toggle='modal' data-bs-target='#kt_modal_generic_3' icon-md'></i></a><a href='#' onclick='EditCustomer({item.Id})'  title='Edit'><i class='fas fa-edit icon-custom' data-bs-toggle='modal' data-bs-target='#kt_modal_generic_2' icon-md'></i></a><a href='#' onclick='DeleteCustomer({item.Id})' data-bs-toggle='modal' data-bs-target='#kt_modal_generic_2' title='Delete' class='text-danger'> <i class='fas fa-trash text-danger icon-custom'></i></a>";

                SalesChannelDTO salesChannelDTO = new SalesChannelDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    //Description = item.Description,
                    button = Button
                };
                MyDate.Add(salesChannelDTO);
            }
            // Returning Json Data
            return Json(new { draw = draw, recordsFiltered = FilteredTotal, recordsTotal = recordsTotal, data = MyDate });
        }
        // GET: SaleChannels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesChannels == null)
            {
                return NotFound();
            }

            var salesChannel = await _context.SalesChannels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesChannel == null)
            {
                return NotFound();
            }

            return View(salesChannel);
        }

        // GET: SaleChannels/Create
        public IActionResult Create(string type)
        {
            if(type == "_partial")
            {
                return PartialView();
            }
            return View();
        }

        // POST: SaleChannels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] SalesChannel salesChannel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesChannel);
        }

        // GET: SaleChannels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesChannels == null)
            {
                return NotFound();
            }

            var salesChannel = await _context.SalesChannels.FindAsync(id);
            if (salesChannel == null)
            {
                return NotFound();
            }
            return View(salesChannel);
        }

        // POST: SaleChannels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] SalesChannel salesChannel)
        {
            if (id != salesChannel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesChannel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesChannelExists(salesChannel.Id))
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
            return View(salesChannel);
        }

        // GET: SaleChannels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesChannels == null)
            {
                return NotFound();
            }

            var salesChannel = await _context.SalesChannels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesChannel == null)
            {
                return NotFound();
            }

            return View(salesChannel);
        }

        // POST: SaleChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesChannels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalesChannels'  is null.");
            }
            var salesChannel = await _context.SalesChannels.FindAsync(id);
            if (salesChannel != null)
            {
                _context.SalesChannels.Remove(salesChannel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesChannelExists(int id)
        {
            return _context.SalesChannels.Any(e => e.Id == id);
        }
    }
}

using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace DotNetCoreBoilerplate.Controllers.Customers
{
    [AllowAnonymous]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public  IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetCustomer()
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

            var ListForIndexofSelectedOject = _context.Customers
                .Select(c => new CustomerDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Street = c.Street,
                City = c.City,
                Email = c.Email,
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
            var MyDate = new List<CustomerDTO>();
            foreach (var item in data)
            {
                string Button = "";

                Button = $"<a  title='Add Contacts' onclick='AddCustomerContact({item.Id})' href='#' title='Add' data-bs-toggle='modal' data-bs-target='#kt_modal_generic'><i class='fas fa-plus text-success icon-custom' style='color:Dark'></i></a> <a onclick='CustomerDetail({item.Id})' href='#' class='mr-2' title='Details'><i class='fas fa-book icon-custom' data-bs-toggle='modal' data-bs-target='#kt_modal_generic_3' icon-md'></i></a><a href='#' onclick='EditCustomer({item.Id})'  title='Edit'><i class='fas fa-edit icon-custom' data-bs-toggle='modal' data-bs-target='#kt_modal_generic_2' icon-md'></i></a><a href='#' onclick='DeleteCustomer({item.Id})' data-bs-toggle='modal' data-bs-target='#kt_modal_generic_2' title='Delete' class='text-danger'> <i class='fas fa-trash text-danger icon-custom'></i></a>";

                CustomerDTO customerDTO = new CustomerDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Street = item.Street,
                    City = item.City,
                    Email = item.Email,
                    //Description = item.Description,
                    button = Button
                };
                MyDate.Add(customerDTO);
            }
            // Returning Json Data
            return Json(new { draw = draw, recordsFiltered = FilteredTotal, recordsTotal = recordsTotal, data = MyDate });
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id, string type)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            if (type == "_partial")
            {
                PartialView(customer);
            }
            return PartialView(customer);
        }

        // GET: Customers/Create
        public IActionResult Create(string type)

        {
            if(type == "_partial")
            {
                return PartialView("Create");

            }
            return View("Create");
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer, string type)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));     
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id, string type)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                
            }
            if (type == "_partial")
            {
                PartialView(customer);
            }
            return PartialView(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Street,City,State,ZipCode,Phone,Email,InsertDate,InsertUserId,UpdateDate,UpdateUserId,TenantId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id, string type)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {

                return NotFound();
            }
            if (type == "_partial")
            {
               return PartialView(customer);
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftuniFest.Data;
using SoftuniFest.Models;

namespace SoftuniFest.Controllers
{
    public class DiscountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Discount
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Discounts.Include(d => d.Merchant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Discount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }

            var discount = await _context.Discounts
                .Include(d => d.Merchant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // GET: Discount/Create
        [Authorize(Roles = "Merchant,Admin")]
        public IActionResult Create()
        {
            ViewData["MerchantId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Discount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Merchant,Admin")]
        public async Task<IActionResult> Create([Bind("Id,MerchantId,Percentage,StartDate,EndDate,Status")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MerchantId"] = new SelectList(_context.Users, "Id", "Id", discount.MerchantId);
            return View(discount);
        }
    }
}

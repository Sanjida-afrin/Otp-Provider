
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtpProvider.WebApi.Data;
using OtpProvider.WebApi.Entities;
using OtpProvider.WebApi.ViewModel;

namespace OtpProvider.WebApi.Controllers
{
    public class OtpRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtpRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OtpRequests
        public async Task<IActionResult> Index()
        {
            var otpList = await _context.OtpRequests.ToListAsync();
            var otpViewModelList = otpList.Select(otp => new OtpRequestViewModel
            {
                Id = otp.Id,
                Method = otp.Method,
                To = otp.To,
                Otp = otp.Otp
            }).ToList();

            return View(otpViewModelList);
        }

        // GET: OtpRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otpRequest = await _context.OtpRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otpRequest == null)
            {
                return NotFound();
            }

            return View(otpRequest);
        }

        // GET: OtpRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OtpRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Method,To,Otp")] OtpRequest otpRequest)
        {
            if (ModelState.IsValid)
            {
                otpRequest.RequestedAt = DateTime.Now;
                _context.Add(otpRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(otpRequest);
        }

        // GET: OtpRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otpRequest = await _context.OtpRequests.FindAsync(id);
            if (otpRequest == null)
            {
                return NotFound();
            }
            return View(otpRequest);
        }

        // POST: OtpRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsSuccessful,RequestedAt,Method,To,Otp")] OtpRequest otpRequest)
        {
            if (id != otpRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otpRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtpRequestExists(otpRequest.Id))
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
            return View(otpRequest);
        }

        // GET: OtpRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otpRequest = await _context.OtpRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otpRequest == null)
            {
                return NotFound();
            }

            return View(otpRequest);
        }

        // POST: OtpRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otpRequest = await _context.OtpRequests.FindAsync(id);
            if (otpRequest != null)
            {
                _context.OtpRequests.Remove(otpRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtpRequestExists(int id)
        {
            return _context.OtpRequests.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.ViewModels;
using PS.LinkShortening.Service.Interfaces;

namespace PS.LinkShortening.Web.Controllers
{
    public class LinkController : Controller
    {

        private readonly ILinkService _dbLinkService;
        public LinkController(ILinkService dbUnitService) => _dbLinkService = dbUnitService;


        public async Task<IActionResult> Index()
        {
            var response = await _dbLinkService.GetAllLinksAsync();

            if(response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var link = new LinkCreateViewModel();
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LinkCreateViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var link = new Link()
            {
                LongURL = model.Url,
                DateCreated = DateTime.UtcNow
            };

            await _dbLinkService.CreateLinkAsync(link);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _dbLinkService.GetLinkAsync(id);

            if (response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Link model)
        {
            if (!ModelState.IsValid) { return View(model); }

            await _dbLinkService.UpdateLinkAsync(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _dbLinkService.GetLinkAsync(id);

            if (response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Link model)
        {
            if (model == null) { return View(model); }

            await _dbLinkService.DeleteLinkAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _dbLinkService.GetLinkAsync(id);

            if (response.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }


    }
}

using FastReport.Export.PdfSimple;
using FR_project.Models;
using FR_project.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FR_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        private readonly IEntrepriseService _entrepriseService;
        private readonly ICommandeService _commandeService;
        private readonly ICategorieService _categorieService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IProductService productService, IClientService clientService, IEntrepriseService entrepriseService, ICommandeService commandeService, ICategorieService categorieService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _clientService = clientService;
            _entrepriseService = entrepriseService;
            _commandeService = commandeService;
            _categorieService = categorieService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("CreateEntreprisesReports")]
        public IActionResult CreateEntreprisesReports()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Entreprises\entreprise.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Report.Save(reportFile);
            return Ok($"Rapport Enreprises généré : {report_path}");
        }

        [Route("EntreprisesReport")]
        public IActionResult EntreprisesReport()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Entreprises\entreprise.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            fast_report.Report.Load(reportFile);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(fast_report, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }

        [Route("CreateClientsReports")]
        public IActionResult CreateClientsReports()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Clients\clients.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var clientList = _clientService.GetClients();
            var entrepriseList = _entrepriseService.GetEntreprises();
            fast_report.Dictionary.RegisterBusinessObject(clientList, "clientList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Report.Save(reportFile);
            return Ok($"Rapport Clients généré : {report_path}");
        }


        [Route("ClientsReport")]
        public IActionResult ClientsReport()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Clients\clients.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var clientList = _clientService.GetClients();
            var entrepriseList = _entrepriseService.GetEntreprises();
            fast_report.Report.Load(reportFile);
            fast_report.Dictionary.RegisterBusinessObject(clientList, "clientList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(fast_report, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }


        [Route("CreateProductsReports")]
        public IActionResult CreateProductsReports()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Products\products.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var productList = _productService.GetProducts();
            var entrepriseList = _entrepriseService.GetEntreprises();
            fast_report.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Report.Save(reportFile);
            return Ok($"Rapport Products généré : {report_path}");
        }

        [Route("ProductsReport")]
        public IActionResult ProductsReport()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Products\products.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var productList = _productService.GetProducts();
            fast_report.Report.Load(reportFile);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            fast_report.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(fast_report, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }

        [Route("CreateCommandesReports")]
        public IActionResult CreateCommandesReports()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Commandes\commandes.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var commandeList = _commandeService.GetCommandes();
            fast_report.Dictionary.RegisterBusinessObject(commandeList, "commandeList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Report.Save(reportFile);
            return Ok($"Rapport généré : {report_path}");
        }

        [Route("CommandesReport")]
        public IActionResult CommandesReport()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Commandes\commandes.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var commandeList = _commandeService.GetCommandes();
            fast_report.Report.Load(reportFile);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(commandeList, "commandeList", 10, true);
            fast_report.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(fast_report, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }

        [Route("CreateCategoriesReports")]
        public IActionResult CreateCategoriesReports()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Categories\categories.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var categoriesList = _categorieService.GetCategories();
            fast_report.Dictionary.RegisterBusinessObject(categoriesList, "categoriesList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Report.Save(reportFile);
            return Ok($"Rapport généré : {report_path}");
        }

        [Route("CategoriesReport")]
        public IActionResult CategoriesReport()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\Categories\categories.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var categoriesList = _categorieService.GetCategories();
            fast_report.Report.Load(reportFile);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(categoriesList, "categoriesList", 10, true);
            fast_report.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(fast_report, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }

        [Route("CreateProductsByCategoriesReports")]
        public IActionResult CreateProductsByCategoriesReports()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\ProductsByCategory\productsByCategories.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var productList = _productService.GetProducts();
            var categoriesList = _categorieService.GetCategories();
            fast_report.Dictionary.RegisterBusinessObject(categoriesList, "categoriesList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Report.Save(reportFile);
            return Ok($"Rapport généré : {report_path}");
        }

        [Route("ProductsByCategoriesReport")]
        public IActionResult ProductsByCategoriesReport()
        {
            var report_path = Path.Combine(_webHostEnvironment.WebRootPath, @"reports\ProductsByCategory\productsByCategories.frx");
            var reportFile = report_path;
            var fast_report = new FastReport.Report();
            var entrepriseList = _entrepriseService.GetEntreprises();
            var productList = _productService.GetProducts();
            var categoriesList = _categorieService.GetCategories();
            fast_report.Report.Load(reportFile);
            fast_report.Dictionary.RegisterBusinessObject(entrepriseList, "entrepriseList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            fast_report.Dictionary.RegisterBusinessObject(categoriesList, "categoriesList", 10, true);
            fast_report.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(fast_report, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
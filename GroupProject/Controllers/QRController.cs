using Microsoft.AspNetCore.Mvc;
using QRLogic.Entities;
using QRLogic.Interfaces;

public class QRController : Controller
{
    private readonly IQRRepository _repo;
    public QRController(IQRRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        string id = Guid.NewGuid().ToString();
        string url = $"https://e2147a066f39.ngrok-free.app/trigger?id={id}";

        _repo.AddQrCodeScan(new QrCodeScan
        {
            Id = id,
            IsUsed = false
        });

        string imageInBase64 = QRGenerator.GenerateQrCode(url);
        ViewBag.QrCode = imageInBase64;
        ViewBag.QrId = id;

        return View();
    }
}

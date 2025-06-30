using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QRLogic.Interfaces;
namespace QRLogic.Controllers
{
    [ApiController]
    public class QRInteractionController : ControllerBase
    {
        private readonly ILogger<QRInteractionController> _logger;
        private readonly IQRRepository _repo;
        public QRInteractionController(ILogger<QRInteractionController> logger, IQRRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet("trigger")]
        public IActionResult Trigger([FromQuery] string id)
        {
            var scan = _repo.GetQrCodeScanById(id);
            if (scan == null)
                throw new KeyNotFoundException("QR not found");

            if (scan.IsUsed)
                throw new InvalidOperationException("QR already used");

            scan.IsUsed = true;
            scan.Points = new Random().Next(10, 100);
            _repo.UpdateQrCodeScan(scan);

            return Content($"You got {scan.Points} points!");
        }

        [HttpGet("points")]
        public IActionResult Points([FromQuery] string id)
        {
            var scan = _repo.GetQrCodeScanById(id);
            if (scan == null)
                return NotFound(new { scanned = false });

            if (scan.IsUsed)
                return Ok(new { scanned = true, points = scan.Points });

            return Ok(new { scanned = false });
        }

    }
}




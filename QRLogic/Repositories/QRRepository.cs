using QRLogic.Entities;
using QRLogic.Interfaces;

namespace QRLogic.Repositories
{
    public class QRRepository : IQRRepository
    {
        private readonly AppDbContext _context;
        public QRRepository(AppDbContext context)
        {
            _context = context;
        }
        public QrCodeScan GetQrCodeScanById(string id)
        {
            return _context.QrCodeScans.FirstOrDefault(q => q.Id == id);
        }
        public void AddQrCodeScan(QrCodeScan qrCodeScan)
        {
            _context.QrCodeScans.Add(qrCodeScan);
            _context.SaveChanges();
        }
        public void UpdateQrCodeScan(QrCodeScan qrCodeScan)
        {
            _context.QrCodeScans.Update(qrCodeScan);
            _context.SaveChanges();
        }
        public void DeleteQrCodeScan(string id)
        {
            var qrCodeScan = GetQrCodeScanById(id);
            if (qrCodeScan != null)
            {
                _context.QrCodeScans.Remove(qrCodeScan);
                _context.SaveChanges();
            }
        }
    }
}

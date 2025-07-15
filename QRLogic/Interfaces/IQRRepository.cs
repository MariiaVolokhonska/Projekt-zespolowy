using QRLogic.Entities;

namespace QRLogic.Interfaces
{
    public interface IQRRepository
    {
        QrCodeScan GetQrCodeScanById(string id);
        void AddQrCodeScan(QrCodeScan qrCodeScan);
        void UpdateQrCodeScan(QrCodeScan qrCodeScan);
        void DeleteQrCodeScan(string id);
    }
}

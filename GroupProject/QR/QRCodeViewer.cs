using GroupProject.ViewModels;
using QRLogic.Entities;

namespace GroupProject.QR
{
    public static class QRCodeViewer
    {
        public static QRViewModel DisplayQrCode(string url, string id)
        {
            string imageInBase64 = QRGenerator.GenerateQrCode(url);

            return new QRViewModel
            {
                QrCode = imageInBase64,
                QrId = id
            };
        }
    }
}

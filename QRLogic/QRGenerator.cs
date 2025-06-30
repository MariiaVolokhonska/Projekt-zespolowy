using QRCoder;
public static class QRGenerator
{
    public static string GenerateQrCode(string url)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new BitmapByteQRCode(qrCodeData);
        var imageBytes = qrCode.GetGraphic(5);
        Console.WriteLine("Hello");
        return $"data:image/png;base64,{Convert.ToBase64String(imageBytes)}";

    }
}

namespace GroupProject.ViewModels
{
    public class CouponViewModel
    {
        public string? Id { get; set; }
        public string? ServiceName { get; set; }
        public string? QrCode { get; set; }
        public bool IsActivated { get; set; }
        public bool IsUsed { get; set; }
    }
}

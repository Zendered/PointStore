namespace Identity.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationTime { get; set; } = 2;
        public string Issuer { get; set; } = "PointStore";
        public string ValidIn { get; set; }
    }
}

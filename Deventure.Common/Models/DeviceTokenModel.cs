namespace Deventure.Common.Models
{
    public class DeviceTokenModel
    {
        public string Email { get; set; }

        public int DeviceType { get; set; }

        public string DeviceId { get; set; }

        public string Token { get; set; }

        public int UserType { get; set; }
    }
}

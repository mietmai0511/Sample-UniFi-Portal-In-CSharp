using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace UniFiPortal.Models
{
    public class WifiLoginModel
    {
        public string Email { get; set; }
        public string Fullname { get; set; }

        #region UniFi sent to controller

        public string Id { get; set; }
        public string Ap { get; set; }
        public string T { get; set; }
        public string Url { get; set; }
        public string Ssid { get; set; }

        #endregion



    }
    
}

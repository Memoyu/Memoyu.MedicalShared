using System;
namespace MedicalShredApp.Models.Profile
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoModel
    {
        public Guid Uid { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string IdNo { get; set; }
        public string Password { get; set; }
        public int ? SexCode { get; set; }
        public DateTime Birthday { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public int ? JobCode { get; set; }
        public string HeadIcon { get; set; }
        public int ? BloodCode { get; set; }
        public string LxProvince { get; set; }
        public string LxCity { get; set; }
        public string LxCounty { get; set; }
        public string LxAddressDetail { get; set; }
        public string LxZipCode { get; set; }
        public string QrCode { get; set; }
        public string WorkTelNo { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDelete { get; set; }
        public string Creater { get; set; }
        public DateTime CreateDate { get; set; }
        public string Modifier { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}

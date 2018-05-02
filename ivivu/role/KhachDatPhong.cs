using System;
using System.Security.Principal;
namespace ivivu.role
{
    public class KhachDatPhongIdentity : IIdentity
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public KhachDatPhongIdentity(){}
        public KhachDatPhongIdentity(string username)
        {
            Name = username;
            AuthenticationType = "khach-dat-phong";
            IsAuthenticated = true;
        }
    }

    public class KhachdatPhong : IPrincipal
    {
        public IIdentity Identity { get; }

        public KhachdatPhong()
        {
            Identity = new KhachDatPhongIdentity();
        }

        public KhachdatPhong(string username)
        {
            Identity = new KhachDatPhongIdentity(username);
        }

        public bool IsInRole(string role)
        {
            switch (role)
            {
                case "admin":
                    {
                        return false;
                    }
                case "customer":
                    {
                        return true;
                    }
                default:
                    {
                        return true;
                    }
            }
        }
    }
}

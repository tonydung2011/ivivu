using System;
using System.Security.Principal;
namespace ivivu.role
{
    public class QuanTriVienIdentity : IIdentity
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public QuanTriVienIdentity() { }
        public QuanTriVienIdentity(string username)
        {
            Name = username;
            IsAuthenticated = true;
            AuthenticationType = "quan-tri-vien";
        }
    }

    public class QuanTriVien: IPrincipal
    {
        public IIdentity Identity { get; }

        public QuanTriVien()
        {
            Identity = new QuanTriVienIdentity();
        }

        public QuanTriVien(string username)
        {
            Identity = new QuanTriVienIdentity(username);
        }

        public bool IsInRole(string role)
        {
            switch (role)
            {
                case "QuanTri":
                    {
                        return true;
                    }
                case "customer":
                    {
                        return false;
                    }
                default:
                    {
                        return true;
                    }
            }
        }
    }
}

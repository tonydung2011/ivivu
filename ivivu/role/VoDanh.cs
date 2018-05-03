using System;
using System.Security.Principal;
namespace ivivu.role
{
    public class VoDanhIdentity : IIdentity
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public VoDanhIdentity(){
            Name = "no-name";
            AuthenticationType = "vo-danh";
            IsAuthenticated = false;
        }
    }

    public class VoDanh: IPrincipal
    {
        public IIdentity Identity { get; }

        public VoDanh()
        {
            Identity = new VoDanhIdentity();
        }

        public bool IsInRole(string role)
        {
            switch (role) {
                case "QuanTri":
                    {
                        return false;
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

using LeanCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    //public enum Account
    //{
    //    UserName,
    //    Password,
    //    PhoneNumber
    //}

    [AVClassName("ACCOUNT")]
    public class ACCOUNT : AVObject
    {
        [AVFieldName("UserName")]
        public string UserName
        {
            get { return GetProperty<string>("UserName"); }
            set { SetProperty<string>(value, "UserName"); }
        }

        [AVFieldName("Password")]
        public string Password
        {
            get { return GetProperty<string>("Password"); }
            set { SetProperty<string>(value, "Password"); }
        }

        [AVFieldName("PhoneNumber")]
        public string PhoneNumber
        {
            get { return GetProperty<string>("PhoneNumber"); }
            set { SetProperty<string>(value, "PhoneNumber"); }
        }

        public override string ToString()
        {
            return "userName: "+ UserName + "\n password: "+ Password + "\n phonenumber: "+ PhoneNumber;
        }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersTest.Models
{
    public enum Cities
    {
        London,
        Paris,
        Chicago
    }
    public enum Countries
    {
        None,
        UK,
        France,
        USA
    }
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public Countries Country { get; set; }
        public void SetCountryFromCity(Cities city)
        {
            switch (city)
            {
                case Cities.London:
                    Country = Countries.UK;
                    break;
                case Cities.Chicago:
                    Country = Countries.USA;
                    break;
                case Cities.Paris:
                    Country = Countries.France;
                    break;
                default:
                    Country = Countries.None;
                    break;

            }
        }
    }
}
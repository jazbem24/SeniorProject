using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hw5.Models;
using System.Data.Entity;


namespace hw5.DAL
{
    public class AddressContext : DbContext
    {
        public AddressContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<Address> Addresses { get; set; }
    }
}
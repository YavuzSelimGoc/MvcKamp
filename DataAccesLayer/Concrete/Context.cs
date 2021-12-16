using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<About> About { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Concent>  Concent { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Heading> Heading { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ImageFile> ImageFile { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Skill> Skill { get; set; }
    }
}

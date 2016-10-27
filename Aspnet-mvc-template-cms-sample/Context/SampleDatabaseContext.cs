using System.Data.Entity;
using Aspnet_mvc_template_cms_sample.ModalLogin.Models;
using Aspnet_mvc_template_cms_sample.PageFieldPlugin.Concrete;

namespace Aspnet_mvc_template_cms_sample.Context
{
    public class SampleDatabaseContext: DbContext
    {
        public DbSet<LoginUser> LoginUsers { get; set; }
        public DbSet<BasicPageField> BasicPageFields { get; set; }

        public SampleDatabaseContext()
        {
            Database.SetInitializer(new SampleDatabaseContextInitializer());
        }
    }

    public class SampleDatabaseContextInitializer : CreateDatabaseIfNotExists<SampleDatabaseContext>
    {
        protected override void Seed(SampleDatabaseContext context)
        {
            context.LoginUsers.Add(new LoginUser() {
                Email = "kadirmuratbaseren@gmail.com",
                Name = "Murat",
                Surname = "Baseren",
                Username = "muratbaseren",
                Password = "123"
            });

            context.SaveChanges();
        }
    }
}

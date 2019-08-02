using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCCarServiceApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //^[a-zA-Z ]+[a-zA-Z]$
        //^[a-zA-Z\\s]*$
        //^[a-zA-Z\s]+$
        [Required(ErrorMessage = "First Name is Mandatory")]
        [RegularExpression(@"^[a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "First Name Format is wrong")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Mandatory")]
        [RegularExpression(@"^[a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "Last Name Format is wrong")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "City is Mandatory")]
        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", ErrorMessage = "City Format is wrong")]
        public string City { get; set; }

        [Required(ErrorMessage = "Email Id is Mandatory")]
        [EmailAddress(ErrorMessage="Email Id Format is wrong")]
        [Display(Name = "Email Id")]
        public override string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is Mandatory")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile No. Format is wrong, Write only 10 digit mobile numbers")]
        [Display(Name ="Mobile No.")]
        public override string PhoneNumber { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarStyle> CarStyles { get; set; }
		public DbSet<ServiceRequest> ServiceRequests { get; set; }

		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
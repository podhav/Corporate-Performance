using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Corporate_Performance.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Controllers.Data
{
    public class DbInitializer : IDbInitializer
    {
        
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

            }
            catch (Exception)
            { 
            
            }
            if (_db.Roles.Any(r => r.Name == SD.ManagerUser)) return;
            _roleManager.CreateAsync(new IdentityRole(SD.ManagerUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.AdminUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.EndUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.ReadOnlyUser)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "podhav@ecdc.co.za",
                Email = "podhav@ecdc.co.za",
                Name = "Prakash Odhav",
                EmailConfirmed = true,
                PhoneNumber = "0834512284",
            },"Rock1967.1").GetAwaiter().GetResult();

            IdentityUser user = await _db.Users.FirstOrDefaultAsync(u => u.Email == "podhav@ecdc.co.za");

            await _userManager.AddToRoleAsync(user, SD.ManagerUser);
        }

        
    }
}

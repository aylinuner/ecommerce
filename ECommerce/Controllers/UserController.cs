using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using ecommerce.Models;
using ecommerce.Models.Custom;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Project.COMMON.Tools;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
         readonly _DbContext _context;
         readonly UserManager<AppUser> _userManager;
         readonly SignInManager<AppUser> _signInManager;

        public UserController( _DbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            //parametredeki bilgilere ait veritabanýndaki kullanýcýyý bul.

            //user exist_user = _context.user.FirstOrDefault(o => o.email == model.email && o.password_hash == model.password);
            //if (exist_user == null)
            //{
            //    ViewBag.ErrorMessage = "E posta veya þifre yanlýþ";
            //}
            //return View(model);
            return View();

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> RegisterOld(UserViewModel model)
        {
            AppUser u = new AppUser();
            if (model.email != null)
            {
                //kullanýcýnýn girdiði maili küçültür(ToLower).
                model.email = model.email.ToLower();

                //veritabanýndan email ile arama yap.
                u = await _userManager.FindByEmailAsync(model.email);
            }
            if (u != null)
            {

                ModelState.AddModelError(string.Empty, "Bu email zaten kayýtlý baþka email kullanýnýz!");

            }

            //Girilen þifreler birbirinden farklý ise 
            else if (model.password != model.password_confirm)
            {

                ModelState.AddModelError(string.Empty, "Þifreleriniz ayný deðil kontrol ediniz!");

            }
            //Hiçbir sorun yoksa veritabanýna kaydet
            else
            {
                PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>(); //IdentityFrameworkten gelir.Þifrelerin hashlenmesi ve doðrulanmasý için kullanýlýr.(chatgpt)
                AppUser user = new()
                {
                    UserName = model.name,
                    Email = model.email,
                    NormalizedEmail = model.email.ToUpper(),
                    NormalizedUserName = model.name.ToUpper(),
                    EmailConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = passwordHasher.HashPassword(null, model.password), //þifreyi þifrelemek
                    //Profile = new AppUserProfile { FirstName = model.FirstName, LastName = model.LastName }, //kullanýcýnýn profil kaydýnýda oluþturmuþ oluyoruz
                };
                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "Visitor");//kullanýcý rolü bütün kayýtlarda visitor olarak atanýr. deðiþtirilmek istendiði takdirde appuserrole tablosundan veritabaný üzerinden düzenlenebilir.

                    //kullanýcý oturum açmýþ olarak ayarla (singýnmanager ýdentitty içinde var.)
                    AppUser appUser = await _userManager.FindByEmailAsync(user.Email);

                    #region üyelik doðrulama maili gönder
                    string body = $"Hesabýnýz oluþturulmuþtur. Üyeliðinizi onaylamak için lütfen http://localhost:5089/User/ConfirmEmail?id={appUser.Id} linkine týklayýnýz";
                    //MailService.Send(model.email, body: body, subject: "Nera Yeni Üye Kaydý Doðrulama");

                    TempData["Message"] = "Kayýt iþlemi baþarýlý, Emailinizi kontrol ediniz,Kayýt iþleminizi tamamlamak için, gelen maildeki linke týklayýn!";
                    #endregion

                    //test ersoy
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);

                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { FullName="test", UserName = model.email, Email = model.email };
                var result = await _userManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(int id)
        {
            // Kullanýcýyý Id ile bulma
            AppUser appUser = await _userManager.FindByIdAsync(id.ToString());

            // Email'i onaylanmýþ olarak iþaretleme
            appUser.EmailConfirmed = true;

            // Kullanýcý bilgilerini güncelleme
            await _userManager.UpdateAsync(appUser);

            // Kullanýcýyý oturum açmýþ gibi iþaretleme
            await _signInManager.SignInAsync(appUser, isPersistent: false);

            // Ana sayfaya yönlendirme
            return RedirectToAction("Index", "Home");
        }
    }
}
//            if (ModelState.IsValid)
//            {
//                // Kullanýcý sayýsýný asenkron olarak veritabanýndan çek
//                int existUserCount = await _context.users.Where(x => x.email == model.email).CountAsync();
//                if (existUserCount > 0)
//                {
//                    ViewBag.ErrorMessage = "Girilen e posta zaten kayýtlý";
//                    return View(model);
//                }


//                _logger.LogInformation($"Toplam Kullanýcý Sayýsý: {existUserCount}");

//                // Viewmodeldeki verileri entity class'a aktar veritabanýna göndermek üzere. 
//                user entityUser = new user
//                {
//                    name = model.name,
//                    surname = model.surname,
//                    phone_area = model.phone_area,
//                    phone_number = model.phone_number,
//                    gender = model.gender,
//                    create_date = DateTime.Now,
//                    birth_date = model.birth_date,
//                    email = model.email,
//                    password = HashPasswordMD5(model.password)
//                };

//                // Veritabanýna ekleyip kaydet (asenkron)
//                _context.users.Add(entityUser);
//                await _context.SaveChangesAsync();
//                TempData["SuccessMessage"] = "Kayýt iþlemi baþarýlý! Giriþ yapabilirsiniz.";

//                // Login sayfasýna yönlendir
//                return RedirectToAction("Login");
//            }

//            return View(model);
//        }
//        public static string HashPasswordMD5(string password)
//        {
//            using (MD5 md5 = MD5.Create())
//            {
//                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
//                byte[] hashBytes = md5.ComputeHash(inputBytes);

//                StringBuilder sb = new StringBuilder();
//                foreach (byte b in hashBytes)
//                {
//                    sb.Append(b.ToString("x2")); // Hexadecimal format
//                }

//                return sb.ToString();
//            }
//        }
//    }


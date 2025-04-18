using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using ecommerce.Models;
using ecommerce.Models.Custom;
using ecommerce.Models.Db;
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

        public UserController(_DbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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
            if (String.IsNullOrEmpty(model.email))
            {
                ModelState.AddModelError("", "E posta zorunludur");
            }
            else if (!IsValidEmail(model.email))
            {
                ModelState.AddModelError("", "Geçerli bir e-posta adresi girin");
            }
            else if (String.IsNullOrEmpty(model.password))
            {
                ModelState.AddModelError("", "Þifre zorunludur");
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.email.ToLower().Trim());

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.password, isPersistent: false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta veya þifre hatalý.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanýcý bulunamadý.");
                }

            }  //parametredeki bilgilere ait veritabanýndaki kullanýcýyý bul.

            //user exist_user = _context.user.FirstOrDefault(o => o.email == model.email && o.password_hash == model.password);
            //if (exist_user == null)
            //{
            //    ViewBag.ErrorMessage = "E posta veya þifre yanlýþ";
            //}
            //return View(model);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User");
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
            if (String.IsNullOrEmpty(model.name))
            {
                ModelState.AddModelError("", "Ad Zorunludur");
            }
            else if (String.IsNullOrEmpty(model.surname))
            {
                ModelState.AddModelError("", "Soyad Zorunludur");
            }
            else if (model.gender == '\0')
            {
                ModelState.AddModelError("", "Cinsiyet zorunludur");
            }
            else if (model.birth_date == DateOnly.MinValue || model.birth_date == null)
            {
                ModelState.AddModelError("", "Doðum tarihi zorunludur");
            }
            else if (String.IsNullOrEmpty(model.phone_area))
            {
                ModelState.AddModelError("", "Telefon kodu zorunludur");
            }
            else if (String.IsNullOrEmpty(model.phone_number))
            {
                ModelState.AddModelError("", "Telefon numarasý zorunludur");
            }
            else if (model.phone_number.Length < 10)
            {

                ModelState.AddModelError("", "Telefon numarasýný 10 hane giriniz");
            }
            else if (String.IsNullOrEmpty(model.email))
            {

                ModelState.AddModelError("", "E posta zorunludur");
            }
            else if (!IsValidEmail(model.email))
            {
                ModelState.AddModelError("", "Geçerli bir e-posta adresi girin");
            }
            else if (!IsValidPassword(model.password))
            {
                ModelState.AddModelError("", "Þifre en az 8 karakter, bir büyük harf, bir küçük harf ve bir özel karakter içermelidir.");
            }
            else if (String.IsNullOrEmpty(model.password))
            {
                ModelState.AddModelError("", "Þifre zorunludur");
            }
            else if (String.IsNullOrEmpty(model.password_confirm))
            {
                ModelState.AddModelError("", "Þifre tekrarý zorunludur");
            }
            else if (model.password != model.password_confirm)
            {
                ModelState.AddModelError("", "Þifreler eþleþmiyor, kontrol edin");
            }
            else
            {
                var existUser = _context.AppUser.FirstOrDefault(x => x.Email == model.email.Trim().ToLower()) ;

                if (existUser != null)
                {
                    ModelState.AddModelError("", "Bu e posta zaten kayýtlý!");
                }
                else 
                {
                    PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>(); //IdentityFrameworkten gelir.Þifrelerin hashlenmesi ve doðrulanmasý için kullanýlýr.(chatgpt)

                    //parametredeki viewmodeldeki verileri appuser nesnesine aktardým.
                    AppUser user = new()
                    {
                        FullName="Aylin",
                        UserName = model.name,
                        Email = model.email,
                        NormalizedEmail = model.email.ToUpper(),
                        NormalizedUserName = model.name.ToUpper(),
                        EmailConfirmed = false,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = passwordHasher.HashPassword(null, model.password), //þifreyi þifrelemek
                        //Profile = new AppUserProfile { FirstName = model.name, LastName = model.surname }, //kullanýcýnýn profil kaydýnýda oluþturmuþ oluyoruz
                    };

                    //yeni kullanýcý oluþtur ve kaydet
                    var result = await _userManager.CreateAsync(user, model.password);

                    if (result.Succeeded)
                    {
                        //kullanýcý profilini oluþtur. Rol ata ve kaydet
                        await _userManager.AddToRoleAsync(user, "Customer");
                        //Bu kod (sinInManager) oturum açýldýktan sonra sana bir user vereceðim o user oturum açmýþ olarak ayarla.(html kodu yazýlacak.)
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
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

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Þifre uzunluðu kontrolü
            if (password.Length < 8)
            {
                return false;
            }

            // Büyük harf kontrolü
            bool hasUpperCase = password.Any(c => char.IsUpper(c));

            // Küçük harf kontrolü
            bool hasLowerCase = password.Any(c => char.IsLower(c));

            // Özel karakter kontrolü
            bool hasSpecialChar = password.Any(c => !char.IsLetterOrDigit(c));

            // Tüm þartlarýn saðlandýðýndan emin ol
            return hasUpperCase && hasLowerCase && hasSpecialChar;
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            // E-posta adresinin geçerli olup olmadýðýný kontrol eden bir düzenli ifade (regex)
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
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


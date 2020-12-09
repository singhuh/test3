using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using test3.Areas.Identity.Models;

namespace test3.Areas.Identity.Pages.Account.Manage
{
    public class ChangePhotoModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public ChangePhotoModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public class InputModel
        {
            public byte[] Photo { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string ImgUrl)
        {
            var returnUrl = Url.Content("~/");
            var img = Convert.FromBase64String(ImgUrl);
            Input.Photo = img;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.Photo = Input.Photo;
                await _userManager.UpdateAsync(user);
                await _signInManager.SignInAsync(user, isPersistent: false);

                return LocalRedirect(returnUrl);
            }
            return Page();
        }
    }
}

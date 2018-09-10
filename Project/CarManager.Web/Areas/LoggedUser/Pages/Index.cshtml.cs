//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Threading.Tasks;
//using CarManager.Data;
//using CarManager.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace CarManager.Web.Areas.LoggedUser.Pages
//{
//    [Authorize]
//    public class IndexModel : PageModel
//    {
//        private readonly CarManagerDbContext context;


//        public IndexModel(CarManagerDbContext context)
//        {
//            this.context = context;
//        }

//        [BindProperty]
//        public InputModel Input { get; set; }

//        public string ReturnUrl { get; set; }

//        public class InputModel
//        {
//            [Required]
//            [Display(Name = "Vehicle Type")]
//            public VehicleType Type { get; set; }

//            [Required]
//            [MinLength(2)]
//            [MaxLength(20)]
//            [Display(Name = "Make")]
//            public string Make { get; set; }

//            [Required]
//            [MaxLength(20)]
//            [Display(Name = "Model")]
//            public string Model { get; set; }

//            [Display(Name = "Image")]
//            public string ImageUrl { get; set; }

//            [Required]
//            [DataType(DataType.Date)]
//            [Display(Name = "Date of registration")]
//            public DateTime FirstRegistrationDate { get; set; }

//            [Display(Name = "Horse Power")]
//            public int HorsePower { get; set; }

//            [Required]
//            [Display(Name = "Current Kilometers")]
//            public double Kilometers { get; set; }
//        }

//        public void OnGet(string returnUrl = null)
//        {
//            ReturnUrl = returnUrl;
//        }

//        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
//        {
//            returnUrl = returnUrl ?? Url.Content("~/");
//            if (ModelState.IsValid)
//            {
//                var vehicle = new Vehicle
//                {
//                    Type = Input.Type,
//                    Make = Input.Make,
//                    Model = Input.Model,
//                    ImageUrl = Input.ImageUrl,
//                    FirstRegistrationDate = Input.FirstRegistrationDate,
//                    HorsePower = Input.HorsePower,
//                    Kilometers = Input.Kilometers
//                };

//                var result = await context.AddAsync<Vehicle>(vehicle);
//                context.SaveChanges();
//                //if (context.)
//                //{
//                //    return LocalRedirect(returnUrl);
//                //}
//                //foreach (var error in result.Errors)
//                //{
//                //    ModelState.AddModelError(string.Empty, error.Description);
//                //}
//            }

//            // If we got this far, something failed, redisplay form
//            return Page();
//        }
//    }
//}
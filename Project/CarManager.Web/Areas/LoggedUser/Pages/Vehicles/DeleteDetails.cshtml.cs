using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManager.Web.Areas.LoggedUser.Pages.Vehicles
{
    public class DeleteDetailsModel : PageModel
    {
        public void OnGet()
        {
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Modification { get; set; }
    }
}
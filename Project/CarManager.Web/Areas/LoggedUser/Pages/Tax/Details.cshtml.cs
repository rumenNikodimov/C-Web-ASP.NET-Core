using System;
using CarManager.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManager.Web.Areas.LoggedUser.Pages.Tax
{
    public class DetailsModel : PageModel
    {
        public void OnGet(int id)
        {

        }

    
        public TaxName Name { get; set; }

        public DateTime ExpireDate { get; set; }

        public int VehicleId { get; set; }
    }
}
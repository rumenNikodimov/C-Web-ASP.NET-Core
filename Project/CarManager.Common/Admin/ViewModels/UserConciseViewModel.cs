﻿namespace CarManager.Web.Areas.Admin.Models.ViewModels
{
    public class UserConciseViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsModerator { get; set; }
    }
}

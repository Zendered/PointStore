﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokerAsync()
        {
            return View();
        }
    }
}
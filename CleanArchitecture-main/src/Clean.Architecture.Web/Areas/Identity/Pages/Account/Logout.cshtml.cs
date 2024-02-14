// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.Architecture.Web.Areas.Identity.Pages.Account;

public class LogoutModel : PageModel
{
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly ILogger<LogoutModel> _logger;

  public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
  {
    _signInManager = signInManager;
    _logger = logger;
  }

  public async Task<IActionResult> OnPost()
  {
    await _signInManager.SignOutAsync();
    _logger.LogInformation("User logged out.");
    return LocalRedirect("/Student/Read");
  }
}

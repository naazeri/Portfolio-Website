using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactUsController(IContactUsService contactUsService) : ControllerBase
{

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreateContactUsViewModel model)
  {
    #region Validations
    return Ok("hi");
    if (!ModelState.IsValid)
    {
      //   return BadRequest("Form is not valid");
      return BadRequest(ModelState);
    }

    #endregion

    var result = await contactUsService.AddAsync(model);

    switch (result)
    {
      case CreateContactUsResult.Success:
        // Return 200 OK with success message
        return Ok(new { message = "پیام شما با موفقیت ثبت شد. نتیجه از طریق ایمیل به شما اطلاع رسانی خواهد شد." });

      case CreateContactUsResult.Error:
        // Return 500 Internal Server Error with an error message
        return StatusCode(500, new { message = "خطایی رخ داده است لطفا مجدد تلاش کنید." });
    }

    // Return 500 Internal Server Error if nothing matched
    return StatusCode(500, new { message = "An unexpected error occurred." });
  }



}

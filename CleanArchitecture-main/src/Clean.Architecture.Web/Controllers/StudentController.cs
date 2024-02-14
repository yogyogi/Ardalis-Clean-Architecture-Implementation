using Clean.Architecture.Web.Endpoints.StudentEndpoints;
using Clean.Architecture.Web.StudentEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Clean.Architecture.Web.Controllers;
public class StudentController : Controller
{

  // Remove the // from Authorize attribute will make it secure
  //[Authorize]
  public IActionResult Create()
  {
    return View();
  }

  // Remove the // from Authorize attribute will make it secure
  //[Authorize]
  [HttpPost]
  public async Task<IActionResult> Create(CreateStudentRequest s)
  {
    if (ModelState.IsValid)
    {
      using (var httpClient = new HttpClient())
      {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{Request.Scheme}://{Request.Host}/Student", s);
        return RedirectToAction("Read");
      }
    }
    else
      return View();
  }

  public async Task<IActionResult> Read()
  {
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"{Request.Scheme}://{Request.Host}/Student"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        var s = JsonConvert.DeserializeObject<StudentListResponse>(apiResponse);
        return View(s);
      }
    }
  }

  public async Task<IActionResult> Update(int id)
  {
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"{Request.Scheme}://{Request.Host}/Student/{id}"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        var s = JsonConvert.DeserializeObject<UpdateStudentRequest>(apiResponse);
        return View(s);
      }
    }
  }

  [HttpPost]
  public async Task<IActionResult> Update(int id, UpdateStudentRequest s)
  {
    if (ModelState.IsValid)
    {
      using (var httpClient = new HttpClient())
      {
        HttpResponseMessage response = await httpClient.PutAsJsonAsync($"{Request.Scheme}://{Request.Host}/Student/{id}", s);
        return RedirectToAction("Read");
      }
    }
    else
      return View();
  }

  public async Task<IActionResult> ReadById(int id)
  {
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"{Request.Scheme}://{Request.Host}/Student/{id}"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        var s = JsonConvert.DeserializeObject<StudentRecord>(apiResponse!);
        return View(s);
      }
    }
  }

  [HttpPost]
  public async Task<IActionResult> Delete(int id)
  {
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.DeleteAsync($"{Request.Scheme}://{Request.Host}/Student/{id}"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
      }
    }

    return RedirectToAction("Read");
  }

  public async Task<IActionResult> ReadByPaging(int id)
  {
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"{Request.Scheme}://{Request.Host}/Student/Paging/{id}"))
      {
        string apiResponse = await response.Content.ReadAsStringAsync();
        var s = JsonConvert.DeserializeObject<StudentPagingRecord>(apiResponse);
        return View(s);
      }
    }
  }
}

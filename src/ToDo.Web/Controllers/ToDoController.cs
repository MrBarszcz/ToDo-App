using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDo.Web.Models;

namespace ToDo.Web.Controllers;

public class ToDoController : Controller {
    public IActionResult Create() {
        return View();
    }

}

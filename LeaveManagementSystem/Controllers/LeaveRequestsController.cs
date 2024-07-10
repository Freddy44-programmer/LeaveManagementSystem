using LeaveManagementSystem.Models.LeaveRequests;
using LeaveManagementSystem.Services.LeaveRequests;
using LeaveManagementSystem.Services.LeaveTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Controllers;

[Authorize]
public class LeaveRequestsController(ILeaveTypesService _leaveTypesService, ILeaveRequestsService _leaveRequestsService) : Controller
{
    // Employee View requests
    public async Task<IActionResult> Index()
    {
        return View();
    }


    // Employee Create requests
    public async Task<IActionResult> Create()
    {
        var leaveTypes = await _leaveTypesService.GetAll();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name");
        var model = new LeaveRequestCreateVM
        {
           StartDate = DateOnly.FromDateTime(DateTime.Now),
           EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
           LeaveTypes= leaveTypesList,
        };

        return View(model);
    }



    // Employee Create requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {
        // Validate that the days don't exceed the allocation
        if(await _leaveRequestsService.RequestDatesExceedAllocation(model))
        {
            ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
            ModelState.AddModelError(nameof(model.EndDate), "The number of days requested is invalid.");
        }
        if (ModelState.IsValid)
        {
            await _leaveRequestsService.CreateLeaveRequest(model);
        }

        var leaveTypes = await _leaveTypesService.GetAll();
        model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
        return View(model);
    }


    // Employee Cancel requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel( int leaveRequestId)
    {
        return View();
    }



    // Admin/Super review request
    public async Task<IActionResult> ListRequests()
    {
        return View();
    }


    // Admin/Super review request
    public async Task<IActionResult> Review(int leaveRequestId)
    {
        return View();
    }



    // Admin/Super review request
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Review(/*Use View Model*/)
    {
        return View();
    }
}

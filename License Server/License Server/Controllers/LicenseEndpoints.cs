using Azure.Core;
using License_Server.Data;
using License_Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Route("api/licenses")]
public class LicenseEndpoints : ControllerBase
{
    private readonly LicenseServerDBContext _context;

    public LicenseEndpoints(LicenseServerDBContext context)
    {
        _context = context;
    }

    [HttpPost("generate")]
    public IActionResult GenerateLicense([FromBody] License license)
    {
        license.Id = Guid.NewGuid();
        _context.Licenses.Add(license);
        _context.SaveChanges();

        return Ok(license);
    }

    [HttpPost("claim")]
    public IActionResult ActivateLicense(string licenseKey, string userid)
    {
        var license = _context.Licenses.FirstOrDefault(l => l.LicenseKey == licenseKey);
        if (license == null)
            return NotFound("License key not found.");

        if (license.IsClaimed)
            return BadRequest("License already claimed.");

        license.IsClaimed = true;
        license.UserID = userid; 
        _context.SaveChanges();

        return Ok("License claimed successfully.");
    }

    [HttpGet("validate/{userID}")]
    public IActionResult GetLicenseLevel(string userID)
    {
        var license = _context.Licenses.FirstOrDefault(l => l.UserID == userID && l.ExpiryDate >= DateTime.Today);

        if (license == null)
            return NotFound("No active license found for this user.");

        return Ok(new
        {
            LicenseLevel = license.LicenseLevel,
            ExpiryDate = license.ExpiryDate
        });
    }

    [HttpGet("all")]
    public IActionResult GetAllLicense()
    {
        var license = _context.Licenses.Select(l => new
        {
            LicenseID = l.Id,
            Key = l.LicenseKey,
            LicenseLevel = l.LicenseLevel,
            ExpiryDate = l.ExpiryDate,
            IsClaimed = l.IsClaimed,
            UserID = l.UserID
        }).ToList();

        if (!license.Any())
        {
            return NotFound("sike!");
        }

        return Ok(license);
    }
}

﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLib;

namespace BlankBlazorApp.Controllers;

/// <summary>
/// TinyMCEditorController Route("api/[controller]/[action]")
/// </summary>
[Route("[controller]/[action]"), ApiController]
[AllowAnonymous]
public class TinyMCEditorController(IStorageTransmission storeRepo) : ControllerBase
{
    /// <summary>
    /// Upload Image
    /// </summary>
    [HttpPost($"{GlobalStaticConstants.TinyMCEditorUploadImage}{{AppNameStorage}}/{{NameStorage}}")]
    public async Task<IActionResult> UploadImage(
        [FromRoute] string AppNameStorage,
        [FromRoute] string NameStorage,
        [FromQuery] string? PrefixPropertyName,
        [FromQuery] int? OwnerPrimaryKey,
        IFormFile file)
    {
        System.Security.Claims.ClaimsPrincipal user = HttpContext.User;
        string un = user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")!.Value;

        if (user.Identity?.IsAuthenticated != true || string.IsNullOrWhiteSpace(un))
            return StatusCode(401, new { location = "/img/unauthorizedimage.png" });

        if (string.IsNullOrWhiteSpace(AppNameStorage) || string.IsNullOrWhiteSpace(NameStorage))
            return StatusCode(401, new { location = "/img/errorimage.png" });

        using MemoryStream ms = new();

        await file.CopyToAsync(ms);
        byte[] payload = ms.ToArray();
        string? file_name = file.Name;

        System.Net.Http.Headers.ContentDispositionHeaderValue cdd = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition);
        if (!string.IsNullOrWhiteSpace(cdd.FileName))
            file_name = cdd.FileName;

        if (file_name.StartsWith('"') && file_name.EndsWith('"'))
            file_name = file_name[1..^1];


        if (string.IsNullOrWhiteSpace(file_name))
            file_name = $"Без имени: {DateTime.UtcNow}";

        if (payload.Length == 0)
            return StatusCode(500, new { location = "/img/unauthorizedimage.png" });


        StorageImageMetadataModel req = new()
        {
            Referrer = HttpContext.Request.Headers["Referer"].FirstOrDefault(),
            PrefixPropertyName = PrefixPropertyName,
            ApplicationName = AppNameStorage,
            OwnerPrimaryKey = OwnerPrimaryKey,
            Payload = payload,
            PropertyName = NameStorage,
            AuthorUserIdentity = un,
            FileName = file_name,
            ContentType = file.ContentType,
        };

        TResponseModel<StorageFileModelDB> rest = await storeRepo.SaveFileAsync(new() { Payload = req, SenderActionUserId = GlobalStaticConstantsRoles.Roles.System });
        if (!rest.Success() || rest.Response is null || rest.Response.Id < 1)
            return StatusCode(500, new { location = "/img/noimage-simple.png" });

        return Ok(new { location = $"/cloud-fs/read/{rest.Response.Id}/{rest.Response.FileName}" });
    }
}
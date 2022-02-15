using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWatchList.Account.Application.Extensions;
using MyWatchList.Account.Domain.Domain;
using MyWatchList.Account.Domain.Domain.ViewModels;
using MyWatchList.Account.Services.Services;
using SecureIdentity.Password;

namespace MyWatchList.Account.Application.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AccountController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("v1/accounts/")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterViewModel model,
        [FromServices] AccountService service
        )
    {
        if (!ModelState.IsValid)
            return BadRequest(new
            {
                success = false,
                message = "Unable to create account, check the payload"
            });
        
        var account = new Domain.Domain.Account(model.Email);
        var password = PasswordGenerator.Generate(25);
        account.PasswordHash = PasswordHasher.Hash(password);
        
        try
        {
            await service.Post(account);
            return Ok(new ResultViewModel<dynamic>(new
            {
                account = account.Email,
                password,
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(
                500,
                new ResultViewModel<string>("Account was already created.")
            );
        }
        catch
        {
            return StatusCode(
                500,
                new ResultViewModel<string>("Internal error")
            );
        }
    }
    
    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginViewModel model,
        [FromServices] AccountService service)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var account = await service.GetByEmail(model.Email);

        if (account == null)
            return StatusCode(401, new ResultViewModel<string>("Wrong user or password"));

        if (!PasswordHasher.Verify(account.PasswordHash, model.Password))
            return StatusCode(401, new ResultViewModel<string>("Wrong user or password"));

        try
        {
            var token = _tokenService.GenerateToken(account);
            return Ok(new ResultViewModel<string>(token, errors: null!));
        }
        catch
        {
            return StatusCode(
                500,
                new ResultViewModel<string>("Internal Error")
            );
        }
    }
    
    //TODO: Endpoint de troca de senha
    //TODO: Endpoint de validar token
}
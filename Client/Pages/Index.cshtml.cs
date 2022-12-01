using Client.Interfaces;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages;

public class IndexModel : PageModel
{
    private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty]
    public List<AccountModel> listAccounts { get; set; } = new List<AccountModel>();

    [BindProperty]
    public AccountModel Account { get; set; }

    [TempData]
    public string Message { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        listAccounts.Clear();
        listAccounts = await _accountService.Get();
        return Page();
    }

    public async Task<IActionResult> OnPostInsertAsync(EditAccountModel account)
    {
        Message = "";

        var result = await _accountService.Insert(account);
        if (!result)
        {
            Message = "Não foi possível remover a conta selecionada.";
        }

        Message = "Conta removida com sucesso!";
        return RedirectToPage("/Account/AccountPage/index");

        return Page();
    }

    public async  Task<IActionResult> OnPostDeleteAsync(string id)
    {
        Message = "";

        if (string.IsNullOrEmpty(id)) Message = "Dados incorretos."; ;

        var result = await _accountService.Delete(id);
        if (!result) {
            Message = "Não foi possível remover a conta selecionada.";
        }
       
        Message = "Conta removida com sucesso!";
        return RedirectToPage("/Account/AccountPage/index");

        return Page();
    }

}

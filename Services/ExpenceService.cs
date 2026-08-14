using Balance.Models;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Balance.Services;

public class ExpenseService
{
    private readonly List<Expense> _expenses = new();

    private readonly IJSRuntime _jsRuntime;
    public IReadOnlyList<Expense> Expenses => _expenses;

    public ExpenseService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task AddExpenseAsync(Expense expense)
    {
        expense.Id = _expenses.Count + 1;
        _expenses.Add(expense);

        await SaveAsync();
    }

    public async Task DeleteExpenseAsync(int id)
    {
        var expense = _expenses.FirstOrDefault(expense => expense.Id == id);

        if (expense != null)
        {
            _expenses.Remove(expense);
            await SaveAsync();
        }
    }

    public decimal GetBalance()
    {
        decimal balance = 0;

        foreach (var expense in _expenses)
        {
            decimal myPart = expense.Amount * expense.MyShare / 100;
            decimal partnerPart = expense.Amount - myPart;

            if (expense.PaidBy == "Me")
            {
                balance += partnerPart;
            }
            else if (expense.PaidBy == "Partner")
            {
                balance -= myPart;
            }
        }

        return balance;
    }

    private async Task SaveAsync()
    {
        string json = JsonSerializer.Serialize(_expenses);

        await _jsRuntime.InvokeVoidAsync(
            "localStorage.setItem",
            "balance-expenses",
            json
        );
    }

    public async Task LoadAsync()
    {
        string? json = await _jsRuntime.InvokeAsync<string?>(
            "localStorage.getItem",
            "balance-expenses"
        );

        if (string.IsNullOrWhiteSpace(json))
        {
            return;
        }

        List<Expense>? savedExpenses =
            JsonSerializer.Deserialize<List<Expense>>(json);

        if (savedExpenses == null)
        {
            return;
        }

        _expenses.Clear();
        _expenses.AddRange(savedExpenses);
    }
}
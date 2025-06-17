using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

using System.Linq;

using System;

public class IndexModel : PageModel
{
    public string SearchTerm { get; set; } = "";
    public List<Invoice> Invoices { get; set; } = new();

    public void OnGet(string? search)
    {
        SearchTerm = search ?? "";
        
        // Sample invoice data
        var allInvoices = new List<Invoice>
        {
            new Invoice { Id = 1001, CustomerName = "Acme Corp", Amount = 1500.00m },
            new Invoice { Id = 1002, CustomerName = "Tech Solutions", Amount = 3200.50m },
            new Invoice { Id = 1003, CustomerName = "Global Industries", Amount = 890.75m }
        };

        if (!string.IsNullOrEmpty(SearchTerm))
        {
            Invoices = allInvoices.Where(i => 
                i.CustomerName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                i.Id.ToString().Contains(SearchTerm)
            ).ToList();
        }
    }
}

public class Invoice
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public decimal Amount { get; set; }
}

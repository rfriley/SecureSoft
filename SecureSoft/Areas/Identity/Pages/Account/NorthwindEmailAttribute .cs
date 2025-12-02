using System.ComponentModel.DataAnnotations;

namespace SecureSoft.Areas.Identity.Pages.Account
{
    public class NorthwindEmailAttribute : ValidationAttribute
    {
        public NorthwindEmailAttribute()
        {
            ErrorMessage = "Email must be a @northwind.com address.";
        }

        public override bool IsValid(object? value)
        {
            if (value is string email)
            {
                return email.EndsWith("@northwind.com", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}

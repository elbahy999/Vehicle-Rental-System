using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace projjjjj
{
    public static class CustomerValidator
    {
        // ── Validation Result ──────────────────────────────────────────────────
        public class ValidationResult
        {
            public bool IsValid { get; set; } = true;
            public List<string> Errors { get; set; } = new List<string>();

            public void AddError(string message)
            {
                IsValid = false;
                Errors.Add(message);
            }

            public string ErrorSummary => string.Join("\n", Errors);
        }

        // ── Main Validator ─────────────────────────────────────────────────────
        public static ValidationResult Validate(Customer c)
        {
            var result = new ValidationResult();

            ValidateName(c.FirstName, "First Name", result);
            ValidateName(c.LastName, "Last Name", result);
            ValidatePhone(c.PhoneNumber, result);
            ValidateEmail(c.Email, result);

            return result;
        }

        // ── Field Rules ────────────────────────────────────────────────────────

        private static void ValidateName(string name, string fieldLabel, ValidationResult result)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddError($"{fieldLabel} is required.");
                return;
            }
            if (name.Trim().Length < 2)
                result.AddError($"{fieldLabel} must be at least 2 characters.");

            if (name.Trim().Length > 50)
                result.AddError($"{fieldLabel} must not exceed 50 characters.");

            if (!Regex.IsMatch(name.Trim(), @"^[a-zA-Z\s\-']+$"))
                result.AddError($"{fieldLabel} must contain letters only.");
        }

        private static void ValidatePhone(string phone, ValidationResult result)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                result.AddError("Phone number is required.");
                return;
            }
           
            string cleaned = Regex.Replace(phone, @"[\s\-\(\)\+]", "");
            if (!Regex.IsMatch(cleaned, @"^\d{10,15}$"))
                result.AddError("Phone number must be 10–15 digits (spaces, dashes, and + allowed).");
        }

        private static void ValidateEmail(string email, ValidationResult result)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                result.AddError("Email is required.");
                return;
            }
            if (!Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                result.AddError("Email address is not valid.");

            if (email.Trim().Length > 100)
                result.AddError("Email must not exceed 100 characters.");
        }
    }
}

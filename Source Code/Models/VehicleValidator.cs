using System;
using System.Text.RegularExpressions;

namespace projjjjj
{
    public static class VehicleValidator
    {
        // ── Main Validator ─────────────────────────────────────────────────────
        public static void Validate(Vehicle v)
        {
            ValidatePlate(v.Plate);
            ValidateText(v.VehicleType, "Vehicle Type", 2, 50);
            ValidateText(v.Brand, "Brand", 1, 50);
            ValidateDailyRate(v.DailyRate);
        }

        // ── Field Rules ────────────────────────────────────────────────────────
        private static void ValidatePlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                throw new Exception("License plate is required.");

            string cleaned = plate.Trim().ToUpper();

            if (cleaned.Length < 2 || cleaned.Length > 10)
                throw new Exception("License plate must be 2–10 characters.");

            if (!Regex.IsMatch(cleaned, @"^[A-Z0-9\-\s]+$"))
                throw new Exception("License plate may only contain letters, digits, spaces, and dashes.");
        }

        private static void ValidateText(string value, string label, int min, int max)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"{label} is required.");

            int len = value.Trim().Length;

            if (len < min)
                throw new Exception($"{label} must be at least {min} characters.");

            if (len > max)
                throw new Exception($"{label} must not exceed {max} characters.");
        }

        private static void ValidateDailyRate(decimal rate)
        {
            if (rate <= 0)
                throw new Exception("Daily rate must be greater than zero.");

            if (rate > 99999)
                throw new Exception("Daily rate seems unrealistically high. Please check the value.");
        }
    }
}

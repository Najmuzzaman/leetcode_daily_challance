public class Solution {
    private const string ELECTRONICS = "electronics";
    private const string GROCERY = "grocery";
    private const string PHARMACY = "pharmacy";
    private const string RESTAURANT = "restaurant";

    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive) {
        var validElectronicsCodes = new List<string>();
        var validGroceryCodes = new List<string>();
        var validPharmacyCodes = new List<string>();
        var validRestaurantCodes = new List<string>();

        for (int i=0; i<code.Length; i++) {
            if (!isActive[i])
                continue;

            var currentCode = code[i];
            var currentBusiness = businessLine[i];

            if (!IsValidCode(currentCode) || !IsValidBusiness(currentBusiness))
                continue;
            
            switch (currentBusiness) {
                case ELECTRONICS:
                    validElectronicsCodes.Add(currentCode);
                    continue;
                case GROCERY:
                    validGroceryCodes.Add(currentCode);
                    continue;
                case PHARMACY:
                    validPharmacyCodes.Add(currentCode);
                    continue;
                // case "restaurant":
                default:
                    validRestaurantCodes.Add(currentCode);
                    continue;
            }
        }

        validElectronicsCodes.Sort(StringComparer.Ordinal);
        validGroceryCodes.Sort(StringComparer.Ordinal);
        validPharmacyCodes.Sort(StringComparer.Ordinal);
        validRestaurantCodes.Sort(StringComparer.Ordinal);

        return new[] { validElectronicsCodes, validGroceryCodes, validPharmacyCodes, validRestaurantCodes }
            .SelectMany(x => x)
            .ToList();
    }

    private bool IsValidCode(string code) {
        return !String.IsNullOrEmpty(code) && code.All(c => char.IsLetterOrDigit(c) || c == '_');
    }

    private bool IsValidBusiness(string business) {
        switch (business) {
            case ELECTRONICS:
            case GROCERY:
            case PHARMACY:
            case RESTAURANT:
                return true;
            default:
                return false;
        }
    }
}
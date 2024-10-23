using System.Text.RegularExpressions;

namespace CNPJAlphanumericValidator;

public class CNPJValidator
{
    private const int CNPJ_LENGTH_WITHOUT_DV = 12;
    private const string REGEX_FORMATTING_CHARACTERS = "[./-]";
    private const string REGEX_CNPJ_BASE_FORMAT = "[A-Z\\d]{12}";
    private const string REGEX_DV_FORMAT = "\\d{2}";
    private const string REGEX_ZERO_VALUE = "^[0]+$";
    private const int BASE_VALUE = (int)'0';
    private static readonly int[] DV_WEIGHTS = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public static bool IsValid(string cnpj)
    {
        if (!string.IsNullOrEmpty(cnpj))
        {
            cnpj = RemoveFormattingCharacters(cnpj);
            if (IsCnpjValidWithDv(cnpj))
            {
                string providedDV = cnpj.Substring(CNPJ_LENGTH_WITHOUT_DV);
                string calculatedDV = CalculateDv(cnpj.Substring(0, CNPJ_LENGTH_WITHOUT_DV));
                return calculatedDV.Equals(providedDV);
            }
        }
        return false;
    }

    public static string CalculateDv(string baseCnpj)
    {
        if (!string.IsNullOrEmpty(baseCnpj))
        {
            baseCnpj = RemoveFormattingCharacters(baseCnpj);
            if (IsCnpjValidWithoutDv(baseCnpj))
            {
                string dv1 = CalculateDigit(baseCnpj).ToString();
                string dv2 = CalculateDigit(baseCnpj + dv1).ToString();
                return dv1 + dv2;
            }
        }
        throw new ArgumentException($"CNPJ {baseCnpj} is not valid for DV calculation");
    }

    private static int CalculateDigit(string cnpj)
    {
        int sum = 0;
        for (int index = cnpj.Length - 1; index >= 0; index--)
        {
            int characterValue = (int)cnpj[index] - BASE_VALUE;
            sum += characterValue * DV_WEIGHTS[DV_WEIGHTS.Length - cnpj.Length + index];
        }
        return sum % 11 < 2 ? 0 : 11 - (sum % 11);
    }

    private static string RemoveFormattingCharacters(string cnpj)
    {
        return Regex.Replace(cnpj.Trim(), REGEX_FORMATTING_CHARACTERS, string.Empty);
    }

    private static bool IsCnpjValidWithoutDv(string cnpj)
    {
        return Regex.IsMatch(cnpj, REGEX_CNPJ_BASE_FORMAT) && !Regex.IsMatch(cnpj, REGEX_ZERO_VALUE);
    }

    private static bool IsCnpjValidWithDv(string cnpj)
    {
        return Regex.IsMatch(cnpj, REGEX_CNPJ_BASE_FORMAT + REGEX_DV_FORMAT) && !Regex.IsMatch(cnpj, REGEX_ZERO_VALUE);
    }
}
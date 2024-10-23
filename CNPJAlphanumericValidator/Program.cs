using CNPJAlphanumericValidator;

Console.WriteLine("CNPJ Alphanumeric Validator");
            
// Exemplo 1 - CNPJ Válido

var validCnpj = "12ABC34501DE35";
Console.WriteLine($"Validating CNPJ: {validCnpj}");
var isValid = CNPJValidator.IsValid(validCnpj);
Console.WriteLine($"Is the CNPJ {validCnpj} valid? {isValid}\n");

// Exemplo 2 - CNPJ Inválido

var invalidCnpj = "12ABC34501DE99";
Console.WriteLine($"Validating CNPJ: {invalidCnpj}");
isValid = CNPJValidator.IsValid(invalidCnpj);
Console.WriteLine($"Is the CNPJ {invalidCnpj} valid? {isValid}\n");

// Exemplo 3 - Cálculo dos dígitos verificadores

var baseCnpj = "12ABC34501DE";
Console.WriteLine($"Calculating DV for CNPJ: {baseCnpj}");
var calculatedDv = CNPJValidator.CalculateDv(baseCnpj);
Console.WriteLine($"Calculated DV: {calculatedDv}");
Console.WriteLine($"Complete CNPJ: {baseCnpj}{calculatedDv}");
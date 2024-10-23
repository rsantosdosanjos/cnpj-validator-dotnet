
# CNPJ Alphanumeric Validator

This project is a simple .NET console application for validating and calculating the verification digits (DVs) of alphanumeric CNPJ numbers. The CNPJ is composed of 12 alphanumeric characters followed by 2 numeric verification digits.

## Features

- Validate an alphanumeric CNPJ (12 alphanumeric characters + 2 verification digits)
- Calculate the verification digits (DVs) from a CNPJ base (without the DVs)

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher recommended)

## How to Run

1. Clone this repository or download the project files.
2. Open a terminal and navigate to the project's directory.
3. Run the following command to build and run the console application:
    ```bash
    dotnet run
    ```

## Example Usage

Here’s how the application works:

1. The application will validate whether a given CNPJ is valid or not based on the algorithm.
2. It will also calculate the verification digits for a CNPJ base (the first 12 characters without the DVs).

### Example Input/Output

#### Validating a CNPJ:

For a valid CNPJ:

```bash
Validating CNPJ: 12ABC34501DE35
Is the CNPJ 12ABC34501DE35 valid? True
```

For an invalid CNPJ:

```bash
Validating CNPJ: 12ABC34501DE99
Is the CNPJ 12ABC34501DE99 valid? False
```

#### Calculating the Verification Digits (DV):

```bash
Calculating DV for CNPJ: 12ABC34501DE
Calculated DV: 35
Complete CNPJ: 12ABC34501DE35
```

## How to Modify

If you want to change the CNPJ examples for testing, you can update the strings in the `Program.cs` file under the `Main` method:

```csharp
string validCnpj = "12ABC34501DE35";  // Example of a valid CNPJ
string invalidCnpj = "12ABC34501DE99";  // Example of an invalid CNPJ
string baseCnpj = "12ABC34501DE";  // CNPJ base for DV calculation
```

## Code Structure

- `CNPJValidator.cs`: Contains the logic for validating and calculating CNPJ verification digits.
- `Program.cs`: Entry point of the application, where example usage is shown.
- `README.md`: Instructions on how to use the application..

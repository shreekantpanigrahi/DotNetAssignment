using Question_1.Exceptions;
namespace Question_1
{
    internal class Program
    {
        static List<string> validAccounts = new List<string> { "12345", "67890", "54321" };
        static void Main(string[] args)
        {
            #region question 1
            //Implement exception handling in C# to manage cases where a
            //user enters an incorrect or non - existent beneficiary account
            //number ?

            try
            {
                Console.Write("Enter Beneficiary Account Number: ");
                string input = Console.ReadLine();

                // Check if input is empty
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new ArgumentNotFoundException("Account number cannot be empty.");
                }

                // Check if input is numeric
                if (!long.TryParse(input, out _))
                {
                    throw new InvalidFormatException("Invalid format! Account number must be numeric.");
                }

                // Check if account exists
                if (!validAccounts.Contains(input))
                {
                    throw new KeyNotContainException("Account number does not exist. Please check and try again.");
                }

                Console.WriteLine("Transaction successful! Beneficiary account verified.");
            }
            catch (InvalidFormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (KeyNotContainException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex) // Catch any other unforeseen errors
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            #endregion

        }
    }

}
   

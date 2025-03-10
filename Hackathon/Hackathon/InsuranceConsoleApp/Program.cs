using InsuranceConsoleApp.Repository;
using InsuranceConsoleApp.Model;
using static InsuranceConsoleApp.Model.Policy;
using InsuranceConsoleApp.Exceptions;

namespace InsuranceConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            PolicyRepository policyRepository = new PolicyRepository();
            UserRepository userRepository = new UserRepository();

            Console.WriteLine("Welcome to the Insurance Console App!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");

            while (true)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    RegisterUser(userRepository);
                }
                else if (input == "2")
                {
                    if (LoginUser(userRepository))
                    {
                        Console.WriteLine("Login successful! Welcome to the main menu.");
                        ShowMainMenu(policyRepository);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                }
            }

            
        }

        private static void RegisterUser(UserRepository userRepository)
        {
            Console.WriteLine("\n--- Register ---");
            Console.Write("Enter a username: ");
            string username = Console.ReadLine();

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            try
            {
                var newUser = new User(username, password);
                userRepository.Register(newUser);
                Console.WriteLine("Registration successful!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool LoginUser(UserRepository userRepository)
        {
            Console.WriteLine("\n--- Login ---");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            return userRepository.Login(username, password);
        }

        private static void ShowMainMenu(PolicyRepository repository)
        {
            Console.WriteLine("Welcome to YourInsuranceApp!");
            while (true)
            {
                Console.WriteLine("\nMenu:\n" +
                 "1. Add Policy\n" +
                 "2. View All Policies\n" +
                 "3. Search Policy\n" +
                 "4. Update Policy\n" +
                 "5. Delete Policy\n" +
                 "6. View Active Policies\n" +
                 "7. Toggle Policy Status (Active/Inactive)\n" +
                 "8. View Inactive Policies\n" +
                 "9. Exit");

                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalid choice. Please enter 1-7.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddNewPolicy(repository);
                            break;
                        case 2:
                            DisplayPolicies(repository.GetAllPolicies());
                            break;
                        case 3:
                            SearchPolicy(repository);
                            break;
                        case 4:
                            UpdatePolicy(repository);
                            break;

                        case 5:
                            DeletePolicy(repository);
                            break;
                        case 6:
                            DisplayPolicies(repository.GetActivePolicies());
                            break;
                        case 7:
                            ToggleActiveInactiveLogic(repository);
                            break;
                        case 8:
                            InActivePolicies(repository);
                            break;
                        case 9:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void InActivePolicies(PolicyRepository repository)
        {
            Console.WriteLine("Viewing inactive policies...");
            var inactivePolicies = repository.GetInactivePolicies();
            if (inactivePolicies.Count == 0)
            {
                Console.WriteLine("No inactive policies found.");
            }
            else
            {
                foreach (var policy in inactivePolicies)
                {
                    Console.WriteLine(policy + "\n");
                }
            }
        }

        private static void ToggleActiveInactiveLogic(PolicyRepository repository)
        {
            Console.WriteLine("Toggling Policy Status...");
            Console.Write("Enter Policy ID: ");
            if (int.TryParse(Console.ReadLine(), out int toggleId))
            {
                try
                {
                    var policy = repository.SearchPolicy(toggleId);
                    Console.WriteLine("\nCurrent Status:");
                    Console.WriteLine(policy);

                    Console.Write("Toggle status? (Y/N): ");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        repository.TogglePolicyStatus(toggleId);
                        Console.WriteLine($"Policy status toggled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Status toggle canceled.");
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Policy ID.");
            }
        }

        private static void AddNewPolicy(PolicyRepository repository)
        {
            Console.WriteLine("\n--- Add New Policy ---");
            var policy = CreatePolicyFormInput();
            repository.AddPolicy(policy);
            Console.WriteLine("Policy added successfully!");
        }

        private static void SearchPolicy(PolicyRepository repository)
        {
            Console.Write("Enter Policy ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var policy = repository.SearchPolicy(id);
                Console.WriteLine("\nPolicy Details:\n" + policy);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private static void UpdatePolicy(PolicyRepository repository)
        {
            Console.WriteLine("Updating policy details...");
            Console.Write("Enter Policy ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int updateId))
            {
                var existing = repository.SearchPolicy(updateId);
                Console.WriteLine("\nCurrent Details:\n" + existing);

                Console.Write("New Holder Name (Enter to keep current): ");
                string newNameInput = Console.ReadLine();
                string newName = string.IsNullOrEmpty(newNameInput) ? existing.PolicyHolderName : newNameInput;

                Console.Write("New Policy Type (Enter to keep current): ");
                string typeInput = Console.ReadLine();
                PolicyTypeEnum newType = string.IsNullOrEmpty(typeInput)
                    ? existing.PolicyType
                    : ParsePolicyType();

                Console.Write($"New End Date (current: {existing.PolicyEndDate:yyyy-MM-dd}, Enter to keep current): ");
                string endDateInput = Console.ReadLine();
                DateTime newEndDate = string.IsNullOrEmpty(endDateInput)
                    ? existing.PolicyEndDate
                    : ParseDate();

                var updatedPolicy = new Policy(
                    existing.PolicyId,
                    newName,
                    newType,
                    existing.PolicyStartDate, // Keep original start date
                    newEndDate);

                repository.UpdatePolicy(updateId, updatedPolicy);
                Console.WriteLine("Policy updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private static void DeletePolicy(PolicyRepository repository)
        {
            Console.Write("Enter Policy ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    repository.SearchPolicy(id); // Verify existence
                    Console.Write("Confirm deletion (Y/N): ");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        repository.DeletePolicy(id);
                        Console.WriteLine("Policy deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion canceled.");
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private static Policy CreatePolicyFormInput()
        {
            Console.Write("Policy Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Policy Type (Life/Health/Vehicle/Travel): ");
            var type = ParsePolicyType();

            Console.Write("Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Now;
            Console.WriteLine(startDate);

            Console.Write("End Date (yyyy-MM-dd): ");
            DateTime endDate = ParseDate();

            return new Policy(0, name, type, startDate, endDate);
        }

        private static PolicyTypeEnum ParsePolicyType()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (Enum.TryParse(input, true, out PolicyTypeEnum type) &&
                    Enum.IsDefined(typeof(PolicyTypeEnum), type))
                {
                    return type;
                }
                Console.Write("Invalid type. Please enter Life/Health/Vehicle/Travel: ");
            }
        }

        private static DateTime ParseDate()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime date))
                    return date;
                Console.Write("Invalid date. Please use yyyy-MM-dd: ");
            }
        }

        private static void DisplayPolicies(List<Policy> policies)
        {
            if (policies.Count == 0)
            {
                Console.WriteLine("No policies found.");
                return;
            }

            Console.WriteLine("\n--- Policies ---");
            foreach (var policy in policies)
            {
                Console.WriteLine(policy + "\n");
            }
        }
    }
}
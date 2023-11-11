bool isValidInput = false;

while (!isValidInput)
{
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    if (int.TryParse(choice, out int option))
    {
        // Process the user's choice
        isValidInput = ProcessUserChoice(option);
    }
    else
    {
        Console.WriteLine($"Invalid input: '{choice}' is not a valid number. Please enter a number.");
    }
}

// Separate method to handle user's choice
bool ProcessUserChoice(int option)
{
    switch (option)
    {
        case 1:
            // Handle option 1
            Console.WriteLine("Option 1 selected.");
            return true;
        case 2:
            // Handle option 2
            Console.WriteLine("Option 2 selected.");
            return true;
        // ... handle other cases ...
        case 6:
            // Handle option 6 (Quit)
            Console.WriteLine("Quitting the program.");
            return true;
        default:
            Console.WriteLine("Invalid choice. Please select a valid option.");
            return false;
    }
}

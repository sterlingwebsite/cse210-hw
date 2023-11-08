public class ProgramManager
{
    public void StartActivity(Activity activity)
    {
        try
        {
            Console.Clear();
            activity.OpeningPrompt();
            activity.SecondPrompt();
            activity.StartActivity();
            activity.CompletedPrompt();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        ProgramManager programManager = new ProgramManager();
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.SetActivityType("Breathing Activity");
                breathingActivity.SetActivityDescription("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                programManager.StartActivity(breathingActivity);
            }
            else if (choice == 2)
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.SetActivityType("Reflecting Activity");
                reflectingActivity.SetActivityDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                programManager.StartActivity(reflectingActivity);
            }
            else if (choice == 3)
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.SetActivityType("Listing Activity");
                listingActivity.SetActivityDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                programManager.StartActivity(listingActivity);
            }
            else if (choice != 4)
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                Console.ReadLine();
            }
        }
    }
}

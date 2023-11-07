public class ProgramManager
{
    public void StartActivity(Activity activity)
    {
        // activity.OpeningPrompt();
        activity.StartActivity();
    }

    public static void Main(string[] args)
    {
        ProgramManager programManager = new ProgramManager();
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Choose and activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.SetActivityType("Breathing Activity");
                string activityType = breathingActivity.GetActivityType();
                breathingActivity.SetActivityDescription("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                string activityDescription = breathingActivity.GetActivityDescription();
                programManager.StartActivity(breathingActivity);
                // uncomment the following to test the attribute passing technique
                // Console.WriteLine($"Attribute value from Breathing Activity: {activityType}");
                // Console.ReadLine();
            }
            else if (choice == 2)
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.SetActivityType("Reflecting Activity");
                programManager.StartActivity(reflectingActivity);
                string activityType = reflectingActivity.GetActivityType();
                // Console.WriteLine($"Attribute value from Reflecting Activity: {activityType}");
                // Console.ReadLine();
            }
            else if (choice == 3)
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.SetActivityType("Listing Activity");
                programManager.StartActivity(listingActivity);
                string activityType = listingActivity.GetActivityType();
                // Console.WriteLine($"Attribute value from Listing Activity: {activityType}");
                // Console.ReadLine();
            }
            else if (choice != 4)
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                Console.ReadLine();
            }
        }
    }
}

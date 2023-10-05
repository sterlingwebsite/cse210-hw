// prompt manager class
// managing the prompts
// what data this should store?
// prompts
// which prompts to say
// Include a list of prompts as well as methods for getting a random prompt from the list.
// list of prompts: Who was the most interesting person I interacted with today?, What was the best part of my day?, How did I see the hand of the Lord in my life today?, What was the strongest emotion I felt today?, If I had one thing I could do over today, what would it be?
// methods for getting a random prompt from a list
// how do i come up with these methods?

// should have properties and methods
// property: Prompts List: A list to store different prompts. Each prompt in the list is a string representing a question or a statement for the user to respond to.
// How do I create the list to store different prompts?
// methods: AddPrompt(prompt: string): This method allows you to add a new prompt to the list of prompts. It takes a string (prompt) as a parameter and adds it to the list. GetRandomPrompt(): string: This method returns a random prompt from the list of prompts. You can generate a random index and use it to retrieve a prompt from the list. RemovePrompt(prompt: string): This method allows you to remove a specific prompt from the list based on its content. If needed, you can implement a way to remove prompts dynamically.
// How do I create the AddPrompt(prompt: string) method?
// What does the "prompt: string" mean in AddPrompt(prompt: string)?
// How do I get the AddPrompt method to take a string (prompt) as a parameter?
// How do I get it to add it to the list?
// Where is the list or how do I create it?
// How do I create the GetRandomPrompt() method?
// How do I generate a random index?
// How do I use the random index to retreive a prompt from the list?
// How do I create the RemovePrompt method?
// How can I implement a way to remove prompts dynamically?

// How do I get the prompt manager class to store a list of prompts?
using System;
using System.Collections.Generic;
public class PromptManager
{
    private List<string> prompts;
    public PromptManager()
    {
        prompts = new List<string>();
        InitializeDefaultPrompts();
    }
    public void AddPrompt(string prompt)
    {
        prompts.Add(prompt);
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];        
    }
    public void RemovePrompt(string prompt)
    {
        prompts.Remove(prompt);
    }
    private void InitializeDefaultPrompts()
    {
        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
    }
}

// By creating an instance of the PromptManager class, you can manage and manipulate the list of prompts for your journal application. For example:
// csharp
// Copy code
// PromptManager promptManager = new PromptManager();
// string randomPrompt = promptManager.GetRandomPrompt();
// Console.WriteLine("Random Prompt: " + randomPrompt);
// This code snippet demonstrates how to create a PromptManager object, get a random prompt, and print it to the console. You can integrate this functionality into your journal application to display prompts to the users.
static List<Base> goalsList = new List<Base>();

        // Create some Base objects and add them to the list
        Base item1 = new Base("cheese", 10);
        Base item2 = new Base("milk", 11);

        goalsList.Add(item1);
        goalsList.Add(item2);

        static List<Base> LoadGoalsFromFile()
        {
            // List<Base> goalsList = new List<Base>();
            string fileName = "goals.txt";

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string goal = parts[0];
                        int points;
                        if (int.TryParse(parts[1], out points))
                        {
                            bool isCompleted;
                            if (bool.TryParse(parts[2], out isCompleted))
                            {
                                Base goalList = new Base { Goal = goal, Points = points, IsCompleted = isCompleted };
                                goalsList.Add(goalsList);
                            }
                        }
                    }
                }
            }
        }

static List<Base> LoadGoalsFromFile()
    {
        // List<object> goalsList = new List<object>();
        string fileName = "goals.txt";

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string goal = parts[0];
                    int points;
                    if (int.TryParse(parts[1], out points))
                    {
                        Base goalObject = new Base { Goal = goal, Points = points };
                        goalsList.Add(goalObject);
                    }
                }
            }
        }

        return goalsList;
    }
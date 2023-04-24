using Wyzwanie21;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Witamy w programie CzasPracy do obliczenia godzin pracy");
        Console.WriteLine("========================================================");
        Console.WriteLine();

        bool closeApp = false;
        while (true)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1 - Zapisywać dane pracownika do pliku\n" +
                "2 - Zapisywać dane pracownika w pamięci programu\n" + "3 - Skończyć na tym\n");
            var userImput = Console.ReadLine();

            switch (userImput)
            {
                case "1":
                    AddHoursToFile();
                    break;
                case "2":
                    AddHoursToMemory();
                    break;
                case "3":
                    closeApp = true;
                    break;
                default:
                    Console.WriteLine("Niepoprawne dane. Wprowadź 1, 2 lub 3");
                    continue;
            }
            if (closeApp)
            {
                break;
            }
            Console.WriteLine("Chcesz stworzyć nowego pracownika?");
        }
    }

    private static void AddHoursToMemory()
    {
        var employee = CreateEmployeeInMemory();
        employee.GoodWork += PraiseAnEmployee;

        bool finishCircle = false;
        while (!finishCircle)
        {
            try
            {
                var type = SelectType();
                switch (type)
                {
                    case 1:
                        employee.AddWorkingHours(WriteCountOfHours());
                        break;
                    case 2:
                        employee.AddVacationHours(WriteCountOfHours());
                        break;
                    case 3:
                        employee.AddSickHours(WriteCountOfHours());
                        break;
                    case 4:
                        employee.AddOvertimeHours(WriteCountOfHours());
                        break;
                    case 5:
                        finishCircle = true;
                        break;
                }
                Console.WriteLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Błąd. {exception.Message}.");
                Console.WriteLine();
            }
        }

        var statistics = employee.GetStatistics();
        Console.WriteLine($"Pracownik: {employee.Name} {employee.Surname}");
        statistics.PrintStatistics();
    }

    private static void AddHoursToFile()
    {
        var employee = CreateEmployeeInFile();
        employee.GoodWork += PraiseAnEmployee;

        bool finishCircle = false;
        while (!finishCircle)
        {
            try
            {
                var type = SelectType();
                switch (type)
                {
                    case 1:
                        employee.AddWorkingHours(WriteCountOfHours());
                        break;
                    case 2:
                        employee.AddVacationHours(WriteCountOfHours());
                        break;
                    case 3:
                        employee.AddSickHours(WriteCountOfHours());
                        break;
                    case 4:
                        employee.AddOvertimeHours(WriteCountOfHours());
                        break;
                    case 5:
                        finishCircle = true;
                        break;
                }
                Console.WriteLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Błąd. {exception.Message}.");
                Console.WriteLine();
            }
        }

        var statistics = employee.GetStatistics();
        Console.WriteLine($"Pracownik: {employee.Name} {employee.Surname}");
        statistics.PrintStatistics();
    }

    private static EmployeeInMemory CreateEmployeeInMemory()
    {
        while (true)
        {
            Console.WriteLine("Wprowadź imię pracownika");
            var name = Console.ReadLine();
            Console.WriteLine("Wprowadź nazwisko pracownika");
            var surname = Console.ReadLine();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                var employee = new EmployeeInMemory(name, surname);
                return employee;
            }
            else
            {
                Console.WriteLine("Pola z imieniem i nazwiskiem pracownika nie mogą być puste");
            }
        }
    }

    private static EmployeeInFile CreateEmployeeInFile()
    {
        while (true)
        {
            Console.WriteLine("Wprowadź imię pracownika");
            var name = Console.ReadLine();
            Console.WriteLine("Wprowadź nazwisko pracownika");
            var surname = Console.ReadLine();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                var employee = new EmployeeInFile(name, surname);
                return employee;
            }
            else
            {
                Console.WriteLine("Pola z imieniem i nazwiskiem pracownika nie mogą być puste");
            }
        }
    }

    private static int SelectType()
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1 - dodaj godziny pracujące\n" + "2 - dodaj godziny urlopowe\n" +
            "3 - dodaj godziny chorobowe\n" + "4 - dodaj nadgodziny\n" + "5 - obliczyć statystyki\n");
        while (true)
        {
            var userImput = Console.ReadLine();
            if (int.TryParse(userImput, out int result))
            {
                if (result >= 1 && result <= 5)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Niepoprawne dane. Wprowadź 1, 2, 3, 4 lub 5");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawne dane. Wprowadź 1, 2, 3, 4 lub 5");
            }
        }
    }

    private static string WriteCountOfHours()
    {
        Console.WriteLine("Wpisz ilość godzin:");
        return Console.ReadLine();
    }

    private static void PraiseAnEmployee(object sender, EventArgs args)
    {
        Console.WriteLine($"Świetna robota!");
    }
}
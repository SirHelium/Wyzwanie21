namespace Wyzwanie21
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void GoodWorkDelegate(object sender, EventArgs args);
        public abstract event GoodWorkDelegate GoodWork;
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public EmployeeBase(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public abstract void AddOvertimeHours(string hours);

        public abstract void AddSickHours(string hours);

        public abstract void AddVacationHours(string hours);

        public abstract void AddWorkingHours(string hours);

        public abstract Statistics GetStatistics();

        protected bool CheckCorrectnessOfTheAddedHours(ref string hours)
        {
            hours = hours.Replace(".", ",");

            if (float.TryParse(hours, out float result))
            {
                if (result > 0 && result <= 24)
                {
                    Console.WriteLine($"Dodano {result} godzin(y)");
                    return true;
                }
                else
                {
                    throw new Exception("Niepoprawna ilość godzin, wpisz liczbę dodatnią do 24.");
                }
            }
            else
            {
                throw new Exception("Wpisz liczbę.");
            }
        }
    }
}

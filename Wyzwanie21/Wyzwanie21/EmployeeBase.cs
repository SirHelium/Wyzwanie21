namespace Wyzwanie21
{
    public abstract class EmployeeBase : IEmployee
    {
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
        protected virtual bool CheckCorrectnessOfTheAddedHours(string hours)
        {
            if (int.TryParse(hours, out int result))
            {
                if (result > 0 && result <= 24)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Niepoprawna ilość godzin, wpisz liczbę od 1 do 24.");
                }
            }
            else
            {
                throw new Exception("Wpisz liczbę całkowitą.");
            }
        }

    }
}

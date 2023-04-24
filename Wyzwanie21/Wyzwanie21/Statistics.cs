namespace Wyzwanie21
{
    public class Statistics
    {
        public float OvertimeHours { get; private set; }
        public float SickHours { get; private set; }
        public float VacationHours { get; private set; }
        public float WorkingHours { get; private set; }
        public float SumHours
        {
            get
            {
                return WorkingHours + VacationHours + SickHours + OvertimeHours;
            }
        }
        public float PercentageHoursAtWork
        {
            get
            {
                return (WorkingHours + OvertimeHours) / SumHours * 100;
            }
        }

        public Statistics()
        {
            OvertimeHours = 0;
            SickHours = 0;
            VacationHours = 0;
            WorkingHours = 0;
        }

        public void AddHoursForStatistics(string hours)
        {
            switch (hours[0])
            {
                case 'o':
                    OvertimeHours += Convert.ToSingle(hours.Substring(1));
                    break;
                case 's':
                    SickHours += Convert.ToSingle(hours.Substring(1));
                    break;
                case 'v':
                    VacationHours += Convert.ToSingle(hours.Substring(1));
                    break;
                case 'w':
                    WorkingHours += Convert.ToSingle(hours.Substring(1));
                    break;
            }
        }

        public void PrintStatistics()
        {
            Console.WriteLine($"Łączna ilość godzin - {SumHours:N2}");
            Console.WriteLine($"Godziny pracujące - {WorkingHours:N2}");
            Console.WriteLine($"Godziny urlopowe - {VacationHours:N2}");
            Console.WriteLine($"Godziny chorobowe - {SickHours:N2}");
            Console.WriteLine($"Nadgodziny - {OvertimeHours:N2}");
            Console.WriteLine($"Procent godzin w pracy od łącznej ilości godzin - {PercentageHoursAtWork:N2} %");
            Console.WriteLine();
        }
    }
}
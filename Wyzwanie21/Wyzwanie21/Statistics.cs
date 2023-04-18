namespace Wyzwanie21
{
    public class Statistics
    {
        public int OvertimeHours { get; private set; }
        public int SickHours { get; private set; }
        public int VacationHours { get; private set; }
        public int WorkingHours { get; private set; }
        public int SumHours
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
                return (float)(WorkingHours + OvertimeHours) / SumHours * 100;
            }
        }

        public Statistics()
        {
            OvertimeHours = 0;
            SickHours = 0;
            VacationHours = 0;
            WorkingHours = 0;
        }

        public void AddHours(string hours)
        {
            switch (hours[0])
            {
                case 'o':
                    OvertimeHours += Convert.ToInt32(hours.Substring(1));
                    break;
                case 's':
                    SickHours += Convert.ToInt32(hours.Substring(1));
                    break;
                case 'v':
                    VacationHours += Convert.ToInt32(hours.Substring(1));
                    break;
                case 'w':
                    WorkingHours += Convert.ToInt32(hours.Substring(1));
                    break;
            }
        }
        public void PrintStatistics()
        {
            Console.WriteLine("Łączna ilość godzin - " + SumHours);
            Console.WriteLine("Godziny pracujące - " + WorkingHours);
            Console.WriteLine("Godziny urlopowe - " + VacationHours);
            Console.WriteLine("Godziny chorobowe - " + SickHours);
            Console.WriteLine("Nadgodziny - " + OvertimeHours);
            Console.WriteLine($"Procent godzin w pracy od łącznej ilości godzin - {PercentageHoursAtWork:N2} %");
            Console.WriteLine();
        }
    }
}
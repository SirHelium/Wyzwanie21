namespace Wyzwanie21
{
    public class EmployeeInMemory : EmployeeBase
    {
        public override event GoodWorkDelegate GoodWork;
        public EmployeeInMemory(string name, string surname) : base(name, surname)
        {
        }

        private List<string> TotalHours = new List<string>();
        public override void AddOvertimeHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                TotalHours.Add("o" + hours);
                if(Convert.ToInt32(hours) >= 12 && GoodWork != null)
                {
                    GoodWork(this, new EventArgs());
                }
            }
        }
        public override void AddSickHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                TotalHours.Add("s" + hours);
            }
        }
        public override void AddVacationHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                TotalHours.Add("v" + hours);
            }
        }
        public override void AddWorkingHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                TotalHours.Add("w" + hours);
                if (Convert.ToInt32(hours) >= 12 && GoodWork != null)
                {
                    GoodWork(this, new EventArgs());
                }
            }
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var hours in TotalHours)
            {
                statistics.AddHoursForStatistics(hours);
            }
            return statistics;
        }
        protected override bool CheckCorrectnessOfTheAddedHours(string hours)
        {
            return base.CheckCorrectnessOfTheAddedHours(hours);
        }
    }
}

using System.Diagnostics;
using System.Xml.Linq;

namespace Wyzwanie21
{
    public class EmployeeInFile : EmployeeBase
    {
        private const string fileName ="_hours.txt";

        public override event GoodWorkDelegate GoodWork;
        private string fullFileName;
        public EmployeeInFile(string name, string surname) : base(name, surname)
        {
            fullFileName = $"{name}_{surname}{fileName}";
            using (var writer = File.AppendText(fullFileName))
            {
                writer.WriteLine($"Pracownik: {name} {surname}");
            }
        }

        public override void AddOvertimeHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine("o" + hours);
                }
                if (Convert.ToInt32(hours) >= 12 && GoodWork != null)
                {
                    GoodWork(this, new EventArgs());
                }
            }
        }
        public override void AddSickHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine("s" + hours);
                }
            }
        }
        public override void AddVacationHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine("v" + hours);
                }
            }
        }
        public override void AddWorkingHours(string hours)
        {
            if (CheckCorrectnessOfTheAddedHours(hours))
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine("w" + hours);
                }
                if (Convert.ToInt32(hours) >= 12 && GoodWork != null)
                {
                    GoodWork(this, new EventArgs());
                }
            }
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            if (File.Exists(fullFileName))
            {
                using (var reader = File.OpenText(fullFileName))
                {
                    var line = reader.ReadLine();
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        statistics.AddHoursForStatistics(line);
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        }
        protected override bool CheckCorrectnessOfTheAddedHours(string hours)
        {
            return base.CheckCorrectnessOfTheAddedHours(hours);
        }
    }
}

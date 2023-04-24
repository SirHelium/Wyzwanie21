using static Wyzwanie21.EmployeeBase;

namespace Wyzwanie21
{
    public interface IEmployee
    {
        event GoodWorkDelegate GoodWork;

        string Name { get; }
        string Surname { get; }

        void AddWorkingHours(string hours);

        void AddVacationHours(string hours);

        void AddSickHours(string hours);

        void AddOvertimeHours(string hours);

        Statistics GetStatistics();
    }
}

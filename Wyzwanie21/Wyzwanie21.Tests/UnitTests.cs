namespace Wyzwanie21.Tests
{
    public class Tests
    {
        [Test]
        public void WhenAddWorkingHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddWorkingHours("10");
            employee.AddWorkingHours("3");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.WorkingHours, Is.EqualTo(13));
            Assert.That(statistics.VacationHours, Is.Not.EqualTo(13));
            Assert.That(statistics.SickHours, Is.Not.EqualTo(13));
            Assert.That(statistics.OvertimeHours, Is.Not.EqualTo(13));
        }
        [Test]
        public void WhenAddVacationHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddVacationHours("24");
            employee.AddVacationHours("7");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.VacationHours, Is.EqualTo(31));
            Assert.That(statistics.WorkingHours, Is.Not.EqualTo(31));
            Assert.That(statistics.SickHours, Is.Not.EqualTo(31));
            Assert.That(statistics.OvertimeHours, Is.Not.EqualTo(31));
        }
        [Test]
        public void WhenAddSickHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddSickHours("4");
            employee.AddSickHours("1");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.SickHours, Is.EqualTo(5));
            Assert.That(statistics.VacationHours, Is.Not.EqualTo(5));
            Assert.That(statistics.WorkingHours, Is.Not.EqualTo(5));
            Assert.That(statistics.OvertimeHours, Is.Not.EqualTo(5));
        }

        [Test]
        public void WhenAddOvertimeHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddOvertimeHours("16");
            employee.AddOvertimeHours("9");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.OvertimeHours, Is.EqualTo(25));
            Assert.That(statistics.WorkingHours, Is.Not.EqualTo(25));
            Assert.That(statistics.VacationHours, Is.Not.EqualTo(25));
            Assert.That(statistics.SickHours, Is.Not.EqualTo(25));
        }

    }
}
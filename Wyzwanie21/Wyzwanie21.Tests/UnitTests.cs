namespace Wyzwanie21.Tests
{
    public class Tests
    {
        [Test]
        public void WhenAddWorkingHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddWorkingHours("10.5");
            employee.AddWorkingHours("3,33");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.WorkingHours, Is.EqualTo(13.83f));
            Assert.That(statistics.VacationHours, Is.Not.EqualTo(13.83f));
            Assert.That(statistics.SickHours, Is.Not.EqualTo(13.83f));
            Assert.That(statistics.OvertimeHours, Is.Not.EqualTo(13.83f));
        }

        [Test]
        public void WhenAddVacationHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddVacationHours("23.67");
            employee.AddVacationHours("7,01");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.VacationHours, Is.EqualTo(30.68f));
            Assert.That(statistics.WorkingHours, Is.Not.EqualTo(30.68f));
            Assert.That(statistics.SickHours, Is.Not.EqualTo(30.68f));
            Assert.That(statistics.OvertimeHours, Is.Not.EqualTo(30.68f));
        }

        [Test]
        public void WhenAddSickHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddSickHours("4,890");
            employee.AddSickHours("1.6");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.SickHours, Is.EqualTo(6.49f));
            Assert.That(statistics.VacationHours, Is.Not.EqualTo(6.49f));
            Assert.That(statistics.WorkingHours, Is.Not.EqualTo(6.49f));
            Assert.That(statistics.OvertimeHours, Is.Not.EqualTo(6.49f));
        }

        [Test]
        public void WhenAddOvertimeHours()
        {
            var employee = new EmployeeInMemory("Piotr", "Testowski");

            employee.AddOvertimeHours("16.01");
            employee.AddOvertimeHours("9.10");

            var statistics = employee.GetStatistics();

            Assert.That(statistics.OvertimeHours, Is.EqualTo(25.11f));
            Assert.That(statistics.WorkingHours, Is.Not.EqualTo(25.11f));
            Assert.That(statistics.VacationHours, Is.Not.EqualTo(25.11f));
            Assert.That(statistics.SickHours, Is.Not.EqualTo(25.11f));
        }

    }
}
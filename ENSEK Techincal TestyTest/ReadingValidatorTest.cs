using Autofac.Extras.Moq;
using Autofac;
using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services.Repository;
using Moq;


namespace ENSEK_Techincal_TestyTest
{
    public class ReadingValidatorTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            RegisterDependencies();
        }

        protected override void OverrideDependenciesWithMocks(AutoMock mock, ContainerBuilder builder)
        {
            base.OverrideDependenciesWithMocks(mock, builder);

            EnergyAccount fakeAccount = new EnergyAccount();
            fakeAccount.FirstName = "Test";
            fakeAccount.LastName = "Tester";
            fakeAccount.SetReading(new EnergyReading());
        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }

        public void MockDataObjectWithFake()
        {
            
        }
    }
}
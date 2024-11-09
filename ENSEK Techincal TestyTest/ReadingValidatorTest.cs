using Autofac.Extras.Moq;
using Autofac;

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
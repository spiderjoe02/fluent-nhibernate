using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.DslImplementation;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel;
using NUnit.Framework;

namespace FluentNHibernate.Testing.ConventionsTests.AcceptanceCriteria
{
    [TestFixture]
    public class PropertyAcceptanceCriteriaEqualSimpleTypeEvalTests
    {
        private IAcceptanceCriteria<IPropertyInspector> acceptance;

        [SetUp]
        public void CreateAcceptanceCriteria()
        {
            acceptance = new ConcreteAcceptanceCriteria<IPropertyInspector>();
        }

        [Test]
        public void ExpectEqualShouldValidateToTrueIfGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert == true);

            acceptance
                .Matches(new PropertyInspector(new PropertyMapping() { Insert = true }))
                .ShouldBeTrue();
        }

        [Test]
        public void ExpectEqualShouldValidateToFalseIfNotGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert == true);

            acceptance
                .Matches(new PropertyInspector(new PropertyMapping() { Insert = false }))
                .ShouldBeFalse();
        }

        [Test]
        public void ExpectEqualShouldValidateToFalseIfUnset()
        {
            acceptance.Expect(x => x.Insert == true);

            acceptance
                .Matches(new PropertyInspector(new PropertyMapping()))
                .ShouldBeFalse();
        }

        [Test]
        public void ExpectNotEqualShouldValidateToTrueIfGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert != true);

            acceptance
                .Matches(new PropertyInspector(new PropertyMapping() { Insert = false }))
                .ShouldBeTrue();
        }

        [Test]
        public void ExpectNotEqualShouldValidateToFalseIfNotGivenMatchingModel()
        {
            acceptance.Expect(x => x.Insert != true);

            acceptance
                .Matches(new PropertyInspector(new PropertyMapping() { Insert = true }))
                .ShouldBeFalse();
        }

        [Test]
        public void ExpectNotEqualShouldValidateToTrueIfUnset()
        {
            acceptance.Expect(x => x.Insert != true);

            acceptance
                .Matches(new PropertyInspector(new PropertyMapping()))
                .ShouldBeTrue();
        }
    }
}
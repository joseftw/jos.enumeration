using System.Linq;
using System.Reflection;
using Shouldly;
using JOS.Enumerations.Microsoft;
using Xunit;

namespace JOS.Enumeration.Tests.Microsoft
{
    public class HamburgerTests
    {
        [Fact]
        public void DifferentInstancesShouldNotBeEqual()
        {
            var cheeseburger = Hamburger.Cheeseburger;
            var bigMac = Hamburger.BigMac;

            bigMac.ShouldNotBeSameAs(cheeseburger);
        }

        [Fact]
        public void SameInstancesShouldBeEqual()
        {
            var cheeseburger1 = Hamburger.Cheeseburger;
            var cheeseburger2 = CreateCopy(cheeseburger1);

            cheeseburger1.Equals(cheeseburger2).ShouldBeTrue();
        }

        [Fact]
        public void GetAll_ShouldReturnAllInstances()
        {
            var hamburgers = Enumeration.Microsoft.Enumeration.GetAll<Hamburger>().ToHashSet();

            hamburgers.Count.ShouldBe(3);
            hamburgers.ShouldContain(Hamburger.BigMac);
            hamburgers.ShouldContain(Hamburger.BigTasty);
            hamburgers.ShouldContain(Hamburger.Cheeseburger);
        }

        [Fact]
        public void AbsoluteDifference_ShouldReturnCorrectDifference()
        {
            var cheeseburger = Hamburger.Cheeseburger;
            var bigTasty = Hamburger.BigTasty;

            var result = Enumeration.Microsoft.Enumeration.AbsoluteDifference(cheeseburger, bigTasty);

            result.ShouldBe(2);
        }

        [Fact]
        public void FromValue_ShouldReturnCorrectInstance()
        {
            var result = Enumeration.Microsoft.Enumeration.FromValue<Hamburger>(Hamburger.Cheeseburger.Id);

            result.ShouldBe(Hamburger.Cheeseburger);
        }

        [Fact]
        public void FromDisplayName_ShouldReturnCorrectInstance()
        {
            var result = Enumeration.Microsoft.Enumeration.FromDisplayName<Hamburger>(Hamburger.Cheeseburger.Name);

            result.ShouldBe(Hamburger.Cheeseburger);
        }

        [Fact]
        public void DifferentImplementationsWillNotClash()
        {
            var hamburgers = Enumeration.Microsoft.Enumeration.GetAll<Hamburger>().ToList();
            var sausages = Enumeration.Microsoft.Enumeration.GetAll<Sausage>().ToList();

            hamburgers.Count.ShouldBe(3);
            sausages.Count.ShouldBe(2);
        }

        [Fact]
        public void CompareTo_ShouldReturn0ForSameInstances()
        {
            var hamburger1 = Hamburger.Cheeseburger;
            var hamburger2 = CreateCopy(hamburger1);

            var result = hamburger1.CompareTo(hamburger2);

            result.ShouldBe(0);
        }

        [Fact]
        public void CompareTo_ShouldReturnMinus1ForItemWhenValueIsLessThanTheComparedValue()
        {
            var hamburger1 = Hamburger.Cheeseburger;
            var hamburger2 = Hamburger.BigTasty;

            var result = hamburger1.CompareTo(hamburger2);

            result.ShouldBe(-1);
        }

        [Fact]
        public void CompareTo_ShouldReturn1ForItemWhenValueIsGreaterThanTheComparedValue()
        {
            var hamburger1 = Hamburger.BigTasty;
            var hamburger2 = Hamburger.Cheeseburger;

            var result = hamburger1.CompareTo(hamburger2);

            result.ShouldBe(1);
        }

        private static Hamburger CreateCopy(Hamburger hamburger)
        {
            return (Hamburger)typeof(Hamburger).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new[] { typeof(int), typeof(string) }, null)
                !.Invoke(new object[] { hamburger.Id, hamburger.Name });
        }
    }
}
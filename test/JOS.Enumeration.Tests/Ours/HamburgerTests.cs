using System.Linq;
using System.Reflection;
using JOS.Enumerations.Ours;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests.Ours
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
            var hamburgers = Enumerations.Ours.Enumeration.GetAll<Hamburger>().ToHashSet();

            hamburgers.Count.ShouldBe(3);
            hamburgers.ShouldContain(Hamburger.BigMac);
            hamburgers.ShouldContain(Hamburger.BigTasty);
            hamburgers.ShouldContain(Hamburger.Cheeseburger);
        }

        [Fact]
        public void FromValue_ShouldReturnCorrectInstance()
        {
            var result = Enumerations.Ours.Enumeration.FromValue<Hamburger>(Hamburger.Cheeseburger.Value);

            result.ShouldBe(Hamburger.Cheeseburger);
        }

        [Fact]
        public void FromDisplayName_ShouldReturnCorrectInstance()
        {
            var result = Enumerations.Ours.Enumeration.FromDescription<Hamburger>(Hamburger.Cheeseburger.Description);

            result.ShouldBe(Hamburger.Cheeseburger);
        }

        [Fact]
        public void DifferentImplementationsWillNotClash()
        {
            var hamburgers = Enumerations.Ours.Enumeration.GetAll<Hamburger>().ToList();
            var sausages = Enumerations.Ours.Enumeration.GetAll<Sausage>().ToList();

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
                !.Invoke(new object[] { hamburger.Value, hamburger.Description });
        }
    }
}
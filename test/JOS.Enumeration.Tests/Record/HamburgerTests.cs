using System;
using System.Linq;
using System.Reflection;
using JOS.Enumerations.Record;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests.Record
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
            var hamburgers = Hamburger.GetAll().ToHashSet();

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

            var result = Hamburger.AbsoluteDifference(cheeseburger, bigTasty);

            result.ShouldBe(2);
        }

        [Fact]
        public void FromValue_ShouldReturnCorrectInstance()
        {
            var result = Hamburger.FromValue(Hamburger.Cheeseburger.Value);

            result.ShouldBe(Hamburger.Cheeseburger);
        }

        [Fact]
        public void FromValue_ShouldThrowIfNoMatchingItemFound()
        {
            var exception = Should.Throw<InvalidOperationException>(() => Hamburger.FromValue(1000));

            exception.Message.ShouldBe("'1000' is not a valid value in JOS.Enumerations.Record.Hamburger");
        }

        [Fact]
        public void FromName_ShouldReturnCorrectInstance()
        {
            var result = Hamburger.FromDisplayName(Hamburger.Cheeseburger.DisplayName);

            result.ShouldBe(Hamburger.Cheeseburger);
        }

        [Fact]
        public void FromName_ShouldThrowIfNoMatchingItemFound()
        {
            var exception = Should.Throw<InvalidOperationException>(() => Hamburger.FromDisplayName("Egg"));

            exception.Message.ShouldBe(
                "'Egg' is not a valid display name in JOS.Enumerations.Record.Hamburger");
        }

        [Fact]
        public void DifferentImplementationsWillNotClash()
        {
            var hamburgers = Hamburger.GetAll().ToList();
            var sausages = Sausage.GetAll().ToList();

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
                !.Invoke(new object[] { hamburger.Value, hamburger.DisplayName });
        }
        // TODO Add test that ensures that code throws if duplicate names.
    }
}

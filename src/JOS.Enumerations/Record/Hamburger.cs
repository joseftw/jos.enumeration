namespace JOS.Enumerations.Record
{
    public record Hamburger : Enumeration.Record.Enumeration<Hamburger>
    {
        public static Hamburger Cheeseburger = new (1, "Cheeseburger");
        public static Hamburger BigMac = new(2, "Big Mac");
        public static Hamburger BigTasty = new(3, "Big Tasty");

        private Hamburger(int id, string displayName) : base(id, displayName)
        {
        }
    }
}

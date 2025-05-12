namespace WebApplication1.Table_Classes
{
    public class Team
    {
        public int Tid { get; set; }
        public string TeamName { get; set; } = null!;

        public int Points { get; set; }

        public int? Win { get; set; }

        public int? Lose { get; set; }

        public int? Draw { get; set; }
    }
}

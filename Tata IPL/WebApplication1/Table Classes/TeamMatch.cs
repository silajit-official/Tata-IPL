namespace WebApplication1.Table_Classes
{
    public class CustomTeamMatch
    {
        public int Tmid { get; set; }

        public int Team1 { get; set; }
        public string Team1_Name { get; set; }
        public int Team2 { get; set; }
        public string Team2_Name { get; set; }
        public DateTime PlayedOn { get; set; }
    }
}

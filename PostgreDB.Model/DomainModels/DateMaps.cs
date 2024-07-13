namespace PostgreDB.Model.DomainModels
{
    public class DateMaps
    {
        public int Id { get; set; }
        public string BsFiscalYear { get; set; }
        public string BsYear { get; set; }
        public string BsMonth { get; set; }
        public string BsStartDate { get; set; }
        public string BsEndDate { get; set; }
        public DateTime EngStartDate { get; set; }
        public DateTime EngEndDate { get; set; }
    }
}

namespace RedisWithTool.Models
{
    public class FindGeo
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public double WithinKm { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
    }
}

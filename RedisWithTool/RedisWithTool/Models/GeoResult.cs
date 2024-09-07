namespace RedisWithTool.Models
{
    public class GeoResult
    {
        public int Id { get; set; }
        public string Member { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public long Hash { get; set; }
        public string Unit { get; set; }
        public double Distance { get; set; }

        // Additional info
        public string EndUpdate { get; set; }
    }
}

namespace Monitoring.Models
{
    public class GigaModel
    {

        public string areaName { get; set; }
        public Area area { get; set; }
        public Type type { get; set; }
        public float min { get; set; }
        public float max { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public float num { get; set; } //params

        public DateTime date { get; set; }//getdate

    }
}

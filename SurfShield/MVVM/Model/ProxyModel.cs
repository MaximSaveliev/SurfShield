namespace SurfShield.MVVM.ViewModel
{
    public class ProxyModel
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public string Country { get; set; }
        public string Flag { get; set; }
        //public string IPnFlag { get => Flag + " " + IP; }
        //public ProxyInfo ProxyDetails { get; set; }
        //
        //public class ProxyInfo
        //{
        //    public string IP { get; set; }
        //    public string Port { get; set; }
        //    public string Country { get; set; }
        //    public string Flag { get; set; }
        //
        //}
    }
}

namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountImageUrl { get; set; }

        public string DiscountDescription { get; set; }
        public int Amount { get; set; }
    }
}

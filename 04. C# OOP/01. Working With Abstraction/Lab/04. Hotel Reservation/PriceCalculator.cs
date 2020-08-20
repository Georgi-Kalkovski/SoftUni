namespace HotelReservation
{
    using System;

    public class PriceCalculator
    {
        private decimal pricePerDay;
        private int numberOfDays;
        private SeasonMultiplier season;
        private DiscountPercentage discount;

        public PriceCalculator(string[] reservation)
        {
            pricePerDay = decimal.Parse(reservation[0]);
            numberOfDays = int.Parse(reservation[1]);
            season = Enum.Parse<SeasonMultiplier>(reservation[2]);
            discount = DiscountPercentage.None;

            if (reservation.Length == 4)
            {
                discount = Enum.Parse<DiscountPercentage>(reservation[3]);
            }
        }
        public decimal GetTotalPrice()
        {
            decimal seasonalDiscount = pricePerDay * (int)season;

            return numberOfDays * (seasonalDiscount - seasonalDiscount * (decimal)discount / 100);

        }
    }
}

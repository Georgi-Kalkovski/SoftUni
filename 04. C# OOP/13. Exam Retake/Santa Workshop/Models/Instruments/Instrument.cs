using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
		private int power;

		public Instrument(int power)
		{
			this.Power = power;
		}

		public int Power
		{
			get => power;
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				power = value;
			}
		}

		public bool IsBroken()
		{
			if (power <= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Use()
		{
			power -= 10;
			if (power < 0)
			{
				power = 0;
			}
		}
	}
}

using SantaWorkshop.Models.Presents.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
		private string name;
		private int energyRequired;

		public Present(string name, int energyRequired)
		{
			this.Name = name;
			this.EnergyRequired = energyRequired;
		}
		public string Name
		{
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Present name cannot be null or empty.");
				}
				name = value;
			}
		}

		public int EnergyRequired
		{
			get => energyRequired;
			private set 
			{
				if (value < 0)
				{
					value = 0;
				}
				energyRequired = value; 
			}
		}

		public void GetCrafted()
		{
			if (energyRequired - 10 >= 0)
			{
				energyRequired -= 10;
			}
		}

		public bool IsDone()
		{
			if (energyRequired == 0)
			{
				return true;
			}
			return false;
		}
	}
}

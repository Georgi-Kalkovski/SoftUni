using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    {
                        aquariums.Add(new FreshwaterAquarium(aquariumName));
                        break;
                    }

                case "SaltwaterAquarium":
                    {
                        aquariums.Add(new SaltwaterAquarium(aquariumName));
                        break;
                    }

                default: throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "FreshwaterAquarium":
                    {
                        decorations.Add(new Ornament());
                        break;
                    }

                case "SaltwaterAquarium":
                    {
                        decorations.Add(new Plant());
                        break;
                    }

                default: throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.Find(x => x.Name == aquariumName);
            var decoration = decorations.FindByType(decorationType);

            if (null == decoration)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            aquarium.AddDecoration(decoration);

            if (aquarium.Decorations.Contains(decoration))
            {
                decorations.Remove(decoration);
            }

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);
            string aquariumType = aquarium.GetType().Name;

            //if (fishType == "FreshwaterFish" && aquariumType == "FreshwaterAquarium")
            //{
            //    aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
            //}
            //else if (fishType == "SaltwaterFish" && aquariumType == "SaltwaterAquarium")
            //{
            //    aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
            //}
            //else if (fishType != "SaltwaterFish" || fishType != "FreshwaterFish")
            //{
            //    throw new InvalidOperationException("Invalid fish type.");
            //}
            //else
            //{
            //    return "Water not suitable.";
            //}

            switch (fishType)
            {
                case "FreshwaterFish":
                    {
                        if (aquariumType == "FreshwaterAquarium")
                        {
                            aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                        }
                        else
                        {
                            return "Water not suitable.";
                        }

                        break;
                    }

                case "SaltwaterFish":
                    {
                        if (aquariumType == "SaltwaterAquarium")
                        {
                            aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                        }
                        else
                        {
                            return "Water not suitable.";
                        }
                        break;
                    }

                default: throw new InvalidOperationException("Invalid fish type.");
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            var sum = 0.0m;

            foreach (var decoration in aquarium.Decorations)
            {
                sum += decoration.Price;
            }
            foreach (var fish in aquarium.Fish)
            {
                sum += fish.Price;
            }

            return $"The value of Aquarium {aquariumName} is {sum:F2}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (IAquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public void Exit()
        {
            return;
        }
    }
}

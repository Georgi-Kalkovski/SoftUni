namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (PilotExists(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            var newPilot = new Pilot(name);
            pilots.Add(newPilot);
            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (MachineExists(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IMachine newTank = new Tank(name, attackPoints, defensePoints);
            machines.Add(newTank);
            return string.Format(OutputMessages.TankManufactured, name, newTank.AttackPoints, newTank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (MachineExists(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IMachine newFighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(newFighter);
            return string.Format(OutputMessages.FighterManufactured, name, newFighter.AttackPoints, newFighter.DefensePoints);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (PilotExists(selectedPilotName))
            {
                if (MachineExists(selectedMachineName))
                {
                    var machine = machines.First(x => x.Name == selectedMachineName);
                    var pilot = pilots.First(x => x.Name == selectedPilotName);

                    if (machine.Pilot == null)
                    {
                        pilot.AddMachine(machine);
                        machine.Pilot = pilot;
                        return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
                    }

                    return string.Format(OutputMessages.MachineHasPilotAlready, selectedPilotName);
                }

                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (MachineExists(attackingMachineName))
            {
                if (MachineExists(defendingMachineName))
                {
                    var atacker = machines.First(x => x.Name == attackingMachineName);
                    var defender = machines.First(x => x.Name == defendingMachineName);

                    if (atacker.HealthPoints > 0)
                    {
                        if (defender.HealthPoints > 0)
                        {
                            atacker.Attack(defender);

                            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defender.HealthPoints);
                        }

                        return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
                    }

                    return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
                }

                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilotInfo = pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return pilotInfo.Report();
        }

        public string MachineReport(string machineName)
        {
            var machineInfo = machines.FirstOrDefault(x => x.Name == machineName);

            return machineInfo.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if ((MachineExists(fighterName)))
            {
                var fighter = (Fighter)machines.First(x => x.Name == fighterName);
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }

            return string.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if ((MachineExists(tankName)))
            {
                var tank = (Tank)machines.First(x => x.Name == tankName);
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return string.Format(OutputMessages.MachineNotFound, tankName);
        }

        private bool MachineExists(string name)
        {
            if (machines.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }

        private bool PilotExists(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}
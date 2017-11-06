using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace RisikoApp.Model
{
    public class FightStatistic
    {
        private List<int> attackerLost = new List<int>();
        private List<int> defenderLost = new List<int>();
        public int AttackerUnits { get; }
        public int DefenderUnits { get; }

        public FightStatistic(int attackerUnits, int defenderUnits)
        {
            AttackerUnits = attackerUnits;
            DefenderUnits = defenderUnits;
        }

        public void AddRoundStatistics(int aLost, int dLost)
        {
            attackerLost.Add(aLost);
            defenderLost.Add(dLost);
        }

        public int[] getAttackerRoundStats()
        {
            return attackerLost.ToArray();
        }

        public int[] getDefenderRoundStats()
        {
            return defenderLost.ToArray();
        }

        public int getAttackerLostAbs()
        {
            return attackerLost.Sum();
        }

        public int getDefenderLostAbs()
        {
            return defenderLost.Sum();
        }

        public double getAttackerLostRel()
        {
            return 1 - ((AttackerUnits - getAttackerLostAbs()) / (double)AttackerUnits); 
        }

        public double getDefenderLostRel()
        {
            return 1 - ((DefenderUnits - getDefenderLostAbs()) / (double)DefenderUnits);
        }        
    }
}

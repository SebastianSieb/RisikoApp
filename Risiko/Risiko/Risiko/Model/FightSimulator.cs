using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risiko.Model
{
    public class FightSimulator
    {
        public int AttackerUnits { set; get; }
        public int DefenderUnits { set; get; }
        public int AttackerLost { set; get; }
        public int DefenderLost { set; get; }

        public FightStatistic Stats { set; get; }

        public FightSimulator(int attackerUnits, int defenderUnits)
        {
            this.AttackerUnits = attackerUnits;
            this.DefenderUnits = defenderUnits;
            this.DefenderLost = 0;
            this.AttackerLost = 0;
            Stats = new FightStatistic(attackerUnits, defenderUnits);
        }

        private void simulate(int dialsAttacker, int dialsDefender)
        {
            LinkedList<int> attacker = new LinkedList<int>();
            LinkedList<int> defender = new LinkedList<int>();

            for (int i = 0; i < dialsAttacker; i++)
            {
                attacker.AddLast(Dice.dial());
            }
            for (int i = 0; i < dialsDefender; i++)
            {
                defender.AddLast(Dice.dial());
            }

            int attackerLostThisRound = 0;
            int defenderLostThisRound = 0;
            if (defender.Max() >= attacker.Max())
            {
                attackerLostThisRound++;
            }
            else
            {
                defenderLostThisRound++;
            }
            attacker.Remove(attacker.Max());
            defender.Remove(defender.Max());
            if (dialsAttacker > 1 && dialsDefender > 1)
            {
                if (defender.Max() >= attacker.Max())
                {
                    attackerLostThisRound++;
                }
                else
                {
                    defenderLostThisRound++;
                }
            }
            AttackerLost += attackerLostThisRound;
            DefenderLost += defenderLostThisRound;
            AttackerUnits -= attackerLostThisRound;
            DefenderUnits -= defenderLostThisRound;

            Stats.AddRoundStatistics(attackerLostThisRound, defenderLostThisRound);
        }

        public void Fight(int rounds, int dialsAttacker, int dialsDefender)
        {
            for (int i = 0; i < rounds; i++)
            {
                if (AttackerUnits < dialsAttacker || DefenderUnits < dialsDefender)
                {
                    break;
                }
                simulate(dialsAttacker, dialsDefender);
            }
        }
    }
}

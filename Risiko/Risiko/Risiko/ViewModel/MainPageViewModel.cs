using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Risiko.View;
using Risiko.Model;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Risiko.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private int unitsAttacker;
        private int unitsDefender;
        private int unitsTotalAttacker;
        private int unitsTotalDefender;
        private int unitsLostAttacker;
        private int unitsLostDefender;
        private int dicesAttacker;
        private int dicesDefender;
        private int rounds;
        public int UnitsAttacker
        {
            get
            {
                return unitsAttacker;
            }
            set
            {
                if (value != unitsAttacker)
                {
                    unitsAttacker = value;
                    fightSimulator = new FightSimulator(UnitsAttacker, UnitsDefender);
                    OnPropertyChanged("UnitsAttacker");
                }
            }
        }
        public int UnitsDefender
        {
            get
            {
                return unitsDefender;
            }
            set
            {
                if (value != unitsDefender)
                {
                    unitsDefender = value;
                    fightSimulator = new FightSimulator(UnitsAttacker, UnitsDefender);
                    OnPropertyChanged("UnitsDefender");
                }
            }
        }
        public int UnitsTotalAttacker
        {
            get
            {
                return unitsTotalAttacker;
            }
            set
            {
                if (value != unitsTotalAttacker)
                {
                    unitsTotalAttacker = value;
                    OnPropertyChanged("UnitsTotalAttacker");
                }
            }
        }
        public int UnitsTotalDefender
        {
            get
            {
                return unitsTotalDefender;
            }
            set
            {
                if (value != unitsTotalDefender)
                {
                    unitsTotalDefender = value;
                    OnPropertyChanged("UnitsTotalDefender");
                }
            }
        }
        public int UnitsLostAttacker
        {
            get
            {
                return unitsLostAttacker;
            }
            set
            {
                if (value != unitsLostAttacker)
                {
                    unitsLostAttacker = value;
                    OnPropertyChanged("UnitsLostAttacker");
                }
            }
        }
        public int UnitsLostDefender
        {
            get
            {
                return unitsLostDefender;
            }
            set
            {
                if (value != unitsLostDefender)
                {
                    unitsLostDefender = value;
                    OnPropertyChanged("UnitsLostDefender");
                }
            }
        }
        public int DicesAttacker
        {
            get
            {
                return dicesAttacker;
            }
            set
            {
                if (value != dicesAttacker)
                {
                    dicesAttacker = value;
                    OnPropertyChanged("DicesAttacker");
                }
            }
        }
        public int DicesDefender
        {
            get
            {
                return dicesDefender;
            }
            set
            {
                if (value != dicesDefender)
                {
                    dicesDefender = value;
                    OnPropertyChanged("DicesDefender");
                }
            }
        }
        public int Rounds
        {
            get
            {
                return rounds;
            }
            set
            {
                if (value != rounds)
                {
                    rounds = value;
                    OnPropertyChanged("Rounds");
                }
            }
        }

        public ICommand Run
        {
            get;
            set;
        }
        public ICommand Reset
        {
            get;
            set;
        }
        public ICommand Stats
        {
            get;
            set;
        }
        private FightSimulator fightSimulator;

        public MainPageViewModel()
        {
            unitsAttacker = 0;
            unitsDefender = 0;
            dicesAttacker = 0;
            dicesDefender = 0;
            rounds = 0;
            UnitsTotalAttacker = unitsAttacker;
            UnitsTotalDefender = unitsDefender;
            unitsLostAttacker = 0;
            unitsLostDefender = 0;
            rounds = 0;
            fightSimulator = new FightSimulator(UnitsAttacker, UnitsDefender);
            Run = new Command(runFight);
            Reset = new Command(reset);
            Stats = new Command(o => App.navigateTo(new StatisticPage(fightSimulator.Stats)));
        }

        private void runFight()
        {
            fightSimulator.Fight(Rounds, DicesAttacker, DicesDefender);
            update();
        }

        private void update()
        {
            UnitsTotalAttacker = fightSimulator.AttackerUnits;
            UnitsTotalDefender = fightSimulator.DefenderUnits;
            UnitsLostAttacker = fightSimulator.AttackerLost;
            UnitsLostDefender = fightSimulator.DefenderLost;
        }

        private void reset()
        {
            UnitsAttacker = 0;
            UnitsDefender = 0;
            DicesAttacker = 0;
            DicesDefender = 0;
            Rounds = 0;
            update();
        }
    }
}

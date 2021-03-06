﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Risiko.Model;

namespace Risiko.ViewModel
{
    public class StatisticPageViewModel : BaseViewModel
    {
        private string attackerLostAbs;
        private string defenderLostAbs;
        private string attackerLostRel;
        private string defenderLostRel;
        private Grid roundsGrid;

        public string AttackerLostAbs
        {
            get
            {
                return attackerLostAbs;
            }
            set
            {
                if (value != attackerLostAbs)
                {
                    attackerLostAbs = value;
                    OnPropertyChanged("AttackerLostAbs");
                }
            }
        }
        public string DefenderLostAbs
        {
            get
            {
                return defenderLostAbs;
            }
            set
            {
                if (value != defenderLostAbs)
                {
                    defenderLostAbs = value;
                    OnPropertyChanged("DefenderLostAbs");
                }
            }
        }
        public string AttackerLostRel
        {
            get
            {
                return attackerLostRel;
            }
            set
            {
                if (value != attackerLostRel)
                {
                    attackerLostRel = value;
                    OnPropertyChanged("AttackerLostRel");
                }
            }
        }
        public string DefenderLostRel
        {
            get
            {
                return defenderLostRel;
            }
            set
            {
                if (value != defenderLostRel)
                {
                    defenderLostRel = value;
                    OnPropertyChanged("DefenderLostRel");
                }
            }
        }

        private FightStatistic stats;

        public StatisticPageViewModel(FightStatistic stats, Grid roundsGrid)
        {
            this.stats = stats;
            this.roundsGrid = roundsGrid;

            AttackerLostAbs = stats.getAttackerLostAbs().ToString();
            DefenderLostAbs = stats.getDefenderLostAbs().ToString();
            AttackerLostRel = stats.getAttackerLostRel().ToString();
            DefenderLostRel = stats.getDefenderLostRel().ToString();

            buildRoundGrid();
            //loadStatistics();
        }

        //Not used yet because it is slower then the sequentiell approach
        private async void loadStatistics()
        {
            blockUI();
            var a = new Task<int>(stats.getAttackerLostAbs);
            a.Start();
            var b = new Task<int>(stats.getDefenderLostAbs);
            b.Start();
            var c = new Task<double>(stats.getAttackerLostRel);
            c.Start();
            var d = new Task<double>(stats.getDefenderLostRel);
            d.Start();
            AttackerLostAbs = (await a).ToString();
            DefenderLostAbs = (await b).ToString();
            AttackerLostRel = (await c).ToString();
            DefenderLostRel = (await d).ToString();
            buildRoundGrid();
            releaseUI();
        }

        private void buildRoundGrid()
        {
            int[] attacker = stats.getAttackerRoundStats();
            int[] defender = stats.getDefenderRoundStats();

            for (int i = 0; i < attacker.Length; i++)
            {
                string[] toAdd = new string[3];
                toAdd[0] = (i + 1).ToString();
                toAdd[1] = "-" + attacker[i].ToString();
                toAdd[2] = "-" + defender[i].ToString();
                addLineToGrid(roundsGrid, toAdd);
            }
        }

        public void addLineToGrid(Grid grid, string[] text)
        {
            if (grid.ColumnDefinitions.Count == text.Length)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                for (int i = 0; i < text.Length; i++)
                {
                    Label temp = new Label
                    {
                        Text = text[i]
                    };
                    grid.Children.Add(temp, i, grid.RowDefinitions.Count);
                }
            }
        }
    }
}

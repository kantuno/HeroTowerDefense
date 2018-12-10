using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroTowerDefense.Classes
{
    public static class GameInfo
    {
        private static int money = 20;
        private static int health = 10;
        private static int wave = 0;
        private static bool waveRunning = false;
        public const int archerCost = 5;
        public const int darkWizardCost = 10;
        public const int cannonCost = 15;
        public const int archerRange = 270;
        public const int darkWizardRange = 330;
        public const int cannonRange = 210;
        public const int maxWave = 5;

        public static int Money
        {
            get => money;
            set => money = value;
        }

        public static int Health
        {
            get => health;
            set => health = value;
        }

        public static int StartWave()
        {
            return ++wave;
        }

        public static bool WaveRunning
        {
            get => waveRunning;
            set => waveRunning = value;
        }

        public static int WaveNumber
        {
            get => wave;
        }
    }
}

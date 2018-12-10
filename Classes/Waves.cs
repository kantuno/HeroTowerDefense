using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroTowerDefense.Classes
{
    public static class Waves
    {
        private static int waveNumber;

        public static Enemy[] GetWave( int x, int y )
        {
            Enemy[] waveList;

            switch( waveNumber)
            {
                case 1:
                    waveList = new Enemy[5] { new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y) };
                    break;
                case 2:
                    waveList = new Enemy[10] { new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y),
                                               new Knight(x, y), new Knight(x, y), new Knight(x, y), new Wizard(x,y), new Wizard(x, y) };
                    break;
                case 3:
                    waveList = new Enemy[15] { new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Wizard(x, y), new Knight(x, y), new Wizard(x,y), new Knight(x, y)};
                    break;
                case 4:
                    waveList = new Enemy[25] { new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Wizard(x, y), new Knight(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Wizard(x, y), new Wizard(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Knight(x,y), new Knight(x, y),};
                    break;
                case 5:
                    waveList = new Enemy[50] { new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y), new Peasant(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Wizard(x, y), new Knight(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Wizard(x, y), new Wizard(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Knight(x,y), new Knight(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Wizard(x, y), new Knight(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Wizard(x, y), new Wizard(x, y), new Wizard(x, y), new Wizard(x,y), new Knight(x, y),
                                               new Knight(x, y), new Knight(x, y), new Wizard(x, y), new Knight(x,y), new Knight(x, y),
                                               new Knight(x, y), new Knight(x, y), new Crusader(x, y), new Crusader(x,y), new Crusader(x, y)};
                    break;
                default:
                    waveList = new Enemy[1] { new Peasant( x,y) };
                    break;
            }

            return waveList;
        }

        public static int WaveNumber { get => waveNumber; set => waveNumber = value; }
    }
}

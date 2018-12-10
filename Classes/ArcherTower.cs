using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class ArcherTower : Tower
    {
        public ArcherTower(BitmapImage bmp, float x, float y)
        {
            fireSpeed = 200;
            towerSprite.Source = bmp;
            damage = 3;
            range = 180;
            X = x;
            Y = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class CannonTower : Tower
    {
        public CannonTower(BitmapImage bmp, float x, float y)
        {
            fireSpeed = 300;
            towerSprite.Source = bmp;
            damage = 8;
            range = 90;
            X = x;
            Y = y;
        }
    }
}

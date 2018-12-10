using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class DarkWizardTower : Tower
    {
        public DarkWizardTower(BitmapImage bmp, float x, float y)
        {
            fireSpeed = 50;
            towerSprite.Source = bmp;
            damage = 1;
            range = 240;
            X = x;
            Y = y;
        }
    }
}

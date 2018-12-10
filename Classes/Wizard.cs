using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class Wizard : Enemy
    {
        public Wizard(float x, float y)
        {
            enemySprite.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/wizard.png"));
            this.x = x;
            this.y = y;
            health = 15;
            speed = 8;
            damage = 2;
        }
    }
}

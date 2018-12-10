using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class Peasant : Enemy
    {
        public Peasant( float x, float y)
        {
            enemySprite.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/peasant.png"));
            this.x = x;
            this.y = y;
            health = 20;
            speed = 5;
            damage = 1;
        }
    }
}

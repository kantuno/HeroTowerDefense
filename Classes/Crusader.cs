using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class Crusader : Enemy
    {
        public Crusader(float x, float y)
        {
            enemySprite.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/crusader.png"));
            this.x = x;
            this.y = y;
            health = 60;
            speed = 6;
            damage = 5;
        }
    }
}

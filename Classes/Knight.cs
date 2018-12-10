using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroTowerDefense.Classes
{
    class Knight : Enemy
    {
        public Knight(float x, float y)
        {
            enemySprite.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/knight.png"));
            this.x = x;
            this.y = y;
            health = 40;
            speed = 3;
            damage = 3;
        }
    }
}

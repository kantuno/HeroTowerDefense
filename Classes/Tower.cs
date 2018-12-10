using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Threading;

namespace HeroTowerDefense.Classes
{
    class Tower
    {
        protected int range;
        protected int damage;
        protected Image towerSprite;
        protected float x;
        protected float y;
        protected int fireSpeed;
        protected bool fired = false;
        public Thread thr;

        public Tower()
        {
            towerSprite = new Image();
        }

        public void ClearImage()
        {
            towerSprite = null;
        }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public Image Img
        {
            get => towerSprite;
        }

        public bool InRange(int distance)
        {
            if (distance < (range / 2))
                return true;

            return false;
        }

        public int Damage
        {
            get => damage;
        }

        public int FireSpeed { get => fireSpeed; set => fireSpeed = value; }
        public bool Fired { get => fired; set => fired = value; }
    }
}

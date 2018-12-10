using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HeroTowerDefense.Classes
{
    public class Enemy
    {
        protected int health;
        protected float speed;
        protected float x;
        protected float y;
        protected Image enemySprite = new Image();
        public Thread thr;
        private int id;
        protected int time = 0;
        protected int damage;

        public Enemy()
        {

        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float X { get => x; set => x = value; }

        public float Y { get => y; set => y = value; }

        public void SetLocation(float x, float y) { this.x = x; this.y = y; }

        public Image Img
        {
            get => enemySprite;
        }
        public int Health { get => health; set => health = value; }
        public int Id { get => id; set => id = value; }
        public int Damage{get => damage; }
    }
}

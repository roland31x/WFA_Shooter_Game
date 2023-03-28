using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_Shooter_Game
{
    public class Enemy
    {
        public int Health { get; set; }
        int Speed { get; set; }

        double sizex, sizey;

        public PictureBox Image { get; set; }
        
        public Enemy(int hp, int sp, int sizeX, int sizeY)
        {
            Health = hp;
            Speed = sp;
            sizex = sizeX;
            sizey = sizeY;
            Image = new PictureBox()
            {
                Parent = Engine.form.pictureBox1,
                Size = new Size(sizeX, sizeY),
                BackColor = Color.Red,
                Location = Engine.GetRandomPoint(sizeX,sizeY),
            };
            Image.Click += EnemyClick;
        }

        private void EnemyClick(object? sender, EventArgs e)
        {
            Health -= 20;
            if(Health <= 0)
            {
                Engine.Enemies.Remove(this);
                Image.Parent = null;
            }
        }

        public void Move()
        {
            int x = Image.Location.X;
            int y = Image.Location.Y + Speed;
            Image.Location = new Point(x,y);
            sizex = sizex + (double)Speed / 16;
            sizey = sizey + (double)Speed / 16;
            Image.Size = new Size((int)sizex,(int)sizey);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_Shooter_Game
{
    public static class Engine
    {
        public static Form1 form;
        public static Random random = new Random();
        public static List<Enemy> Enemies = new List<Enemy>();
        public static int FortHP = 100;
        public static void Init(Form1 f)
        {
            form = f;
            Enemies.Add(new Enemy(100, 5, 50, 100));
        }
        public static void MoveEnemies()
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Move();
                if(Enemies[i].Image.Location.Y > form.Height)
                {
                    Enemies.Remove(Enemies[i]);
                    Enemies[i].Image.Parent = null;
                    i--;
                    FortHP -= 20;
                    CheckIfYouLost();
                }
            }
        }
        public static void CheckIfYouLost()
        {
            if(FortHP <= 0)
            {
                MessageBox.Show("The zombies ate your brain","Game Over");
                form.Close();
            }
        }
        public static Point GetRandomPoint(int EnemySizeX, int EnemySizeY)
        {
            return new Point(random.Next(0,form.Width - EnemySizeX), 200 - EnemySizeY);
        }
    }
}

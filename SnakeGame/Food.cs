using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food{

        public Point Location { get; private set; }//Localização da comida no jogo

        public void CreateFood(){
            Random rnd = new Random();//Gerar a comida em lugares aleatorios do map
            Location = new Point(rnd.Next(0, 27), rnd.Next(0, 27)); //Definindo locais que podem ser gerados
        }
    }
}

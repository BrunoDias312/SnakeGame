using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake{

        public int Length { get; private set; } //Para definir o tamanho da cobrinha.
        public Point[] Location { get; private set; } //Para definir localizacao da cobrinha.


        public Snake(){
            Location = new Point[28 * 28];
            Reset();
        }

        //Sempre que o jogo for reiniciado o tamanho e localizaçãao do cobra vai ser resetado.
        public void Reset(){
            Length = 5;//Tamanho inicial da cobra.

            for(int i = 0; i < Length; i++){//Definindo local de nascimento da cobra.
                Location[i].X = 12;
                Location[i].Y = 12;
            }
        }
        
        //fazer que todas as partes sigam uma das outras da cobrinha, a partir da cabeca.
        public void Follow(){
            for(int i = Length - 1; i > 0; i--) {
                Location[i] = Location[i - 1];
            }
        }

        //verificar se a cobra bateu nos cantos transportar ela para o lado oposto.
        public void Up(){
            Follow();
            Location[0].Y--;
            if (Location[0].Y < 0) {
                Location[0].Y += 28;
            }
        }

        public void Down(){
            Follow();
            Location[0].Y++;
            if (Location[0].Y > 27)
            {
                Location[0].Y -= 28;
            }

        }

        public void Left(){
            Follow();
            Location[0].X--;
            if (Location[0].X < 0)
            {
                Location[0].X += 28;
            }

        }

        public void Rigth(){
            Follow();
            Location[0].X++;
            if (Location[0].X > 27)
            {
                Location[0].X -= 28;
            }
        }
        
        //Verificar se a cobra comeu a fruta, se comer almentar o tamanho da cobra em um.
        public void Eat() {
            Length++;
        }


    }
}

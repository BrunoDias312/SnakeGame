using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    class Game{

        public Keys Direction { get; set; }
        public Keys Arrow { get; set; }//Botao clicado

        private Timer Frame { get; set; }
        private Label LbPontucao { get; set; }
        private Panel PnTela { get; set; }

        private int pontos = 0;//pontuação do player
        private Food Food;
        private Snake Snake;

        //Atributos Graficos
        private Bitmap offScreenBitmap; //Trabalhar com os pixels da tela. Inicio|Fim da tela;
        private Graphics bitmapoGraph; //Desenhar os componentes em si;
        private Graphics screenGraph; //Redenizar a tela com novas possicoes de comida e da cobra


        public Game(ref Timer time, ref Label label, ref Panel panel) {
            //Recebendo valores da tela grafica
            PnTela = panel;
            Frame = time;
            LbPontucao = label;
            //Pegando medidas da tela
            offScreenBitmap = new Bitmap(428, 428);
            //Iniciando classes essenciais 
            Snake = new Snake();
            Food = new Food();
            //Setando direção inicial para a cobrinha
            Direction = Keys.Left;
            Arrow = Direction;
        }


        public void StarGame(){
            Snake.Reset();
            Food.CreateFood();
            Direction = Keys.Left;
            bitmapoGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = PnTela.CreateGraphics();
            Frame.Enabled = true;
        }

        public void Tick(){
            if ( ((Arrow == Keys.Left) && (Direction != Keys.Right))||
                ((Arrow == Keys.Right) && (Direction != Keys.Left))||
                ((Arrow == Keys.Up) && (Direction != Keys.Down))||
                ((Arrow == Keys.Down) && (Direction != Keys.Up)) ) {
                Direction = Arrow;
            }


            switch (Direction){//Movimentar a cobra
                case Keys.Left:
                    Snake.Left();
                    break;
                case Keys.Right:
                    Snake.Rigth();
                    break;
            case Keys.Up:
                    Snake.Up();
                    break;
            case Keys.Down:
                    Snake.Down();
                    break;
            }

            bitmapoGraph.Clear(Color.White);//Limpar a tela
            //Especificar endereco e tamanho da imagem, assim como alocar ela na tela
            bitmapoGraph.DrawImage(Properties.Resources.food,(Food.Location.X * 15), (Food.Location.Y * 15), 15, 15);
            bool gameOver = false;

            for(int i = 0; i < Snake.Length; i++){
                if(i == 0){//se for a possicao da cabeca da cobra
                    bitmapoGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#000000")),
                    (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);//Se for a cabeca
                }
                else{
                    bitmapoGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#4F4F4F")),
                    (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);//Se for o corpo
                }

                //Verificar se a cabeca colidiu com o corpo
                if ((Snake.Location[i] == Snake.Location[0]) && (i > 0)) {
                    gameOver = true;
                }
            }

            screenGraph.DrawImage(offScreenBitmap, 0, 0);
            CheckCollision();
            if (gameOver) { 
                GameOver();
            }
        }

        public void CheckCollision(){//Metodo para verificar colisão
            if (Snake.Location[0] == Food.Location){
                Snake.Eat();//Comendo a comida
                Food.CreateFood();//Criando comida para a cobrinha
                pontos += 9;//Atribuindo pontos
                LbPontucao.Text = "Pontos: " + pontos;//Adicionar pontos para o player
            }
        }

        public void GameOver(){//Fim de jogo 
            Frame.Enabled = false;
            bitmapoGraph.Dispose();
            screenGraph.Dispose();
            pontos = 0;
            LbPontucao.Text = "Pontos: 0";
            MessageBox.Show("Game Over");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame{
    public partial class GameScreen : Form{

        Game Game;

        public GameScreen(){
            InitializeComponent();
            Game = new Game(ref Frame, ref LbPontucao, ref PnTela);
            //Game.StarGame();//Remover futuramente
        }


        private void Frame_Tick(object sender, EventArgs e){
            Game.Tick();
        }

        private void Clicado(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.Left||
               e.KeyCode == Keys.Right||
               e.KeyCode == Keys.Up||
               e.KeyCode == Keys.Down){
                Game.Arrow = e.KeyCode;
                Console.WriteLine("setado");
            }
        }

        private void iniciarToolStripMenuItem4_Click(object sender, EventArgs e){
            Game.StartGame();
        }

        private void sairToolStripMenuItem6_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void Frame_Tick_1(object sender, EventArgs e)
        {
            Game.Tick();
        }
    }
}
//Game.StarGame();Application.Exit();
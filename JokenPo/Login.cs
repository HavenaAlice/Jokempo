using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JokenPo {
    [Activity (Label = "Login")]
    public class Login : Activity {

        private enum JokenPo {Papel, Pedra, Tesoura};

        private long pontuacao = 0;
        private Random rnd  = new Random();

        private TextView txtPlacar;
        private TextView txtComputador;
        private ImageView imgComputador;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate (savedInstanceState);
            SetContentView(Resource.Layout.activity_jogo);

            txtPlacar = FindViewById<TextView>(Resource.Id.txtPlacar);
            txtComputador = FindViewById<TextView>(Resource.Id.txtComputador);

            imgComputador = FindViewById<ImageView>(Resource.Id.imgComputador);

            Button btnPapel = FindViewById<Button>(Resource.Id.btnPapel);
            btnPapel.Click += delegate {
                BtnPapelClick();
            };

            Button btnTesoura = FindViewById<Button>(Resource.Id.btnTesoura);
            btnTesoura.Click += delegate {
                BtnTesouraClick();
            };

            Button btnPedra = FindViewById<Button>(Resource.Id.btnPedra);
            btnPedra.Click += delegate {
                BtnPedraClick();
            };
        }

        private void AtualizarTela()
        {
            txtPlacar.Text = "Placar: " + pontuacao;
        }

        public void BtnPedraClick()
        {
            int rndNum = rnd.Next(3);

            if (rndNum == (int)JokenPo.Tesoura)
            {
                txtComputador.Text = "Você Ganhou! Computador escolheu Tesoura.";

                imgComputador.SetImageResource(Resource.Drawable.pedrawin);

                pontuacao++;
                AtualizarTela();
            } else if (rndNum == (int)JokenPo.Papel)
            {
                txtComputador.Text = "Você Perdeu!Computador escolheu Papel.";
                imgComputador.SetImageResource(Resource.Drawable.papelwin);
            } else
            {
                imgComputador.SetImageResource(Resource.Drawable.pedraigual);
                txtComputador.Text = "Empate. Computador escolheu Pedra. ";
            }

        }

        public void BtnPapelClick()
        {
            int rndNum = rnd.Next(3);

            if (rndNum == (int)JokenPo.Pedra) {
                txtComputador.Text = "Você Ganhou!Computador escolheu Pedra.";

                imgComputador.SetImageResource(Resource.Drawable.papelwin);

                pontuacao++;
                AtualizarTela();
            } else if (rndNum == (int)JokenPo.Tesoura)
            {
                txtComputador.Text = "Você Perdeu!Computador escolheu Tesoura.";
                imgComputador.SetImageResource(Resource.Drawable.tesourawin);
            }
            else
            {
                imgComputador.SetImageResource(Resource.Drawable.papeligual);
                txtComputador.Text = "Empate. Computador escolheu Papel. ";
            }
        }

        public void BtnTesouraClick()
        {
            int rndNum = rnd.Next(3);

            if (rndNum == (int)JokenPo.Papel) {
                txtComputador.Text = "Você Ganhou!Computador escolheu Papel.";

                imgComputador.SetImageResource(Resource.Drawable.tesourawin);

                pontuacao++;
                AtualizarTela();
            } else if (rndNum == (int)JokenPo.Pedra)
            {
                txtComputador.Text = "Você Perdeu! Computador escolheu Pedra.";
                imgComputador.SetImageResource(Resource.Drawable.pedrawin);
            }  else
            {
                imgComputador.SetImageResource(Resource.Drawable.tesouraigual);
                txtComputador.Text = "Empate. Computador escolheu Tesoura. ";
            }
        }

    }
}
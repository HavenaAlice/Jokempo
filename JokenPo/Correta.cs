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

namespace JokenPo
{
    [Activity(Label = "Correta")]
    public class Correta : Activity
    {
        private enum JokenPo { Papel, Pedra, Tesoura };

        private long pontuacao = 0;
        private Random rnd = new Random();
        private int rndNum;

        private int opcaoJogador = 0;

        Button btnJogar;

        ImageView imgPedra;
        ImageView imgPapel;
        ImageView imgTesoura;

        private TextView txtPlacar;
        private TextView txtComputador;
        private ImageView imgComputador;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Correta);

            btnJogar = FindViewById<Button>(Resource.Id.btnJogar);
            btnJogar.Text = "Jogar";

            imgPapel = FindViewById<ImageView>(Resource.Id.imgPapel);
            imgPedra = FindViewById<ImageView>(Resource.Id.imgPedra);
            imgTesoura = FindViewById<ImageView>(Resource.Id.imgTesoura);
            txtPlacar = FindViewById<TextView>(Resource.Id.txtPlacar);
            txtComputador = FindViewById<TextView>(Resource.Id.txtComputador);

            imgComputador = FindViewById<ImageView>(Resource.Id.imgComputador);

            imgPapel.SetImageResource(Resource.Drawable.paper);
            imgPedra.SetImageResource(Resource.Drawable.pedra);
            imgTesoura.SetImageResource(Resource.Drawable.tesoura);

            imgPapel.Click += (s, e) =>
            {
                opcaoJogador = 0;
            };

            imgPedra.Click += (s, e) =>
            {
                opcaoJogador = 1;
            };

            imgTesoura.Click += (s, e) =>
            {
                opcaoJogador = 2;
            };

            btnJogar.Click += BtnJogar_Click;

            Button btnEstatistica = FindViewById<Button>(Resource.Id.btnEstatiticas);
            btnEstatistica.Click += (s, e) =>
            {
                var intent = new Intent(this, typeof(Estatisticas));
                StartActivity(intent);
            };
        }

        private void BtnJogar_Click(object sender, EventArgs e)
        {

            rndNum = rnd.Next(3);

            if (opcaoJogador == (int)JokenPo.Tesoura)
            {
                BtnTesouraClick();
            }
            else if (opcaoJogador == (int)JokenPo.Papel)
            {
                BtnPapelClick();
            } else
            {
                BtnPedraClick();
            }
        }

        private void BtnPedraClick()
        {

            if (rndNum == (int)JokenPo.Tesoura)
            {
                txtComputador.Text = "Você Ganhou! Computador escolheu Tesoura.";

                imgComputador.SetImageResource(Resource.Drawable.pedrawin);

                pontuacao++;
                AtualizarTela();
            }
            else if (rndNum == (int)JokenPo.Papel)
            {
                txtComputador.Text = "Você Perdeu!Computador escolheu Papel.";
                imgComputador.SetImageResource(Resource.Drawable.papelwin);
            }
            else
            {
                imgComputador.SetImageResource(Resource.Drawable.pedraigual);
                txtComputador.Text = "Empate. Computador escolheu Pedra. ";
            }

        }

        public void BtnPapelClick()
        {
            if (rndNum == (int)JokenPo.Pedra)
            {
                txtComputador.Text = "Você Ganhou!Computador escolheu Pedra.";

                imgComputador.SetImageResource(Resource.Drawable.papelwin);

                pontuacao++;
                AtualizarTela();
            }
            else if (rndNum == (int)JokenPo.Tesoura)
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
            if (rndNum == (int)JokenPo.Papel)
            {
                txtComputador.Text = "Você Ganhou!Computador escolheu Papel.";

                imgComputador.SetImageResource(Resource.Drawable.tesourawin);

                pontuacao++;
                AtualizarTela();
            }
            else if (rndNum == (int)JokenPo.Pedra)
            {
                txtComputador.Text = "Você Perdeu! Computador escolheu Pedra.";
                imgComputador.SetImageResource(Resource.Drawable.pedrawin);
            }
            else
            {
                imgComputador.SetImageResource(Resource.Drawable.tesouraigual);
                txtComputador.Text = "Empate. Computador escolheu Tesoura. ";
            }
        }

        private void AtualizarTela()
        {
            txtPlacar.Text = "Placar: " + pontuacao;
        }

    }
}



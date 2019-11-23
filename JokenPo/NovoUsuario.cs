using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace JokenPo {
    [Activity (Label = "NovoUsuario")]
    public class NovoUsuario : Activity {

        EditText txtNovoUsuario;
        EditText txtSenhaNovoUsuario;
        Button btnNovoUsuario;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate (savedInstanceState);
            SetContentView(Resource.Layout.NovoUsuario);

            txtNovoUsuario = FindViewById<EditText>(Resource.Id.txtNovoUsuario);
            txtSenhaNovoUsuario = FindViewById<EditText>(Resource.Id.txtSenhaNovoUsuario);
            btnNovoUsuario = FindViewById<Button>(Resource.Id.btnNovoUsuario);

            btnNovoUsuario.Click += BtnNovoUsuario_Click;
        }

        private void BtnNovoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //define o caminho do banco de dados
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Usuario.db3");
                //abre o banco de dados se ele existir
                var db = new SQLiteConnection(dbPath);

                //executa um create table if not existe no banco de dados
                db.CreateTable<Usuario>();

                //Cria Instancia de login
                Usuario tblogon = new Usuario();

                //atribui p nome e a senha informados
                tblogon.usuario = txtNovoUsuario.Text;
                tblogon.senha = txtSenhaNovoUsuario.Text;
                //inclui na tabela
                db.Insert(tblogon);
                Toast.MakeText(this, "Cadastro feito com sucesso...", ToastLength.Short).Show();
                OnBackPressed();
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}
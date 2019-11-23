using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SQLite;
using System.IO;
using System;
using Android.Content;

namespace JokenPo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUsuario;
        EditText txtSenha;
        Button   btnLogar;
        Button   btnCadastrar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtUsuario = FindViewById<EditText>(Resource.Id.txtUsuario);
            txtSenha = FindViewById<EditText>(Resource.Id.txtSenha);
            btnLogar = FindViewById<Button>(Resource.Id.btnLogar);
            btnCadastrar = FindViewById<Button>(Resource.Id.btnCadastrar);

            btnLogar.Click += BtnLogar_Click;
            btnCadastrar.Click += BtnCadastrar_Click;
            CriarBancoDeDados();
        }

        private void BtnCadastrar_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(NovoUsuario));
        }

        private void BtnLogar_Click(object sender, System.EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Usuario.db3");
                var db = new SQLiteConnection(dbPath);
                var dados = db.Table<Usuario>();//Chama Tabela

                //verifica se o usuario/senha existem
                var login = dados.Where(x => x.usuario == txtUsuario.Text && x.senha == txtSenha.Text).FirstOrDefault();//Consulta LINQ

                //se não for nulo
                if (login != null)
                {
                    Toast.MakeText(this, "Login realizado com sucesso", ToastLength.Short).Show();

                    var atividade2 = new Intent(this, typeof(Correta));

                    //pega os dados digitados do txtUsuario
                    atividade2.PutExtra("nome", FindViewById<EditText>(Resource.Id.txtUsuario).Text);
                    StartActivity(atividade2);
                }
                else
                {
                    Toast.MakeText(this, "Nome do usuário e/ou Senha inválida(os)", ToastLength.Short).Show();
                }
            }
                catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }

            }
                              
            private void CriarBancoDeDados()
            {
                try
                {
                    //Combina duas cadeias de caracteres em um caminho
                    string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"Usuario.db3");//cria Banco de dados
                    //cria banco de dados se ela não existir
                    var db = new SQLiteConnection(dbPath);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                }
            }
        }
               
    }


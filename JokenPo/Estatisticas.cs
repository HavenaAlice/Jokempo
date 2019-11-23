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
    [Activity (Label = "Estatisticas")]
    public class Estatisticas : Activity {

        ListView lstUsuarios;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate (savedInstanceState);
            SetContentView(Resource.Layout.Estatisticas);
            // Create your application here
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Usuario.db3");
            var db = new SQLiteConnection(dbPath);
            var dados = db.Table<Usuario>();//Chama Tabela
            List<Usuario> usuarios = dados.ToList();//Consulta LINQ

            String[] lstShow = new String[usuarios.Count];

            for (int i = 0; i < usuarios.Count; i++)
            {
                lstShow[i] = usuarios[i].ToString();
            }

            lstUsuarios = FindViewById<ListView>(Resource.Id.lstUsuarios);

            ArrayAdapter adaptador = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, lstShow);
            lstUsuarios.Adapter = adaptador;
        }
    }
}
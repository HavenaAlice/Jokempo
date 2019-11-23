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
using SQLite;

namespace JokenPo
{
    public class Usuario
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(25)]
        public string usuario { get; set; }
        [MaxLength(15)]
        public string senha { get; set; }
        public long vitorias { get; set; }
        public long derrotas { get; set; }

        public override string ToString()
        {
            return usuario + " - Vitórias: " + vitorias + " || Derrotas: " + derrotas;
        }
    }

}
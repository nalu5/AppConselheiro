using System;
using System.Collections.Generic;
using System.Text;

namespace AppConselheiro.Model
{
    public class Conselho
    {
        public int Id { get; set; }
        public string Frase { get; set; }

        public Conselho()
        {
            this.Frase = "";
        }
    }
}

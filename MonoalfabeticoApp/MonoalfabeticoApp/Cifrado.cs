using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoalfabeticoApp
{

    public class Cifrado
    {
        public string Clave { get; set; }
        public string Mensaje { get; set; }
        public string Resultado { get; set; }

        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Cifrar()
        {

            string newAlfabeto = GenerarAlfabeto();
            StringBuilder builder = new StringBuilder();

            if (newAlfabeto.Length == Alfabeto.Length)
            {
                foreach (char item in this.Mensaje)
                {
                    int index = Alfabeto.IndexOf(item);
                    builder.Append(newAlfabeto[index]);
                }
            }
            else
            {
                throw new Exception("Ocurrio un error en la encripcion !");
            }

            newAlfabeto = builder.ToString();

            return newAlfabeto;
        }

        public String Descifrar()
        {
            string newAlfabeto = GenerarAlfabeto();
            StringBuilder builder = new StringBuilder();

            if (newAlfabeto.Length == Alfabeto.Length)
            {
                foreach (char item in this.Mensaje)
                {
                    int index = newAlfabeto.IndexOf(item);
                    builder.Append(Alfabeto[index]);
                }
            }
            else
            {
                throw new Exception("Ocurrio un error en la encripcion !");
            }

            newAlfabeto = builder.ToString();

            return newAlfabeto;
        }

        private String GenerarAlfabeto()
        {
            this.Clave = EliminarRepetidos(this.Clave).Trim();
            this.Mensaje = this.Mensaje.ToUpper().Trim();

            StringBuilder builder = new StringBuilder();
            builder.Append(this.Clave);

            foreach (char item in Alfabeto)
            {
                if (!builder.ToString().Contains(item))
                {
                    builder.Append(item);
                }
            }

            string newAlfabeto = builder.ToString();

            List<char[]> words = new List<char[]>();

            int charIndex = 0;

            builder = new StringBuilder();

            foreach (var item in newAlfabeto)
            {
                if (charIndex < this.Clave.Length)
                {
                    builder.Append(item);
                    charIndex++;
                }
                else
                {
                    words.Add(builder.ToString().ToCharArray());
                    builder = new StringBuilder();
                    builder.Append(item);
                    charIndex = 1;
                }
            }

            if (builder.ToString().Length < this.Clave.Length)
            {
                Char[] last = new char[Clave.Length];

                charIndex = 0;

                while (charIndex < this.Clave.Length)
                {
                    if (charIndex < builder.ToString().Length)
                    {
                        last[charIndex] = builder.ToString()[charIndex];
                    }
                    else
                    {
                        last[charIndex] = '*';
                    }

                    charIndex++;
                }

                words.Add(last);
            }

            builder = new StringBuilder();
            int fila = 0, columna = 0;

            while (columna < this.Clave.Length)
            {
                foreach (char[] item in words)
                {
                    builder.Append(item[columna]);
                    fila++;
                }
                columna++;
            }

            newAlfabeto = builder.ToString();

            if (builder.ToString().Contains('*'))
            {
                builder = new StringBuilder();

                foreach (char item in newAlfabeto)
                {
                    if (item != '*')
                    {
                        builder.Append(item);
                    }
                }
            }

            newAlfabeto = builder.ToString();

            return newAlfabeto;
        }

        private string EliminarRepetidos(string clave)
        {
            StringBuilder builder = new StringBuilder();

            foreach (char item in clave)
            {
                if (!builder.ToString().Contains(item))
                {
                    builder.Append(item);
                }
            }

            return builder.ToString().ToUpper();
        }
    }
}

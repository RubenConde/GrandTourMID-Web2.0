using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GrandTourMID.BO
{
    public class UsuarioBO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idtipo { get; set; }
        public string imagen { get; set; }
        public int idDireccion { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string mensaje { get; set; }
        public int idchat { get; set; }
        public int idenvia { get; set; }
        public int idrecibe { get; set; }
        public DateTime fecha { get; set; }
        public string ruta { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }


        public string EncriptarMD5(string texto)
        {
            try
            {
                string key = "accesopermitido";
                byte[] keyArray;
                byte[] Arreglo_a_cifrar = UTF8Encoding.UTF8.GetBytes(texto);
                //Se utilizan las clases de encriptacion MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                //Arreglo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_cifrar, 0, Arreglo_a_cifrar.Length);
                tdes.Clear();
                //Se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception)
            {

            }
            return texto;
        }

        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image Imgoriginal, int Altoimg)
        {
            var Radio = (double)Altoimg / Imgoriginal.Height;//diferencia entre la imagenes
            var NuevoAncho = (int)(Imgoriginal.Width * Radio);
            var NuevoAlto = (int)(Imgoriginal.Height * Radio);
            var ImagenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            //creo archivo apartir del bitmap con las nuevas dimensiones
            var g = Graphics.FromImage(ImagenRedimencionada);
            g.DrawImage(Imgoriginal, 0, 0, NuevoAncho, NuevoAlto);
            return ImagenRedimencionada;
        }

    }

   

}
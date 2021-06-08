using Adopt1Dev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public byte[] PasswordOut
        {
            get
            {
                return HashMe(PasswordIn);
            }
        }

        public string PasswordIn { get; set; }

        private byte[] HashMe(string passwordIn)
        {
            //crypto --> Namespace
            //Sha 512
            //tableau de byte

            byte[] data = Encoding.UTF8.GetBytes(passwordIn);
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);
            return result;
        }

        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        public IEnumerable<Notation> Notations { get; set; }
    }
}

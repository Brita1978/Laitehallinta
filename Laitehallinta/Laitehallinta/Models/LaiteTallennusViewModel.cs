using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laitehallinta.Models
{
    public class LaiteTallennusViewModel
    {
  
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
 
        public string Sarjanumero { get; set; }
        public string Merkki { get; set; }
        public string Malli { get; set; }
        public string Muuta { get; set; }
        public string Tarkennus { get; set; }
        public string Logi { get; set; }


        public int LogiID { get; set; }
        public int? SijaintiID { get; set; }
        public int? PaikkaID { get; set; }

        public DateTime? Kirjattusisään { get; set; }
        public int? HenkiloID { get; set; }
        public int? LaiteID { get; set; }
        public int? TilaID { get; set; }


        public string EtunimiH { get; set; }

        public string SukunimiH { get; set; }

        //public string FullNameH
        //{
        //    get { return EtunimiH + " " + SukunimiH; }
        //}
        public string FullNameH2 { get; set; }
        public string FullNameH
        {
            get { return EtunimiH + " " + SukunimiH; }
            set { FullNameH2 = value; }
        }




        public virtual Henkilot Henkilot { get; set; }
        public virtual Laitteet Laitteet { get; set; }
        public virtual Tilat Tilat { get; set; }


    }
}
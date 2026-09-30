using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CAvvistamenti
    {
        private DateTime data;
        private string luogo;
        private string note;
        public CAvvistamenti(DateTime data, string luogo, string note)
        {
            this.Data = data;
            this.Luogo = luogo;
            this.Note = note;
        }
        public DateTime Data
        {
            get => data;
            set
            {
                if (value >= DateTime.Now)
                    throw new Exception("Non puoi prevedere di fare una avvistamento in un tempo futuro");

                data = value;
            }
        }
        public string Luogo
        {
            get => luogo;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Dove hai fatto questo avvistamento? Nel vuoto?");

                luogo = value;
            }
        }
        public string Note
        {
            get => note;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Non ti piace scrivere? Nemmeno a me :)");

                note = value;
            }
        }
        public string ToString()
        {
            return $"Avvistamento avvenuto in data: {Data}, in luogo: {Luogo}. \n Note: {Note}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CAvvistamenti
    {
        private DateTime data; //posso mettere private senza get set perchè non devo visualizzare il valore. C'è il ToString che li mostra
        private string luogo; //Protected lo userei solo se ci sono classi derivate
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Non ti piace scrivere? Nemmeno a me :)");

                note = value;
            }
        }
        public override string ToString()
        {
            return $"Avvistamento avvenuto in data: {Data.ToShortDateString()}, in luogo: {Luogo}. \n Note: {Note}"; //ToShort... perchè voglio solo giorno mese e anno
        }
    }
}

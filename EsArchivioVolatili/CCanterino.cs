using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CCanterino : CPennuto
    {
        private string cantoCaratteristico;

        public CCanterino(int codice, string specie, string habitat, bool tipoMigratorio,double aperturaAlare, string cantoCaratteristico): base(codice, specie, habitat, tipoMigratorio, aperturaAlare)
        {
            this.CantoCaratteristico = cantoCaratteristico;
        }
        public string CantoCaratteristico
        {
            get => cantoCaratteristico;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("SENZA CANTO NON E' CANTERINO");

                cantoCaratteristico = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Canto caratteristico: {CantoCaratteristico}";
        }
    }
}

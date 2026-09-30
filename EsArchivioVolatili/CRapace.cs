using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CRapace : CPennuto
    {
        private string dieta;
        public CRapace(int codice, string specie, string habitat, bool tipoMigratorio,float aperturaAlare, string dieta): base(codice, specie, habitat, tipoMigratorio, aperturaAlare)
        {
            this.Dieta = dieta;
        }
        public string Dieta
        {
            get => dieta;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Attento che muore di fame:(. Il valore di dieta non può essere vuoto");

                dieta = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Dieta: {dieta}";
        }
    }
}

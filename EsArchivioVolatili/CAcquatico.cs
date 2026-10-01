using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CAcquatico : CPennuto
    {
        public TipoAcqua tipoAcqua { get; set; }

        public CAcquatico(int codice, string specie, string habitat, bool tipoMigratorio, double aperturaAlare, TipoAcqua tipoAcqua): base(codice, specie, habitat, tipoMigratorio, aperturaAlare)
        {
            this.tipoAcqua = tipoAcqua;
        }
        public override string ToString()
        {
            return base.ToString() + $", Tipo acqua: {tipoAcqua}";
        }
    }
}

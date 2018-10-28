using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class Record
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Record()
        {

            this.TblRecordsSocio = new HashSet<RecordsSocio>();

        }


        public int id_record { get; set; }

        public Nullable<decimal> pesoInicial { get; set; }

        public Nullable<decimal> pesoBajado { get; set; }

        public Nullable<decimal> pesoActual { get; set; }

        public Nullable<decimal> circCinturaInicial { get; set; }

        public Nullable<decimal> circCinturaBajado { get; set; }

        public Nullable<decimal> circCinturaActual { get; set; }

        public Nullable<decimal> circCaderaInicial { get; set; }

        public Nullable<decimal> circCaderaBajado { get; set; }

        public Nullable<decimal> circCaderaActual { get; set; }

        public Nullable<decimal> circPechoInicial { get; set; }

        public Nullable<decimal> circPechoBajado { get; set; }

        public Nullable<decimal> circPechoActual { get; set; }

        public Nullable<decimal> altura { get; set; }

        public string talla { get; set; }

        public Nullable<decimal> grasaCorporal { get; set; }

        public Nullable<decimal> edad { get; set; }

        public Nullable<decimal> frecCardicaMaxima { get; set; }

        public Nullable<decimal> frecCardicaReposo { get; set; }

        public Nullable<decimal> porceEntrenamiento { get; set; }

        public Nullable<decimal> imc { get; set; }

        public Nullable<decimal> pie { get; set; }

        public string guia { get; set; }

        public string observaciones { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<RecordsSocio> TblRecordsSocio { get; set; }
    }
}
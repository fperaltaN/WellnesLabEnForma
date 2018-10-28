using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class RecordTicket
    {
        public int id_record_ticket { get; set; }

        public int id_socio { get; set; }

        public decimal pliegueTricipal { get; set; }

        public decimal pliegueEscapular { get; set; }

        public decimal trigliceridos { get; set; }

        public decimal Colesterol { get; set; }

        public decimal Glucosa { get; set; }

        public decimal frecuenciaCardiaca { get; set; }

        public decimal frecuanciArtSisfolica { get; set; }

        public decimal frecuanciArtDiasfolica { get; set; }

        public decimal porcentajeCargaPecho { get; set; }

        public decimal porcentajeCargaPierna { get; set; }

        public decimal metabolismoBasal { get; set; }



        public virtual Socio Socio { get; set; }
    }
}
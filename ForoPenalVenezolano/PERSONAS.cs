using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForoPenalVenezolano {
    class PERSONAS {
        public string
            ci,
            nom,
            ape,
            sex,
            dir,
            tlf;
        DateTime
            f_nac;

        public PERSONAS(string ci, string nom, string ape, string sex, DateTime f_nac, string dir, string tlf) {
            this.ci=ci;
            this.nom=nom;
            this.ape=ape;
            this.sex=sex;
            this.f_nac=f_nac;
            this.dir=dir;
            this.tlf=tlf;
        }

        public PERSONAS() { }
    }
}

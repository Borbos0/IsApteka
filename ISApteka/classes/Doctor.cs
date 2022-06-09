using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka
{
    partial class Doctor
    {
        public string FixedImageDoctor
        {
            get
            {
                if (String.IsNullOrEmpty(DoctorImg) || String.IsNullOrWhiteSpace(DoctorImg)) return @"/img/imageDoc.png";
                else return DoctorImg;
            }
        }
        public override string ToString()
        {
            return DoctorName + " " + DoctorSecondName + " " + DoctorSurname;
        }
    }
}

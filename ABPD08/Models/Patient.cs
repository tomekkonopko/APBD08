﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ABPD08.Models
{
    public class Patient
    {

        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }

    }
}
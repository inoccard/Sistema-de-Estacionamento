﻿using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.IFeatures
{
    internal interface IFeature_Parking
    {
        TimeSpan Period_CheckOut(DateTime Entrada, DateTime Saida)
        {
          
            return TimeSpan.MaxValue;
        }

        void Validation_Venancies(int id) { }

        string CredentialRadom() { return string.Empty; }

        double Pagamento(TimeSpan Periodo) { return 0; }
    }
}
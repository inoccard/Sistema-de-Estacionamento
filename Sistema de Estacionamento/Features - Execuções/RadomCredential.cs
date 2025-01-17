﻿using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class RandomCredential : IFeature_Parking
    {
        private readonly Random Aux_random = new Random();
        public string CredentialRadom()
        {
            string Credencial=string.Empty;
            bool random = true;

            while (random)
            {
                for (int i = 0; i < 3; i++)
                {
                    char letraAleatoria = (char)Aux_random.Next(65, 91);//ASCII (A - Z)
                    Credencial += letraAleatoria.ToString().ToUpper();
                }
               
                for (int i = 3; i < 6; i++)
                {
                    int numeroAleatorio = Aux_random.Next(0, 10);// 0 A 9
                    Credencial += numeroAleatorio.ToString();
                }
                ValidacaoCredendital Val_Credential= new ValidacaoCredendital();

                bool validacao=Val_Credential.ValidacaoCredencial_EF(Credencial);

                if (validacao==true)
                {
                    return CredentialRadom(); //recursividade (loop)
                }
                else
                {
                    random = false;   
                }
            }
            return Credencial;
        }
    }
}

﻿using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal class MotocycleParking : AtributesParking
    {
       
        private int _numeroVagasMotos;
        
        private int _numeroVagasDisponiveisMotos;

        public override int NumeroVagas
        { 
            get => _numeroVagasMotos;
            set => _numeroVagasMotos = value;
        }
        public override int NumeroVagasDisp
        {
            get => _numeroVagasDisponiveisMotos;
            set=> _numeroVagasDisponiveisMotos=value;
        }

        public override void AlterarNumeroVagasDisponiveis(int N_vagas, int id) { }//Atribuição de valores incrementando ou decrementando na varaivel de vagas disponíveis
        public override void AlterarNumeroVagas(int novoNumero, MyDbContext contexto)
        {
            var estacionamento = contexto.Estacionamento.FirstOrDefault(x => x.Id == 2);

            if (estacionamento != null)
            {
                estacionamento.NumeroVagas = novoNumero;
                contexto.SaveChanges();
            }
        }
    }
}

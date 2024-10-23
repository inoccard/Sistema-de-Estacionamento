﻿using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.IStorage___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Storage
{
    internal class StorageClient : AtributesClient, IStorage_Client
    {
        VehicleCheckOut aux_co = new VehicleCheckOut();

        public string S_Name()
        {
            bool aux1 = true;
            while (aux1)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("\nDigite o nome do cliente:");
                Nome_Cliente = Console.ReadLine().TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(Nome_Cliente))
                {
                    Console.WriteLine("\nO nome do cliente não pode ser nulo.");
                }
                else
                {
                    aux1 = false;
                }
            }
            return Nome_Cliente;
        }

        public DateTime S_CheckIn()
        {
            Entrada = DateTime.Now;
           
            return Entrada;
        }

        

        public DateTime  S_CheckOut()
        {

            bool validacao1 = true;
            bool validacao2 = false;

            while (validacao1)
            {
                Console.WriteLine("\nInforme a credencial do cliente:");
                string Credencial = Console.ReadLine().TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(Credencial))
                {
                    Console.WriteLine("\nO valor informado não pode ser nulo.");
                }
                else
                {
                    validacao1 = false;

                    //Query para verificar a existência da credencial/ nome do usuário e se essa query encontrar o nome, irá validar a variavel "validacao2".
                }
            }
            while (validacao2)
            {
                Console.WriteLine("\nDados do cliente e veículo:");
                Console.WriteLine("============================================");


                //Incrementar uma funcionalidade irá realizar a query conforme o nome do cliente, exibir os dados do veículo de vinculação e o check-in de entrada ao estacionamento


                Console.WriteLine("============================================");
                Console.WriteLine("\nDeseja confirmar o check-out? ");
                Console.WriteLine("\n1. Sim");
                Console.WriteLine("2. Não");
                Console.WriteLine("============================================");
                if (int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 2)
                {
                    Console.WriteLine("\nOpção inválida. Digite (1) para 'Sim' ou (2) para 'Não'.");
                }
                else if (op.Equals(1))
                {
                    validacao2 = false;

                    Saida = DateTime.Now;

                  ;// Segunda etapa do processo de Check-Out

                }
                else if (op.Equals(2))
                {
                    validacao2 = false;

                    Program.Main(ref_args);

                }
            }
            return Saida;
        }
    }
}

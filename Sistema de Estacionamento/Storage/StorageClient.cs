﻿using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.DataBase.EF___CRUD;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.IStorage___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Storage
{
    internal class StorageClient : StorageVehicle, IStorage_Client
    {
        QueryCredentialOrPlate_EF aux_Q = new QueryCredentialOrPlate_EF(); //Consulta dos dados cliente e veiculo pela credencial
        ValidacaoCredendital aux_VAL= new ValidacaoCredendital(); //Validação da credencial (Evitar duplicidades)
   
        public string S_Name()
        {
            bool aux1 = true;
            string nomeCliente=string.Empty;
            while (aux1)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("\nDigite o nome do cliente:");
                 nomeCliente = Console.ReadLine().TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(nomeCliente))
                {
                    Console.WriteLine("\nO nome do cliente não pode ser nulo.");
                }
                else
                {
                    aux1 = false;
                }
            }
            return nomeCliente;
        }

        public DateTime S_CheckIn()
        {
            DateTime entrada = DateTime.Now;
           
            return entrada;
        }

        public (DateTime,DateTime, string, bool) S_CheckOut()
        {
            bool validacao1 = true;
            bool validacao2 = false;
            DateTime saida=DateTime.Now;
            string Credencial=string.Empty;
            DateTime _Entrada=DateTime.Now;

            while (validacao1)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("\nInforme a credencial do cliente:");
                Credencial = Console.ReadLine().TrimStart().TrimEnd().ToUpper();

                if (string.IsNullOrEmpty(Credencial) || Credencial.Length!=6)
                {
                    Console.WriteLine("\nCredencial inválida. A credencial deve possuir 6 caracteres.");
                }
                else
                {
                    validacao1 = false;

                    bool val= aux_VAL.ValidacaoCredencial_EF(Credencial); //Verifica a existencia da credencial
                    if (val!= true)
                    {
                        validacao2 = false;                      
                        return (_Entrada, saida, Credencial, val);
                    }
                    else 
                    {
                        validacao2 = true;
                    }
                }
            }

            while (validacao2)
            {
                Console.WriteLine("\nDados do cliente e veículo:");
                Console.WriteLine("============================================");

                aux_Q.QueryCredential_EF(Credencial);
                var ATB = aux_Q.GetDadosQuery();
                var Atributos_Cliente = ATB.Item1;
                var Atributos_Veiculo = ATB.Item2;
          

                Console.WriteLine($"\nNome do cliente: {Atributos_Cliente.Nome_Cliente}");
                Console.WriteLine($"Credencial de acesso: {Atributos_Cliente.Credencial_Acesso}");
                Console.WriteLine($"Entrada: {Atributos_Cliente.Entrada}");

                _Entrada = Atributos_Cliente.Entrada;

                
                Console.WriteLine($"\nNome do veículo: {Atributos_Veiculo.Nome_Veiculo}");
                Console.WriteLine($"Tipo de veiculo: {Atributos_Veiculo.TipoVeiculo}");
                Console.WriteLine($"Placa: {Atributos_Veiculo.Placa}");
                Console.WriteLine($"Cor: {Atributos_Veiculo.Cor}");

                
                Console.WriteLine("============================================");
                Console.WriteLine("\nContinuar:");
                Console.WriteLine("\n1. Sim");
                Console.WriteLine("2. Não");
                Console.WriteLine("============================================");
                if (!int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 2)
                {
                    Console.WriteLine("\nOpção inválida. Digite (1) para 'Sim' ou (2) para 'Não'.");
                }
                else if (op.Equals(1))
                {
                    validacao2 = false;

                    saida = DateTime.Now;
                }
                else if (op.Equals(2))
                {
                    validacao2 = false;
                    return (_Entrada, saida, Credencial, false);
                }   
            }
            return (_Entrada, saida, Credencial, true);
        }
    }
}

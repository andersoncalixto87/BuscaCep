using BuscaCep.UI.model;
using BuscaCep.UI.service;
using System;
using System.Threading.Tasks;

namespace BuscaCep.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            Console.WriteLine("---------------Sistema busca de CEP---------------");
            
            var buscarCep = "S";
            while (buscarCep.ToUpper() == "S" || buscarCep.ToUpper() == "SIM")
            {
                Console.WriteLine("");
                Console.WriteLine("Digite um CEP para pesquisar:");
                var CEP = Console.ReadLine();
                if (Helper.validaCEP(ref CEP))
                {
                    var EnderecoCompleto = await ServiceCep.GetEnderecoByCepAsync(CEP);

                    if (EnderecoCompleto != null)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---Resultado---");
                        Console.WriteLine("");
                        Console.WriteLine($"Logradouro: {EnderecoCompleto.Logradouro}");
                        Console.WriteLine($"Complemento: {EnderecoCompleto.Complemento}");
                        Console.WriteLine($"Bairro: {EnderecoCompleto.Bairro}");
                        Console.WriteLine($"Localidade: {EnderecoCompleto.Localidade}");
                        Console.WriteLine($"Uf: {EnderecoCompleto.Uf}");
                        Console.WriteLine($"Cep: {EnderecoCompleto.Cep}");
                    }
                    else
                    {
                        Console.WriteLine("Objeto 'EnderecoCompleto' está vazio");
                    }
                }
                else
                {
                    Console.WriteLine("Cep Inválido");
                }

                Console.WriteLine("");
                Console.WriteLine("Deseja consultar outro Cep? ((S)im ou (N)ão)");
                buscarCep = Console.ReadLine();
            }
            
        }
    }
}

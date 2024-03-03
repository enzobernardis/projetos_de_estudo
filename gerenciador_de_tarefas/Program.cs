using System;
using System.Collections.Generic;

namespace gerenciador_de_tarefas
{
    class Program
    {
        static List<Task> listOfTasks = new List<Task>();
        public class Task
        {
            private string NameToShow { get; set; }
            private string NameToCode;
            private string Description { get; set; }
            private DateTime LimitDate;

            public Task() 
            {
                Console.WriteLine("Digite um titulo para a tarefa:");
                NameToShow = Console.ReadLine();
                NameToCode = NameToShow.ToLower().Replace(" ", "");
                Console.WriteLine("Digite o que voce deve fazer para completar a tarefa:");
                Description = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Qual a data limite para voce terminar a tarefa?");
                        Console.WriteLine("Ano:");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Mes (Ex: 1, 4, 12):");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Dia:");
                        int day = int.Parse(Console.ReadLine());
                        LimitDate = new DateTime(year, month, day);
                        break;
                    } catch (FormatException ex)
                    {
                        Console.WriteLine("Erro: " + ex);
                        Console.WriteLine("Por favor, digite apenas numeros");
                    }
                }

                Console.WriteLine("Tarefa adicionada!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ola! voce acabou de abrir o seu gerenciador de tarefas! o que voce deseja fazer?");
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                switch (input.Replace(" ", "").ToLower())
                {
                    case "faq":
                        Faq();
                        break;
                    case "adicionartarefa":
                        Task task = new Task();
                        listOfTasks.Add(task);
                        break;
                }
            }
        }

        static void Faq()
        {
            string[] descriptionsOfComands = {
                "Crie uma tarefa com nome, descrição e data limite para completar"
            };
            Console.WriteLine("Comandos:");
            Console.WriteLine("1 - Adicionar tarefa");

            Console.WriteLine("Voce deseja ver o que um comando faz mais especificamente? (Sim/Nao)");

            if (Console.ReadLine().Trim().ToLower() == "sim")
            {
                Console.WriteLine("Qual? (digite o numero do comando)");
                Console.WriteLine(descriptionsOfComands[int.Parse(Console.ReadLine().Trim())]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public Contato(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | Telefone: {Telefone}";
    }
}

class Program
{
    static List<Contato> contatos = new List<Contato>();

    static void Main(string[] args)
    {
        int opcao = 0;

        while (opcao != 5)
        {
            Console.Clear();
            Console.WriteLine("AGENDA TELEFÔNICA");
            Console.WriteLine("1 - Adicionar Contato");
            Console.WriteLine("2 - Listar Contatos");
            Console.WriteLine("3 - Pesquisar Contato");
            Console.WriteLine("4 - Remover Contato");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida! Pressione ENTER...");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    AdicionarContato();
                    break;
                case 2:
                    ListarContatos();
                    break;
                case 3:
                    PesquisarContato();
                    break;
                case 4:
                    RemoverContato();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AdicionarContato()
    {
        Console.Clear();
        Console.Write("Digite o nome do contato: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o telefone: ");
        string telefone = Console.ReadLine();

        contatos.Add(new Contato(nome, telefone));

        Console.WriteLine("Contato adicionado com sucesso!");
        Console.ReadLine();
    }

    static void ListarContatos()
    {
        Console.Clear();
        Console.WriteLine("LISTA DE CONTATOS");

        if (!contatos.Any())
        {
            Console.WriteLine("Nenhum contato cadastrado.");
        }
        else
        {
            foreach (var c in contatos)
            {
                Console.WriteLine(c);
            }
        }

        Console.ReadLine();
    }

    static void PesquisarContato()
    {
        Console.Clear();
        Console.Write("Digite o nome para pesquisa: ");
        string busca = Console.ReadLine().ToLower();

        var resultados = contatos
            .Where(c => c.Nome.ToLower().Contains(busca))
            .ToList();

        if (resultados.Any())
        {
            Console.WriteLine("Resultados encontrados:");
            foreach (var c in resultados)
            {
                Console.WriteLine(c);
            }
        }
        else
        {
            Console.WriteLine("Nenhum contato encontrado!");
        }

        Console.ReadLine();
    }

    static void RemoverContato()
    {
        Console.Clear();
        Console.Write("Digite o nome do contato a remover: ");
        string nome = Console.ReadLine().ToLower();

        var contato = contatos.FirstOrDefault(c => c.Nome.ToLower() == nome);

        if (contato != null)
        {
            contatos.Remove(contato);
            Console.WriteLine("Contato removido!");
        }
        else
        {
            Console.WriteLine("Contato não encontrado!");
        }

        Console.ReadLine();
    }
}

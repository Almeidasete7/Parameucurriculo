
    public class Compromisso
    {
        public DateTime DataHora { get; set; }
        public string Servico { get; set; }
        public string Cliente { get; set; }

        public override string ToString()
        {
            return $"{DataHora}: {Servico} para {Cliente}";
        }
    }

    static List<Compromisso> compromissos = new List<Compromisso>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Adicionar Compromisso");
            Console.WriteLine("2. Remover Compromisso");
            Console.WriteLine("3. Visualizar Compromissos");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarCompromisso();
                    break;
                case "2":
                    RemoverCompromisso();
                    break;
                case "3":
                    VisualizarCompromissos();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarCompromisso()
    {
        Console.Write("Informe a data (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        
        Console.Write("Informe a hora (HH:mm): ");
        TimeSpan hora = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Informe o serviço: ");
        string servico = Console.ReadLine();

        Console.Write("Informe o nome do cliente: ");
        string cliente = Console.ReadLine();

        Compromisso compromisso = new Compromisso
        {
            DataHora = data.Date.Add(hora),
            Servico = servico,
            Cliente = cliente
        };

        compromissos.Add(compromisso);
        Console.WriteLine("Compromisso adicionado com sucesso!");
    }

    static void RemoverCompromisso()
    {
        Console.Write("Informe a data (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        
        Console.Write("Informe a hora (HH:mm): ");
        TimeSpan hora = TimeSpan.Parse(Console.ReadLine());

        DateTime dataHora = data.Date.Add(hora);
        var compromisso = compromissos.Find(c => c.DataHora == dataHora);

        if (compromisso != null)
        {
            compromissos.Remove(compromisso);
            Console.WriteLine("Compromisso removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Compromisso não encontrado.");
        }
    }

    static void VisualizarCompromissos()
    {
        if (compromissos.Count == 0)
        {
            Console.WriteLine("Nenhum compromisso agendado.");
            return;
        }

        Console.WriteLine("Compromissos agendados:");
        foreach (var compromisso in compromissos)
        {
            Console.WriteLine(compromisso);
        }
    }


class ControllerBand
{
    private Dictionary<string, List<int>> listBand = new();
    private Setup setup;
    
    public ControllerBand(Setup setup)
    {
        this.setup = setup;
    }

    private string GetBandNameFromUser()
    {
        Console.Write("Digite o nome da banda: ");
        return Console.ReadLine()!;
    }

    private int GetNoteFromUser()
    {
        int note;

        while (true)
        {
            Console.Write("Digite a nota da banda (1 até 10): ");

            if (int.TryParse(Console.ReadLine(), out note) && note >= 1 && note <= 10)
            {
                break;
            }
        
            Console.WriteLine("\nAteção: Por favor, insira uma nota válida (1 até 10).");
        }

        return note;
    }

    public void ControllerAddBand()
    {
        Console.Clear();
        setup.ShowTitle("Adicionado uma nova banda");

        string nameBand = GetBandNameFromUser();

        if (!listBand.ContainsKey(nameBand))
        {
            listBand.Add(nameBand, new List<int>());
            Console.Write($"\nResposta: A banda ({nameBand}) foi adicionado com sucesso! ");
        }
        else 
        {
            Console.Write($"\nResposta: A banda ({nameBand}) já foi adicionada! ");
        }

        setup.DefaultRedirection();
    }

    public void ControllerListBand()
    {
        Console.Clear();
        setup.ShowTitle("Listagem das bandas");

        var checkListBand = listBand.Count == 0 ? "Nenhuma banda foi adicionada" : "\nFim da lista de bandas";

        foreach (var itemBand in listBand.Keys)
        {
            Console.WriteLine($"Banda: {itemBand}");
        }

        Console.WriteLine($"{checkListBand}");

        setup.RedirectionByKey();
    }

    public void ControllerAddNoteToBand()
    {
        Console.Clear();
        setup.ShowTitle("Adicionando nota para banda");

        string nameBand = GetBandNameFromUser();

        if (listBand.ContainsKey(nameBand))
        {
            int noteBand = GetNoteFromUser();
            listBand[nameBand].Add(noteBand);
            Console.Write($"\nResposta: A nota {noteBand} foi adicionada com sucesso para {nameBand}.");
        }
        else 
        {
            Console.Write($"\nResposta: A banda {nameBand} ainda não foi adicionada! ");
            Thread.Sleep(2000);
            Console.Clear();
            ControllerAddNoteToBand();
        }

        setup.DefaultRedirection();
    }

    public void ControllerShowAverageBand()
    {
        Console.Clear();
        setup.ShowTitle("Mostrando média da banda");

        string nameBand = GetBandNameFromUser();

        if (listBand.ContainsKey(nameBand) && listBand[nameBand].Any())
        {
            double averageBand = listBand[nameBand].Average();
            Console.WriteLine($"\nResposta: A banda {nameBand} tem média {averageBand}");
            setup.RedirectionByKey();
        }
        else if (!listBand.ContainsKey(nameBand))
        {
            Console.Write($"\nResposta: A banda {nameBand} ainda não foi adicionada! ");
            Thread.Sleep(2000);
            ControllerShowAverageBand();
        }
        else 
        {
            Console.WriteLine($"\nResposta: A banda {nameBand} não possui notas para calcular a média!");
            Thread.Sleep(2000);
            ControllerShowAverageBand();
        }
    }    
}
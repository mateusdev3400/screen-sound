class Setup
{
    ControllerBand controllerBand;

    public Setup()
    {
        controllerBand = new ControllerBand(this);
    }
    
    public void MensageWelcome()
    {
        Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
        Console.WriteLine("\nBem-vindo ao ScreenSound");
    }

    public void MensageInitial()
    {
        Console.WriteLine("\nDigite 1 para adicionar uma banda");
        Console.WriteLine("Digite 2 para mostrar bandas");
        Console.WriteLine("Digite 3 para adicionar nota da banda");
        Console.WriteLine("Digite 4 para mostrar média da banda");
        Console.WriteLine("Digite 0 para sair do programa");

        Console.Write("\nEscolha uma opção: ");
        int chosenOption = int.Parse(Console.ReadLine()!);

        switch(chosenOption)
        {
            case 1: controllerBand.ControllerAddBand();
                break;
            case 2: controllerBand.ControllerListBand();
                break;
            case 3: controllerBand.ControllerAddNoteToBand();
                break;
            case 4: controllerBand.ControllerShowAverageBand();
                break;
            case 0: Console.WriteLine("Tchau. Até mais!");
                break;
            default: ShowMessageOptionDefault();
                break;
        }
    }

    public void SetupInitial()
    {
        Console.Clear();
        MensageWelcome();
        MensageInitial();
    }

    public void ShowMessageOptionDefault()
    {
        Console.WriteLine("Opção inválida, tente outra");
        Thread.Sleep(1000);
        Console.Clear();
        SetupInitial();
    }

    public void DefaultRedirection()
    {
        Thread.Sleep(2000);
        Console.Clear();
        SetupInitial();
    }

    public void RedirectionByKey()
    {
        Console.Write("\nDigite a tecla espaço para voltar ao menu inicial: ");
        Console.ReadKey();
        Console.Clear();
        SetupInitial();
    }

    public void ShowTitle(string title)
    {
        int counterLetterTitle = title.Length;
        string asterisk = string.Empty.PadLeft(counterLetterTitle, '*');

        Console.WriteLine(asterisk);
        Console.WriteLine(title);
        Console.WriteLine(asterisk + "\n");
    }
}
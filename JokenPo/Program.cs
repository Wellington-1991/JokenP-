using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

RegraDoJogo jogar = new RegraDoJogo();
jogar.IniciarPartida();
Environment.Exit(1);

public class Jogador
{
    public Jogador(string nome, string opcao, int id)
    {
        this.Id = id;
        this.Nome = nome;
        this.OpcaoSelecionada = opcao;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public string OpcaoSelecionada { get; set; }
}

public class CriarNovoJogador
{
    public string NovoJogador(int i)
    {
        Console.Write("Jogador Número "+ i +" Digite seu nome: ");
        return Console.ReadLine().ToUpper();
    }
}

public class RegraDoJogo
{
    public void IniciarPartida()
    {
        ExibirMenu();
        string mensagem = "";
        string opcaoEscolhida = "";
        bool continuarJogando;
        bool jogar = true;

        RegraDoJogo jogo = new RegraDoJogo();
        List<Jogador> jogadores = new List<Jogador>();
        CriarNovoJogador criarJogador = new CriarNovoJogador();

        for (int i = 0; i < 2; i++)
        {
            Jogador novoJogador = new Jogador(criarJogador.NovoJogador(i), "",i);

            jogadores.Add(novoJogador);

            ExibirMenu();
        }

        while (jogar)
        {
            continuarJogando = false;

            foreach (Jogador jogadorDaVez in jogadores)
            {
                bool opcaoValida = true;

                while (opcaoValida)
                {
                    jogo.ExibirOpcoes();
                    Console.WriteLine("Sua vez: " + jogadorDaVez.Nome.ToUpper() + " - Por favor escolha uma das opções acima:\n");
                    opcaoEscolhida = Console.ReadLine().ToUpper();
                    if (jogo.ValidarDigitacaoOpcaoEscolhida(opcaoEscolhida))
                    {
                        jogadorDaVez.OpcaoSelecionada = opcaoEscolhida;
                        opcaoValida = false;
                    }else
                    {
                        Console.WriteLine("Opção inválida, escolha novamente!");
                        Thread.Sleep(1000);
                    }
                    
                    ExibirMenu();
                }
            }

            Jogador primeiroJogador = jogadores[0];
            Jogador segundoJogador = jogadores[1];

            switch (primeiroJogador.OpcaoSelecionada)
            {
                case "PEDRA":
                    if (segundoJogador.OpcaoSelecionada == RegraDoJogo.opcoes.PAPEL.ToString())
                    {
                        mensagem = segundoJogador.Nome + " venceu - Papel ganha da pedra!";
                    }
                    else if (primeiroJogador.OpcaoSelecionada == segundoJogador.OpcaoSelecionada)
                    {
                        mensagem = "Impate - Ninguem vence";
                    }
                    else if (segundoJogador.OpcaoSelecionada == RegraDoJogo.opcoes.TESOURA.ToString())
                    {
                        mensagem = primeiroJogador.Nome + " venceu - Pedra ganha de tesoura!";
                    }
                    break;
                case "PAPEL":
                    if (segundoJogador.OpcaoSelecionada == RegraDoJogo.opcoes.TESOURA.ToString())
                    {
                        mensagem = segundoJogador.Nome + " venceu - Tesoura corta Papel!";
                    }
                    else if (primeiroJogador.OpcaoSelecionada == segundoJogador.OpcaoSelecionada)
                    {
                        mensagem = "Impate - Ninguem vence";
                    }
                    else if (segundoJogador.OpcaoSelecionada == RegraDoJogo.opcoes.PEDRA.ToString())
                    {
                        mensagem = primeiroJogador.Nome + " venceu - Papel ganha da pedra!";
                    }
                    break;
                case "TESOURA":
                    if (segundoJogador.OpcaoSelecionada == RegraDoJogo.opcoes.PEDRA.ToString())
                    {
                        mensagem = segundoJogador.Nome + " venceu - Pedra ganha de Tesoura!";
                    }
                    else if (primeiroJogador.OpcaoSelecionada == segundoJogador.OpcaoSelecionada)
                    {
                        mensagem = "Impate - Niguem vence";
                    }
                    else if (segundoJogador.OpcaoSelecionada == RegraDoJogo.opcoes.PAPEL.ToString())
                    {
                        mensagem = primeiroJogador.Nome + " venceu - Tesoura corta Papel!";
                    }
                    break;
            }
            ExibirMenu();

            Console.WriteLine(primeiroJogador.Nome + ": " + primeiroJogador.OpcaoSelecionada);
            Console.WriteLine(segundoJogador.Nome + ": " + segundoJogador.OpcaoSelecionada);
            Console.WriteLine("\n" + mensagem + "\n");
            
            while (continuarJogando == false)
            {
                Console.Write("Deseja continuar : " + RegraDoJogo.continuarJogando.SIM.ToString() + " OU " + RegraDoJogo.continuarJogando.NAO.ToString() + " ? ");
                string continuar = Console.ReadLine().ToUpper();

                if (DigitacaoCorreta(continuar) && continuar == RegraDoJogo.continuarJogando.SIM.ToString())
                {
                    continuarJogando = true;
                }
                else
                {
                    continuarJogando = true;
                    jogar = false;
                }

                Console.Clear();
            }
        }
        Console.WriteLine("#####  FIM  #####");
        Thread.Sleep(2000);
    }

    public void ExibirOpcoes()
    {

        Console.WriteLine(" ------------- Opções ------------- ");
        foreach (opcoes opcao in Enum.GetValues(typeof(opcoes)))
        {

            Console.Write("|  " + opcao.ToString() + "  |");
        }
        Console.WriteLine("\n ---------------------------------- \n");
    }

    public bool ValidarDigitacaoOpcaoEscolhida(string opcao)
    {
        if (opcao == RegraDoJogo.opcoes.PEDRA.ToString() || opcao == RegraDoJogo.opcoes.PAPEL.ToString() || opcao == RegraDoJogo.opcoes.TESOURA.ToString())
        {
            return true;
        }

        return false;
    }

    public bool DigitacaoCorreta(string continuar)
    {
        if (continuar == RegraDoJogo.continuarJogando.SIM.ToString() || continuar == RegraDoJogo.continuarJogando.NAO.ToString())
        {
            return true;
        }
        return false;
    }

    public void ExibirMenu()
    {
        Console.Clear();

        Console.WriteLine(" ---------------------------------- ");
        Console.WriteLine("|             JOKEN PÔ             |");
        Console.WriteLine(" ---------------------------------- ");
    }
    public enum opcoes
    {
        PEDRA,
        PAPEL,
        TESOURA
    }

    public enum continuarJogando
    {
        SIM,
        NAO
    }
}


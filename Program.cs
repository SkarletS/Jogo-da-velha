namespace jogovelha
{
    class Program
    {
        // matriz pra representar o tabuleiro do jogo
        static char[,] jogo = {
        {' ', ' ', ' '},
        {' ', ' ', ' '},
        {' ', ' ', ' '}
    };

        // jogador atual inicia com X
        static char jogador = 'X';

        static void Main()
        {
            // loop principal do jogo
            while (true)
            {
                Console.Clear();
                ImprimiJogo();
                JogoAtual();

                // verifica se há um vencedor ou empate após cada jogada
                if (Vencedor() || Empate())
                {
                    Console.Clear();
                    ImprimiJogo();

                    // resultado do jogo
                    if (Vencedor())
                    {
                        Console.WriteLine("Jogador " + jogador + " é o campeão do jogo!");
                    }
                    else
                    {
                        Console.WriteLine("Empate! Parece que temos jogadores igualmente habilidosos.");
                    }    
                    break; // Sai do loop do jogo após o resultado ser determinado
                }
                ProxJogo();
            }
            Console.ReadLine(); // entrada do usuário antes de encerrar o programa
        }

        static void ImprimiJogo()
        {
            Console.WriteLine("  Jogo da Velha");
            Console.WriteLine();
            Console.WriteLine("  0 1 2"); // colunas
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " "); // linhas
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(jogo[i, j]); // monta o jogo
                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("  -+-+-");
            }
        }

        static void JogoAtual()
        {
            Console.WriteLine();
            Console.WriteLine("Jogador " + jogador + ", é sua vez.");
            while (true)
            {
                Console.Write("Digite a linha (0, 1 ou 2): ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Digite a coluna (0, 1 ou 2): ");
                int col = int.Parse(Console.ReadLine());

                // verifica se a jogada é válida e atualiza o jogo
                if (row >= 0 && row < 3 && col >= 0 && col < 3 && jogo[row, col] == ' ')
                {
                    jogo[row, col] = jogador;
                    break;
                }
                else
                {
                    Console.WriteLine("Ops! Posição ocupada, escolha outra.");
                }
            }
        }

        // função pra alternar para o próximo jogador
        static void ProxJogo()
        {
            if (jogador == 'X')
                jogador = 'O';
            else
                jogador = 'X';
        }

        static bool Vencedor()
        {
            // verifica linhas, colunas e diagonais para determinar se há um vencedor
            for (int i = 0; i < 3; i++)
            {
                if (jogo[i, 0] == jogador && jogo[i, 1] == jogador && jogo[i, 2] == jogador)
                    return true; // venceu na linha i
                if (jogo[0, i] == jogador && jogo[1, i] == jogador && jogo[2, i] == jogador)
                    return true; // venceu na coluna i
            }

            // verifica diagonais
            if ((jogo[0, 0] == jogador && jogo[1, 1] == jogador && jogo[2, 2] == jogador) ||
                (jogo[0, 2] == jogador && jogo[1, 1] == jogador && jogo[2, 0] == jogador))
                return true; // venceu na diagonal

            return false; // não há vencedor ainda
        }

        static bool Empate()
        {
            // verifica se tem empate
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (jogo[i, j] == ' ')
                        return false; // espaços vazios no jogo
                }
            }
            return true; // empate
        }
    }

}
/*
Heurísticas de Nielsen aplicadas:

1. Visibilidade do Status (#1):
   - Mensagens como [Passo 1 de 3], [Passo 2 de 3], etc., informam o progresso do usuário.

2. Controle e Liberdade (#3):
   - O usuário pode digitar "voltar" para retornar à etapa anterior.
   - Pode digitar "cancelar" a qualquer momento para encerrar o pedido.

3. Ajuda e Prevenção de Erros (#9):
   - Validação de entradas com mensagens claras e específicas.
   - Exemplo: "Código 99 não encontrado. Nossos códigos vão de 1 a 10."
*/

using System;

class Program
{
    static void Main()
    {
        int passo = 1;
        int codigoProduto = 0;
        int quantidade = 0;

        while (true)
        {
            // PASSO 1 - CÓDIGO DO PRODUTO
            while (passo == 1)
            {
                Console.Clear();
                Console.WriteLine("[Passo 1 de 3] Seleção de Produto");
                Console.WriteLine("Digite o código do produto (1 a 10):");
                Console.WriteLine("(ou digite 'cancelar')");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    CancelarPedido();
                    return;
                }

                if (int.TryParse(entrada, out codigoProduto))
                {
                    if (codigoProduto >= 1 && codigoProduto <= 10)
                    {
                        passo = 2;
                    }
                    else
                    {
                        Console.WriteLine($"Código {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10.");
                        Pausa();
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite um número de 1 a 10.");
                    Pausa();
                }
            }

            // PASSO 2 - QUANTIDADE
            while (passo == 2)
            {
                Console.Clear();
                Console.WriteLine("[Passo 2 de 3] Quantidade");
                Console.WriteLine("Digite a quantidade desejada:");
                Console.WriteLine("(ou 'voltar' | 'cancelar')");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    CancelarPedido();
                    return;
                }

                if (entrada == "voltar")
                {
                    passo = 1;
                    break;
                }

                if (int.TryParse(entrada, out quantidade) && quantidade > 0)
                {
                    passo = 3;
                }
                else
                {
                    Console.WriteLine("Quantidade inválida. Digite um número maior que 0.");
                    Pausa();
                }
            }

            // PASSO 3 - CONFIRMAÇÃO
            while (passo == 3)
            {
                Console.Clear();
                Console.WriteLine("[Passo 3 de 3] Confirmação");
                Console.WriteLine($"Produto: {codigoProduto}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.WriteLine("Confirmar pedido? (s/n)");
                Console.WriteLine("(ou 'voltar' | 'cancelar')");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    CancelarPedido();
                    return;
                }

                if (entrada == "voltar")
                {
                    passo = 2;
                    break;
                }

                if (entrada == "s")
                {
                    Console.WriteLine("Pedido realizado com sucesso!");
                    Pausa();
                    return;
                }
                else if (entrada == "n")
                {
                    Console.WriteLine("Pedido não confirmado. Voltando...");
                    Pausa();
                    passo = 2;
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite 's' ou 'n'.");
                    Pausa();
                }
            }
        }
    }

    static void CancelarPedido()
    {
        Console.WriteLine("Pedido cancelado.");
        Console.ReadKey();
    }

    static void Pausa()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
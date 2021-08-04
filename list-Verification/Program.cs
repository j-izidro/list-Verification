using System;
using System.Linq;
using System.Collections.Generic;


public class program //teste commit git jéssica
{
    public enum OpcionaisCarro // crio os opcionais do carro
    {
        sair = 0,
        ar = 1,
        vidroEletrico = 2,
        direcao = 3, //basic - até 3
        travaEletrica = 4,
        faroldeNeblina = 5, //urban - até 5
        câmbioAutomatico = 6,
        bancodeCouro = 7, //confort - até 7
        tetoSolar = 8,
        pilotoAutomatico = 9,
        blindagem = 10 //luxury - todos
    }

    public enum Kits
    {
        personalisado = 0,
        basico = 3, //1 2 3
        urban = 5, //1 2 3 4 5
        confort = 7, //1 2 3 4 5 6 7
        luxury = 10 //todos
    }

    /*
     Comparo o que o usuário escolheu com os kits que tenho
     */
    public static void MostrarKitEscolhido(List<int> opcionaisEscolhidos)
    {
        List<int> ordemKit = new List<int>(); //crio a lista que vai representar o meu kit (seja ele qual for)
        Kits kit; //crio o enumerável que será mostrado na tela

        for (int i = 0; i < opcionaisEscolhidos.Count(); i++) //adiciono os números progressivamente baseado na quantidade de itens escolhidos pelo usuário.
            ordemKit.Add(i + 1); // 1º = 1, assim respectivamente

        var comparacao = opcionaisEscolhidos.Except(ordemKit); //comparo as duas listas excluindo o ordemKit de dentro da lista de itens escolhidos pelo usuário 

        if (comparacao.Count() == 0) // se não sobrou nada na variável 'comparação' significa que o usuário escolheu um kit fechado (seja ele qual for)
            kit = (Kits)opcionaisEscolhidos.Count(); //preencho a variável kit baseado na quantidade de itens escolhidos pelo usuário (POIS JÁ SEI QUE ELE ESCOLHEU UM KIT FECHADO)
        else
            kit = Kits.personalisado; //se sobrou algo dentro da variável 'comparação' significa que o kit SÓ PODE SER personalisado.

        Console.WriteLine("você escolheu o kit: "+kit);
    } 
    public static void Main()
    {

        var opcionais = Enum.GetValues(typeof(OpcionaisCarro)); //pego os valores (do tipo enum) dos opcionais

        Console.WriteLine("Você entrou no programa de escolha de carros. Os Opcionais disponíveis são:");

        foreach (var item in opcionais) // varro a lista de opcionais pra mostrar na tela
        {
            if (item.ToString() != "sair") // verifico se é a opção sair, se não for, eu escrevo
                Console.WriteLine(Convert.ToInt32(item) + " " + item); // printo todos os opcionais na tela
        }

        Console.WriteLine("escreva o númmero do opcional que você quer colocar no seu carro, e/ou 0 pra sair");
        List<int> opcionaisEscolhidos = new List<int>(); // crio a variável que reserva as escolhas do usuário

        for (int i = 1; i <= 10; i++) //loop de 10 vezes para pegar as opções do usuário
        {
            Console.WriteLine("digite o valor do " + i + " opcional:");
            string opcional = Console.ReadLine(); //armazeno a opção do usuário

            if (opcional != "0") // verifico se o opcional é diferente de zero, se sim, eu continuo o fluxo
            {
                if (Convert.ToInt32(opcional) <= 10) //verifico se é menor ou igual a 10, se sim, continuo
                {
                    opcionaisEscolhidos.Add(Convert.ToInt32(opcional)); // adiciono a opção escolhida na minha lista de opções
                }
                else // se não, aviso que o opcional é inexistente
                {
                    Console.WriteLine("opcional é inexistente");
                }
            }
            else
            {
                Console.WriteLine("você saiu do programa");
                break;
            }
        }
        MostrarKitEscolhido(opcionaisEscolhidos);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_aeroporto
{
    public class Voo
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public DateTime DataHora { get; set; }
    }

    public class Passageiro
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public Voo Nvoo { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Insere cada destino
            Voo destino1 = new Voo()
            {
                Id = 001,
                Destino = "SÃO PAULO",
                DataHora = Convert.ToDateTime("13:50")
            };
            Voo destino2 = new Voo()
            {
                Id = 002,
                Destino = "RECIFE",
                DataHora = Convert.ToDateTime("20:00")
            };
            Voo destino3 = new Voo()
            {
                Id = 003,
                Destino = "RIO DE JANEIRO",
                DataHora = Convert.ToDateTime("21:00")
            };
            //Cria uma lista com os voos
            List<Voo> voos = new List<Voo>();
            voos.Add(destino1);
            voos.Add(destino2);
            voos.Add(destino3);

            int posição;
            Queue fila = new Queue();
            List<Passageiro> listaPassageiro = new List<Passageiro>();

            Passageiro passageiro = new Passageiro();

            //Cria passageiros pré-definidos para não ter que cadastrar varios de uma vez, ao abrir o programa
            Passageiro fake1 = new Passageiro()
            {
                Nome = "MARY KENNETH KELLER",
                CPF = "12345678910",
                Telefone = "31900000000",
                Nvoo = destino1
            };

            Passageiro fake2 = new Passageiro()
            {
                Nome = "ADA AUGUSTA KING LOVELACE",
                CPF = "12345678911",
                Telefone = "31900000001",
                Nvoo = destino2
            };

            Passageiro fake3 = new Passageiro()
            {
                Nome = "JEAN SAMMET",
                CPF = "12345678912",
                Telefone = "31900000002",
                Nvoo = destino3
            };

            Passageiro fake4 = new Passageiro()
            {
                Nome = "GRACE HOPPER",
                CPF = "12345678913",
                Telefone = "31900000003",
                Nvoo = destino1
            };

            Passageiro fake5 = new Passageiro()
            {
                Nome = "MAGDALENA CARMEN FRIDA KAHLO",
                CPF = "12345678914",
                Telefone = "31900000004",
                Nvoo = destino1
            };

            //adciona os usuarios a lista e fila
            listaPassageiro.Add(fake1);
            listaPassageiro.Add(fake2);
            listaPassageiro.Add(fake3);
            listaPassageiro.Add(fake4);
            listaPassageiro.Add(fake5);
            fila.Enqueue(fake1);
            fila.Enqueue(fake2);
            fila.Enqueue(fake3);
            fila.Enqueue(fake4);
            fila.Enqueue(fake5);

            bool sair = false;
            do
            {
                string pDestino = "";
                DateTime aux;
                for (int i = 0; i < voos.Count; i++)//define qual é o proximo voo
                {
                    pDestino = destino1.Destino;
                    aux = destino1.DataHora;
                    if (aux > destino2.DataHora)
                    {
                        pDestino = destino2.Destino;
                    }
                    else if (aux > destino3.DataHora)
                    {
                        pDestino = destino3.Destino;
                    }
                }

                Console.WriteLine();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n" +
                    "\t░░░░░░ AEROPORTO INTERNACIONAL STAR ALLIANCE ░░░░░░");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n" +
                    "\t╔══════════════════════════════ MENU PRINCIPAL ═══╗");
                Console.WriteLine(
                    "\t║  [F1] LISTA DE PASSAGEIROS                      ║\n" +
                    "\t║  [F2] PESQUISAR PASSAGEIROS POR NÚMERO DE CPF   ║\n" +
                    "\t║  [F3] CADASTRAR PASSAGEIRO                      ║\n" +
                    "\t║  [F4] EXCLUIR PASSAGEIRO                        ║\n" +
                    "\t║  [F5] FILA DE ESPERA                            ║\n" +
                    "\t║ [ESC] SAIR                                      ║", pDestino);
                Console.WriteLine("" +
                    "\t╚═════════════════════════════════════════════════╝");
                Console.ResetColor();
                ConsoleKeyInfo Menu = Console.ReadKey();
                sair = Menu.Key == ConsoleKey.Escape;

                if (Menu.Key == ConsoleKey.F1)//verifica todos os passageiros na fila
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t▒▒▒▒▒▒▒▒▒▒▒▒▒ LISTAGEM DE PASSAGEIROS ▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.ResetColor();
                    
                    for (int i = 0; i < fila.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\n" +
                            "\n\t¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯\n" +
                            "\tNOME DO PASSAGEIRO: {0} \n" +
                            "\tCPF DO PASSAGEIRO: {1} \n" +
                            "\tNÚMERO DO VÔO: {2} \n" +
                            "\tDESTINO DO VÔO: {3} \n" +
                            "\tTELEFONE: {4} \n" +
                            "\tHORÁRIO DE SAÍDA: {5} \n",
                            listaPassageiro[i].Nome, listaPassageiro[i].CPF, listaPassageiro[i].Nvoo.Id, listaPassageiro[i].Nvoo.Destino,
                            listaPassageiro[i].Telefone, listaPassageiro[i].Nvoo.DataHora.TimeOfDay);
                        Console.ResetColor();

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n\t» PRESSIONE [ESC] PARA RETORNAR AO MENU PRINCIPAL");

                    Console.ReadKey();
                    Console.Clear();
                }

                else if (Menu.Key == ConsoleKey.F2)//pesquisa passageiro expecifico
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t▒▒▒▒▒ PESQUISAR PASSAGEIROS POR NÚMERO DE CPF ▒▒▒▒▒");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\tINSIRA O CPF DO PASSAGEIRO: ");
                    Console.ResetColor();
                    Console.Write("\t");

                    string CPF = Console.ReadLine();
                    for (int i = 0; i < listaPassageiro.Count && i < 5; i++)
                    {
                        if (CPF == listaPassageiro[i].CPF)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\t\n" +
                            "\tNOME DO PASSAGEIRO: {0} \n" +
                            "\tCPF DO PASSAGEIRO: {1} \n" +
                            "\tNÚMERO DO VÔO: {2} \n" +
                            "\tDESTINO DO VÔO: {3} \n" +
                            "\tTELEFONE: {4} \n" +
                            "\tHORÁRIO DE SAÍDA: {5} \n",
                            listaPassageiro[i].Nome, listaPassageiro[i].CPF, listaPassageiro[i].Nvoo.Id, listaPassageiro[i].Nvoo.Destino,
                            listaPassageiro[i].Telefone, listaPassageiro[i].Nvoo.DataHora.TimeOfDay);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\n\t» PRESSIONE [ESC] PARA RETORNAR AO MENU PRINCIPAL");
                    Console.ResetColor();

                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Menu.Key == ConsoleKey.F3)//cadastra um passageiro
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t▒▒▒▒▒▒▒▒▒▒▒▒ CADASTRAR NOVO PASSAGEIRO ▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.ResetColor();

                    bool retornar = false;
                    do
                    {
                        Passageiro passageiroCadastro = new Passageiro();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tNOME DO PASSAGEIRO: ");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiroCadastro.Nome = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tCPF DO PASSAGEIRO: ");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiroCadastro.CPF = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tINSIRA A UF DO DESTINO(RJ, SP OU RE): ");
                        Console.ResetColor();
                        Console.Write("\t");
                        string Nvoo = Console.ReadLine();

                        if (Nvoo == "SP")
                        {
                            passageiroCadastro.Nvoo = destino1;
                        }
                        else if (Nvoo == "RE")
                        {
                            passageiroCadastro.Nvoo = destino2;
                        }
                        else if (Nvoo == "RJ")
                        {
                            passageiroCadastro.Nvoo = destino3;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tNÚMERO DE TELEFONE (INSIRA APENAS NÚMEROS): ");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Telefone = Console.ReadLine();

                        listaPassageiro.Add(passageiroCadastro);
                        fila.Enqueue(passageiroCadastro);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\n\tPRESSIONE [ENTER] PARA CONFIRMAR.");
                        Console.ReadLine();
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\tPASSAGEIRO CADASTRADO COM SUCESSO!\n");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t» PRESSIONE [ESC] PARA RETORNAR AO MENU PRINCIPAL");
                        Console.WriteLine("\t» PRESSIONE [ENTER] PARA CADASTRAR UM NOVO PASSAGEIRO");
                        Console.ResetColor();

                        var finalizar = Console.ReadKey();
                        retornar = finalizar.Key == ConsoleKey.Escape;
                        Console.WriteLine();
                        Console.Clear();

                    } while (!retornar);
                }
                else if (Menu.Key == ConsoleKey.F4)//remove passageiro da fila
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t▒▒▒▒▒▒▒▒▒▒▒ EXCLUIR PASSAGEIRO DA LISTA ▒▒▒▒▒▒▒▒▒▒▒");
                    Console.ResetColor();

                    fila.Dequeue();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\tPRESSIONE [ENTER] PARA EXCLUIR O ULTIMO PASSAGEIRO CADASTRADO");

                    Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tPASSAGEIRO REMOVIDO COM SUCESSO\n");
                    Console.Write("\t");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t» PRESSIONE [ESC] PARA RETORNAR AO MENU PRINCIPAL");
                    Console.ResetColor();
                    
                    Console.ReadKey();
                    Console.Clear();
                }
                
                else if (Menu.Key == ConsoleKey.F5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ LISTA DE ESPERA ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.ResetColor();

                    posição = 6;
                    for (int i = 0; i > 5 && i < fila.Count; i++)//mostra lista de espera
                    {
                        Console.WriteLine("\n" + posição +
                            "°: " + "NOME DO PASSAGEIRO: {0} " +
                            "CPF DO PASSAGEIRO: {1} " +
                            "NÚMERO DO VÔO: {2} " +
                            "DESTINO: {3} " +
                            "TELEFONE: {4} " +
                            "HORÁRIO DE SAÍDA: {5}",
                            listaPassageiro[i].Nome, listaPassageiro[i].CPF, listaPassageiro[i].Nvoo.Id, listaPassageiro[i].Nvoo.Destino, listaPassageiro[i].Telefone, listaPassageiro[i].Nvoo.DataHora.TimeOfDay);
                        posição++;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t» PRESSIONE [ESC] PARA RETORNAR AO MENU PRINCIPAL");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!sair);
        }
        
    }
}

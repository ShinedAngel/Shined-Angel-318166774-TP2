using System;
using System.Collections.Generic;

namespace tpAero
{
    class Program
    {
        public class Passageiro
        {
            public string Nome { get; set; }
            public int Voo { get; set; }
            public int Passagem { get; set; }
            public long CPF { get; set; }
            public long Telefone { get; set; }
            public TimeSpan Horario { get; set; }
        }

        static void Main(string[] args)
        {
            List<Passageiro> lista = new List<Passageiro>();
            Passageiro passageiro = new Passageiro();
            bool sair = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tAEROPORTO INTERNACIONAL STAR ALLIANCE");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n\t╔══════════════════════════════ MENU PRINCIPAL ═══╗");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(
                    "\t║  [F1] Lista de passageiros                      ║\n" + "\t║  [F2] Pesquisar passageiros por número de CPF   ║\n" + "\t║  [F3] Cadastrar novo passageiro                 ║\n" +
                    "\t║  [F4] Excluir passageiro da lista               ║\n" + "\t║  [F5] Mostra fila de espera                     ║\n" + "\t║  [ESC] Sair                                     ║");
                Console.WriteLine("\t╚═════════════════════════════════════════════════╝");
                Console.ResetColor();

                ConsoleKeyInfo Menu = Console.ReadKey();
                sair = Menu.Key == ConsoleKey.Escape;

                if (Menu.Key == ConsoleKey.F1)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ LISTAGEM DE PASSAGEIROS ▒▒▒▒▒▒");
                    Console.ResetColor();

                    int posição = 1;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        Console.WriteLine(posição + "°: " + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: {2} " +
                            "Numero da Passagem: {3} " +
                            "Telefone: {3} " +
                            "Horario: {4}",
                            lista[i].Nome, lista[i].CPF, lista[i].Voo, lista[i].Passagem, lista[i].Telefone, lista[i].Horario);
                        posição++;
                        Console.WriteLine();
                    }
                }

                else if (Menu.Key == ConsoleKey.F2)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ PESQUISAR PASSAGEIROS POR NÚMERO DE CPF ▒▒▒▒▒▒");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\n\tNÚMERO DO CPF: ");
                    Console.ResetColor();

                    Console.Write("\t");
                    long pCPF = Convert.ToInt64(Console.ReadLine());
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (pCPF == passageiro.CPF)
                        {
                            Console.WriteLine("NOME: {0} " +
                                "CPF: {1} " +
                                "NÚMERO DO VÔO: {2} " +
                                "NÚMERO DA PASSAGEM: {3} " +
                                "TELEFONE: {3} " +
                                "HORÁRIO: {4}",
                                lista[i].Nome, lista[i].CPF, lista[i].Voo, lista[i].Passagem, lista[i].Telefone, lista[i].Horario);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Passageiro não localizado na base de dados");
                            Console.ResetColor();
                        }
                    }
                }

                else if (Menu.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    bool voltar = false;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ CADASTRAR NOVO PASSAGEIRO ▒▒▒▒▒▒");
                    Console.ResetColor();

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tNOME DO PASSAGEIRO:");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Nome = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tCPF DO PASSAGEIRO:");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.CPF = Convert.ToInt64(Console.ReadLine());


                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tNUMERAÇÃO DO VÔO:");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Voo = Int32.Parse(Console.ReadLine());


                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tNUMERAÇÃO DA PASSAGEM:");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Passagem = Int32.Parse(Console.ReadLine());


                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tNÚMERO DE TELEFONE (INSIRA APENAS NÚMEROS):");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Telefone = Convert.ToInt64(Console.ReadLine());


                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tHORÁRIO DO VÔO:");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Horario = TimeSpan.Parse(Console.ReadLine());

                        lista.Add(passageiro);
                        /*
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                Console.WriteLine("\t\t\n\n[F6] MENU PRINCIPAL");
                                                Console.ResetColor();

                                                var end = Console.ReadKey();
                                                voltar = end.Key == ConsoleKey.F6;

                                            */
                    } while (voltar); 
                }











                else if (Menu.Key == ConsoleKey.F4)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ EXCLUIR PASSAGEIRO DA LISTA ▒▒▒▒▒▒");
                    Console.ResetColor();
                }

                else if (Menu.Key == ConsoleKey.F5)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ LISTA DE ESPERA ▒▒▒▒▒▒");
                    Console.ResetColor();
                }

            } while (sair);

            
        }
    }
}
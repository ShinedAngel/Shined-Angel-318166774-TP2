using System;
using System.Collections;
using System.Collections.Generic;

namespace aero
{
    public class Passageiro
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public Voo numerovoo { get; set; }
    }

    public class Voo
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public DateTime Hora { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Voo mg = new Voo()
            {
                Id = 01,
                Destino = "Minas Gerais",
                Hora = Convert.ToDateTime("11:10")
            };
            Voo sp = new Voo()
            {
                Id = 02,
                Destino = "São Paulo",
                Hora = Convert.ToDateTime("16:20")
            };
            Voo rs = new Voo()
            {
                Id = 03,
                Destino = "Rio Grande do Sul",
                Hora = Convert.ToDateTime("20:20")
            };

            List<Voo> voos = new List<Voo>();
            voos.Add(mg);
            voos.Add(sp);
            voos.Add(rs);

            int posicao;
            Queue espera = new Queue();
            List<Passageiro> listaPassageiro = new List<Passageiro>();

            Passageiro passageiro = new Passageiro();

            Passageiro porta1 = new Passageiro()
            {
                Nome = "Lucas Carlos Montanhês",
                CPF = "12345678910",
                Telefone = "31995689781",
                numerovoo = mg
            };
            Passageiro porta2 = new Passageiro()
            {
                Nome = "Luciana Madalena Katia",
                CPF = "12345678911",
                Telefone = "11989546598",
                numerovoo = rs
            };
            Passageiro porta3 = new Passageiro()
            {
                Nome = "Camila Luciana da Silva",
                CPF = "12345678912",
                Telefone = "62985478521",
                numerovoo = sp
            };
            Passageiro porta4 = new Passageiro()
            {
                Nome = "Thiago Oliveira Claudio",
                CPF = "65487915945",
                Telefone = "64998755484",
                numerovoo = mg
            };

            listaPassageiro.Add(porta1);
            listaPassageiro.Add(porta2);
            listaPassageiro.Add(porta3);
            listaPassageiro.Add(porta4);

            //Enqueue é usado para enfileirar as strings
            espera.Enqueue(porta1);
            espera.Enqueue(porta2);
            espera.Enqueue(porta3);
            espera.Enqueue(porta4);

            bool sair = false;
            do
            {
                string Destino = "";
                DateTime aux;
                for (int i = 0; i < voos.Count; i++)
                {
                    Destino = mg.Destino;
                    aux = mg.Hora;

                    if (aux > sp.Hora)
                    {
                        Destino = sp.Destino;
                    }
                    else if (aux > rs.Hora)
                    {
                        Destino = rs.Destino;
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tAEROPORTO INTERNACIONAL STAR ALLIANCE");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n" +
                    "\t╔══════════════════════════════ MENU PRINCIPAL ═══╗");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(
                    "\t║  [F1] Lista de passageiros                      ║\n" +
                    "\t║  [F2] Pesquisar passageiros por número de CPF   ║\n" +
                    "\t║  [F3] Cadastrar novo passageiro                 ║\n" +
                    "\t║  [F4] Excluir passageiro da lista               ║\n" +
                    "\t║  [F5] Mostra fila de espera                     ║\n" +
                    "\t║ [ESC] Sair                                      ║", Destino);
                Console.WriteLine("" +
                    "\t╚═════════════════════════════════════════════════╝");
                Console.ResetColor();

                ConsoleKeyInfo menu = Console.ReadKey();
                sair = menu.Key == ConsoleKey.Escape;

                if (menu.Key == ConsoleKey.F1)//verifica todos os passageiros na fila
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ LISTAGEM DE PASSAGEIROS ▒▒▒▒▒▒");
                    Console.ResetColor();

                    posicao = 1;
                    for (int i = 0; i < espera.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\t\n" +
                            "\t" + posicao +
                            "° PASSAGEIRO: \n" + "\tNome: {0} \n" +
                            "\tCPF: {1} \n" +
                            "\tNumero do Voo: {2} \n" +
                            "\tDestino: {3} \n" +
                            "\tTelefone: {4} \n" +
                            "\tHorario: {5} \n",
                            listaPassageiro[i].Nome, listaPassageiro[i].CPF, listaPassageiro[i].numerovoo.Id, listaPassageiro[i].numerovoo.Destino,
                            listaPassageiro[i].Telefone, listaPassageiro[i].numerovoo.Hora.TimeOfDay);
                        posicao++;
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                }
                else if (menu.Key == ConsoleKey.F2)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ PESQUISAR PASSAGEIROS POR NÚMERO DE CPF ▒▒▒▒▒▒");
                    Console.ResetColor();

                    Console.Write("\t");
                    string CPF = Console.ReadLine();
                    for (int i = 0; i < listaPassageiro.Count && i < 5; i++)
                    {
                        if (CPF == listaPassageiro[i].CPF)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n" +
                            "\n\tNome: {0} " +
                            "\n\tCPF: {1} " +
                            "\n\tNumero do Voo: {2} " +
                            "\n\tDestino: {3} " +
                            "\n\tTelefone: {4} " +
                            "\n\tHorario: {5}",
                            listaPassageiro[i].Nome, listaPassageiro[i].CPF, listaPassageiro[i].numerovoo.Id, listaPassageiro[i].numerovoo.Destino,
                            listaPassageiro[i].Telefone, listaPassageiro[i].numerovoo.Hora.TimeOfDay);
                            Console.WriteLine();
                            Console.ResetColor();
                        }
                    }
                }
                else if (menu.Key == ConsoleKey.F3)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ CADASTRAR NOVO PASSAGEIRO ▒▒▒▒▒▒");
                    Console.ResetColor();

                    do
                    {
                        Passageiro cadastrado = new Passageiro();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tNOME DO PASSAGEIRO: ");
                        Console.ResetColor();
                        Console.Write("\t");
                        cadastrado.Nome = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tCPF DO PASSAGEIRO: ");
                        Console.ResetColor();
                        Console.Write("\t");
                        cadastrado.CPF = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tUF DE DESTINO DO VÔO: ");
                        Console.ResetColor();
                        Console.Write("\t");
                        string numerovoo = Console.ReadLine();

                        if (numerovoo == "MG")
                        {
                            cadastrado.numerovoo = mg;
                        }
                        else if (numerovoo == "SP")
                        {
                            cadastrado.numerovoo = sp;
                        }
                        else if (numerovoo == "RS")
                        {
                            cadastrado.numerovoo = rs;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n\tNÚMERO DE TELEFONE (INSIRA APENAS NÚMEROS): ");
                        Console.ResetColor();
                        Console.Write("\t");
                        passageiro.Telefone = Console.ReadLine();

                        listaPassageiro.Add(cadastrado);
                        espera.Enqueue(cadastrado);

                        Console.WriteLine("\n\tPRESSIONE [ENTER] PARA CADASTRAR O PASSAGEIRO");
                        Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\tPASSAGEIRO CADASTRADO COM SUCESSO.");
                        Console.ResetColor();

                        Console.ReadLine();

                        ConsoleKey voltar = ConsoleKey.Enter;
                        voltar = Console.ReadKey().Key;

                    } while(sair);
                }

                else if (menu.Key == ConsoleKey.F4)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ EXCLUIR PASSAGEIRO DA LISTA ▒▒▒▒▒▒");

                    //O código Dequeue é usado para desenfileirar
                    espera.Dequeue();
                    Console.WriteLine("\n\tINFORME O CPF DO PASSAGEIRO A SER REMOVIDO: ");
                    Console.ResetColor();
                    Console.Write("\t");
                    Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n\tPASSAGEIRO REMOVIDO COM SUCESSO.\n");
                    Console.ResetColor();
                }
                else if (menu.Key == ConsoleKey.F5)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\t▒▒▒▒▒▒ LISTA DE ESPERA ▒▒▒▒▒▒");

                    posicao = 6;
                    for (int i = 0; i > 5 && i < espera.Count; i++)
                    {
                        Console.WriteLine("\n" + posicao +
                            "°: " + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: {2} " +
                            "Destino: {3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                            listaPassageiro[i].Nome, listaPassageiro[i].CPF, listaPassageiro[i].numerovoo.Id, listaPassageiro[i].numerovoo.Destino,
                            listaPassageiro[i].Telefone, listaPassageiro[i].numerovoo.Hora.TimeOfDay);
                        posicao++;
                        Console.WriteLine();
                    }
                }
            } while (sair);
            Console.ReadKey();
        }
    }
}
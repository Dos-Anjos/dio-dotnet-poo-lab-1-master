using System;
using System.Collections.Generic;

// ultima mensagem utilizada Msg 019

namespace DIO.DosAnjos.Bank
{
	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						InserirConta();
						break;
					case "2":						
						ListarContas();
						break;
					case "3":
						Depositar();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Transferir();
						break;
                    case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Msg 001 - Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void InserirConta()
		{
			Console.WriteLine("  -----  Inserir nova conta  -----");

			Console.Write("Msg 002 - Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Msg 003 - Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Msg 004 - Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Msg 005 - Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}

		private static void ListarContas()
		{
			Console.WriteLine("  -----  Listar contas  -----  ");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Msg 006 - Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static void Depositar()
		{
			Console.WriteLine("  -----  Depósito  -----");

			Console.Write("Msg 007 - Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Msg 008 - Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			Console.WriteLine("  -----  Saque  -----");

			Console.Write("Msg 009 - Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Msg 010 - Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			Console.WriteLine("  -----  Transferência entre contas  -----");

			Console.Write("Msg 011 - Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Msg 012 - Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Msg 013 - Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("---  DIO Dos-Anjos Bank a seu dispor!!! ---");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Inserir nova conta");
			Console.WriteLine("2 - Listar contas");
			Console.WriteLine("3 - Depositar");
			Console.WriteLine("4 - Sacar");
			Console.WriteLine("5 - Transferir");
            Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}

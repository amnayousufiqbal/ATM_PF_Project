using System;
using System.IO;
namespace Atm
{
	class Program
	{
		public static string[] row;
		public static string name;
		public static string pin;
		public static string name1;
		public static string pin1;
		public static int option;
		public static void save()
		{
			string path = @"D:\Projectss\ATM(PF)\filee.txt";
			File.WriteAllLines(path, row);
		}
		static void Main(string[] args)

		{
			file();
			Login();
			menu();
			save();

		}
		public static void header()
		{
			Console.WriteLine(" ========================================================================================================================\n");
			Console.WriteLine("\t\t\t\t\t****** WELCOME TO ATM 24/7 SERVICE *****\n");
			Console.WriteLine("========================================================================================================================\n\n\n");
		}
		public static void file()
		{
			string path = @"D:\Projectss\ATM(PF)filee.txt";
			if (File.Exists(path) == false)
			{
				File.CreateText(path);
			}
			row = File.ReadAllLines(path);
		}

		public static void menu()
		{
			header();
			Console.WriteLine("\t\t\t\t\t\t WELCOME " + "'" + name + "'" + " To MAIN MENU");
			Console.WriteLine("\t\t\t\t\t\t``");
			Console.WriteLine("\n\t\t\t\t\t\t  Press 1 for Deposit     ");
			Console.WriteLine("\t\t\t\t\t\t  Press 2 for Withdrawl   ");
			Console.WriteLine("\t\t\t\t\t\t  Press 3 for PIN Change  ");
			Console.WriteLine("\t\t\t\t\t\t  Press 4 for Detail     ");
			Console.Write(" \n\t\t\t\t\t\t  Choice Option : ");

			int a = Convert.ToInt32(Console.ReadLine());
			switch (a)
			{
				case 1:
					deposit(name, pin);
					break;
				case 2:
					withdraw(name, pin);
					break;
				case 3:
					change_pin(name, pin);
					break;
				case 4:
					detail(name);
					break;
			}

		}
		public static void Login()
		{
			header();
			Console.Write("\t\t\t\t\t\tMention The Name : ");
			name = Console.ReadLine();
			Console.Write("\t\t\t\t\t --------------------------------------\n");
			Console.Write("\t\t\t\t\t\t Mention The Pin : ");
			pin = Console.ReadLine();
			Console.Write("\t\t\t\t\t      ---------------------------\n");

			for (int i = 0; i < row.Length; i++)
			{
				string[] column = row[i].Split('\t');

				for (int j = 0; j < column.Length; j++)
				{
					if (column[0] == name && column[1] == pin)
					{
						name1 = column[0];
						pin1 = column[1];
					}
				}
			}
			if (name == name1 && pin == pin1)
			{
				Console.WriteLine("\n\n\n\t\t\t\t\t\t ======================");
				Console.WriteLine("\t\t\t\t\t\t || Succesfull Login ||");
				Console.WriteLine("\t\t\t\t\t\t ======================");
				Console.WriteLine("\t\t\t\t\t\t ======================");

				Console.WriteLine("\t\t\t\t\t\t || Press Any Key To Continue||");

				Console.ReadKey();
				Console.Clear();
				menu();
			}
			else
			{
				Console.WriteLine("\n\n\n\t\t\t\t\t\t ==================");
				Console.WriteLine("\t\t\t\t\t\t || Invalid Login||");
				Console.WriteLine("\t\t\t\t\t\t ==================");
				Console.ReadKey();
				Console.Clear();
				Login();
			}

		}



		public static void deposit(string name, string pin)
		{
			Console.Clear();
			header();
			Console.Write("\t\t\t\t\t\tEnter Amount To Deposit : ");
			double deposit = double.Parse(Console.ReadLine());
			if (deposit == 0)
			{
				Console.WriteLine("\t\t\t\t\t\tDeposit Amount Can't Be 0(Zero)");
				Console.WriteLine("Press Any Key To Continue....");
				Console.ReadKey();
			}
			for (int i = 0; i < row.Length; i++)
			{
				string[] column = row[i].Split('\t');

				if (column[0] == name)
				{
					int amount = Convert.ToInt32(column[2]);
					double Total = amount + deposit;
					row[i] = column[0] + "\t" + column[1] + "\t" + Total + "\t" + column[3] + "\t" + column[4];
					Console.WriteLine("\n========================================================================================================================\n");
					Console.WriteLine("\n\t\t\t\t\tYour Account Balance Before Deposit is " + column[2] + " Pkr.");
					Console.WriteLine("\n\t\t\t\t\tYour Transcition Amount For Deposit is " + deposit + " Pkr.");
					Console.WriteLine("\n\t\t\t\t\tYour Account Balance After Deposit is " + Total + " Pkr.");
					Console.WriteLine("\n========================================================================================================================\n");
				}
			}
			Console.WriteLine("\n\n\t\t\t\t\t\t   Press 1 : Back To Menu");
			Console.WriteLine("\t\t\t\t\t\t   Press 2 : Back To Login");
			Console.Write("\n\t\t\t\t\t\t     Choose Option : ");
			option = int.Parse(Console.ReadLine());
			if (option == 1)
			{
				Console.Clear();
				save();
				menu();
			}
			else if (option == 2)
			{
				Console.Clear();
				save();
				Login();
			}

		}


		public static void withdraw(string name, string pin)
		{
			Console.Clear();
			header();
			Console.Write("\t\t\t\t\t\tEnter The Amount To Withdarw : ");
			double Withdraw = double.Parse(Console.ReadLine());
			for (int i = 0; i < row.Length; i++)
			{
				string[] column = row[i].Split('\t');
				if (column[0] == name)
				{
					int amount = Convert.ToInt32(column[2]);
					double Total = amount - Withdraw;
					row[i] = column[0] + "\t" + column[1] + "\t" + Total + "\t" + column[3] + "\t" + column[4];
					Console.WriteLine("\n========================================================================================================================\n");
					Console.WriteLine("\n\t\t\t\t\tYour Account Balance Before Withdraw is " + column[2] + " Pkr.");
					Console.WriteLine("\n\t\t\t\t\t Your Transcition Amount For Withdraw is " + Withdraw + " Pkr.");
					Console.WriteLine("\n\t\t\t\t\tYour Account Balance After Withdraw is " + Total + " Pkr.");
					Console.WriteLine("\n========================================================================================================================\n");
				}
			}
			Console.WriteLine("\n\n\t\t\t\t\t\t   Press 1 : Back To Menu");
			Console.WriteLine("\t\t\t\t\t\t   Press 2 : Back To Login");
			Console.Write("\n\t\t\t\t\t\t     Choose Option : ");
			option = int.Parse(Console.ReadLine());
			if (option == 1)
			{
				Console.Clear();
				save();
				menu();
			}
			else if (option == 2)
			{
				Console.Clear();
				save();
				Login();
			}

		}

		public static void detail(string name)
		{
			Console.Clear();
			header();
			for (int i = 0; i < row.Length; i++)
			{
				string[] cell = row[i].Split('\t');
				if (cell[0] == name)
				{
					Console.WriteLine("\t\t\t\t\t\t   " + " Name : " + cell[0] + "\n" + "\t\t\t\t\t\t   " + " PIN : " + cell[1] + "\n" + "\t\t\t\t\t\t   " + " Amount : " + cell[2] + "\n" + "\t\t\t\t\t\t   " + " Account No : " + cell[3] + "\n" + "\t\t\t\t\t\t   " + " Bank : " + cell[4]);
				}
			}
			Console.WriteLine("\n\n\t\t\t\t\t\t   Press 1 : Back To Menu");
			Console.WriteLine("\t\t\t\t\t\t   Press 2 : Back To Login");
			Console.Write("\n\t\t\t\t\t\t     Choose Option : ");
			option = int.Parse(Console.ReadLine());
			if (option == 1)
			{
				Console.Clear();
				save();
				menu();
			}
			else if (option == 2)
			{
				Console.Clear();
				save();
				Login();
			}

		}


		public static void change_pin(string name, string pin)
		{
			Console.Clear();
			header();

			Console.Write("\n\t\t\t\t\t\t  Write Your New Pin : ");
			string pin_new = Console.ReadLine();
			Console.Write("\n\t\t\t\t\t\tWrite New Pin To Confirm : ");
			string pin_new1 = Console.ReadLine();
			Console.WriteLine("\n========================================================================================================================");
			for (int i = 0; i < row.Length; i++)
			{
				string[] column = row[i].Split('\t');
				if (pin_new == pin_new1)
				{
					if (column[0] == name)
					{
						row[i] = column[0] + "\t" + pin_new + "\t" + column[2] + "\t" + column[3] + "\t" + column[4];
						Console.WriteLine("\n\t\t\t\t\t\t==============================");
						Console.WriteLine("\t\t\t\t\t\t| Old Pin Of Account Was " + pin + "|");
						Console.WriteLine("\t\t\t\t\t\t| New Pin Of Account is " + pin_new + " |");
						Console.WriteLine("\t\t\t\t\t\t==============================\n");
					}
				}
			}
			if (pin_new != pin_new1)
			{
				Console.WriteLine("\n\t\t\t\t\t\tPin Not Match , Try Again ");
			}
			Console.WriteLine("\n\n\t\t\t\t\t\t   Press 1 : Back To Menu");
			Console.WriteLine("\t\t\t\t\t\t   Press 2 : Back To Login");
			Console.Write("\n\t\t\t\t\t\t     Choose Option : ");
			option = int.Parse(Console.ReadLine());
			if (option == 1)
			{
				Console.Clear();
				save();
				menu();
			}
			else if (option == 2)
			{
				Console.Clear();
				save();
				Login();
			}
		}
	}
}
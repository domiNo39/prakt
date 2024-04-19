using System;

namespace xoba{
	public interface ITransaction{
		bool TransferStatus();
	}
	
	delegate void Transfer(string se, string recv, double sum);

	

	public class FinancialTransaction : ITransaction{
		public string sender{ get; set; }
		public string reciever{ get; set; }
		public double sum{ get; set; }
		public FinancialTransaction(string se, string recv, double su){
			sender = se;
			reciever = recv;
			sum = su;
		}

		public FinancialTransaction(){
			sender = "unknown";
			reciever = "unknown";
			sum = 0.0;
		}

		~FinancialTransaction(){
			Console.WriteLine("BURNING THE MONEY!!!");
		}

		public bool TransferStatus(){
			if(sum >= 0){
				return true;
			}
			else{
				return false;
			}
		}

		public void TransferMoney(string se, string recv, double su){
			Console.WriteLine($"Transfering {su} from {se} to {recv}");
		}


		public override string ToString(){
			return $"---FinancialTransaction---\nsum: {sum}\nsender: {sender}\nReciever: {reciever}\n\n";
		}
		public static void Perform(Transfer operation, string se, string recv, double su){
			operation(se, recv, su);

		}
	}

	public class SomethingTransaction : FinancialTransaction, ITransaction{
		public string someField{ get; set; }
		public SomethingTransaction(string se, string recv, double su, string something) : base(se, recv, su){
			someField = something;
		}

		public SomethingTransaction() : base(){
			someField = "sample text";
		}

		~SomethingTransaction(){
			Console.WriteLine("BURNING SOMETHING MONEY!!!");
		}
		public bool Transferstatus(){
			if((sum > 0) && (someField != "sample text")){
				return true;
			}
			else{
				return false;
			}
		}

		public void transferMoney(string se, string recv, double su){
			Console.WriteLine($"Transfering {su} from {se} to {recv}");
		}

		public override string ToString(){
			return $"---SomethingTransaction---\nsum: {sum}\nsender: {sender}\nReciever: {reciever}\nsomeField: {someField}\n\n";
		}
		public static void perform(Transfer operation, string se, string recv, double su){
			operation(se, recv, su);
		}
	}
	class Program{
		static void Main(){
			Console.WriteLine("blyo");
			Console.WriteLine(" ");
			FinancialTransaction test = new FinancialTransaction();
			Console.WriteLine(test.ToString());
			SomethingTransaction test2 = new SomethingTransaction();
			Console.WriteLine(test2.ToString());
			test.Perform(test.TransferMoney, "Andrew", "PesPatron", 255.0);
			test2.perform(test2.transferMoney, "chupakabra", "Andrew", 240.0);	
		}

	}

}

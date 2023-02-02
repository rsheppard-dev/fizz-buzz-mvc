using System;
namespace fizz_buzz_mvc.Models
{
	public class FizzBuzz
	{
		public int StartValue { get; set; }
		public int EndValue { get; set; }
		public int FizzValue { get; set; }
		public int BuzzValue { get; set; }
		public List<string> Result { get; set; } = new();
	}
}


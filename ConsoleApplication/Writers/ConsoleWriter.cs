using System;

namespace ConsoleApplication.Writer
{
	public class ConsoleWriter : IWriter
	{
		public void Write(string message) => Console.WriteLine(message);
	}
}

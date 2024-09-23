using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace lab1{
    class Class1{

        static List<string> words = new List<string>();

        static void replaceToChar(char r){
			for (int i = 0; i < words.Count(); i++){
               StringBuilder builder = new StringBuilder(words[i]);
               for (int j = 0; j<words[i].Count(); j++){
					   if ((j+1)%2==0) builder[j] = r;
			   }
			   words[i] = builder.ToString();
			   Console.WriteLine(words[i]);
            }
        }


        static void Main(string[] args){
		    Console.WriteLine("Type a symbol parameter: ");
			char parametr = Convert.ToChar(Console.Read());
            try{
                FileStream file = new FileStream("input.txt", FileMode.Open);
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                    words.Add(sr.ReadLine());
				replaceToChar(parametr); 

				StreamWriter sw = new StreamWriter("output.txt");
				for (int i = 0; i<words.Count(); i++){
						sw.WriteLine(words[i]);
				}
				sw.Close();
            }
            catch(Exception e){
				Console.WriteLine("Exception: " + e.Message);
			}
        }
    }
}

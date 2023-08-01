// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
namespace example
{
    public class Helo
    {
        public static void Main(string[] args)
        {
            /* 
             /// write string reverse program
             string str = "divya";
             string reverse = "";
             for (int i = str.Length - 1; i >= 0; i--)
             {
                 reverse += str[i];
             }
             Console.WriteLine("original string is:" + str);
             Console.WriteLine("reverse string is:"+reverse);
            */

             string s = "hello world";
           // Console.WriteLine("enter string :");
            //string s = Console.ReadLine();
            int len = s.Length;
            int count = 0;
           // string x = s.Trim();
           for(int i=0; i < len ; i++)
            {
                if (s[i] =='' )
                {
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohamed_Haj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
           

            Console.WriteLine("Welcome to my game");
            Char[] lines = { '_', '_', '_', '_', };
            char[] ct = lines;
            printLines(lines);
            int hearts = getTodayWord().Length;
            int w = 0;
            int sh = 0;
            int ts = 0;
            string word = getTodayWord();
            int l = 1;
            Console.WriteLine("level" + l);
            int wt = 30;
            int wf = 50;
            while (hearts > 0)
            {
                
                char ch = AskUser();
                int result = checkLetter(word, ch, lines);
                if (result == -1)
                {
                    hearts--;
                    Console.WriteLine("You have {0} left!", hearts);
                }
                else
                {
                    if (0 <= result && result <= word.Length)
                    {
                        lines[result] = ch;
                        if(result != getTodayWord().Length-1)
                        {
                            for (int i = result + 1; i < word.Length; i++)
                            {
                                if (word[i] == lines[result])
                                {
                                    lines[i] = ch;
                                }
                            }
                        }                                                                       
                        printLines(lines);

                    }
                    
                }
                if (Checkw(word, lines) != 'f')
                {
                    w++;
                    word = getTodayWord();
                    sh = sh + hearts * 5;
                    l++;
                    Console.WriteLine("level" + l);
                    lines = ct;
                }


            }

            ts = w*20 + sh;
            if (w>=3)
            {
                ts = ts + wt;
            }

            if (w >= 5)
            {
                ts = ts + wf;
            }
            Console.WriteLine("you lost");

            Console.WriteLine("your score is {0}", ts);

        }
        public static char AskUser()
        {
            Console.WriteLine("please enter a char");
            Char a;
            a = char.Parse(Console.ReadLine());
            return a;
        }
        public static void printLines(char[] lines)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                Console.Write(lines[i] + " ");
            }
            Console.WriteLine();
        }
        public static string getTodayWord()
        {
            string[] arr = {"loop","food","team","home","zoom"};
            Random r = new Random();
            int rnd = r.Next(0, arr.Length);
            return arr[rnd];
        }
        public static int checkLetter(string todayWord, char a, char[] lines)
        {
            for(int i=0;i<4;i++)
            {
                if ( a == todayWord[i])
                {
                    return i;
                }

            }
            return -1;
            
        }
        public static char Checkw(string todaysword, char [] lines)
        {
            for(int i=0;i<todaysword.Length;i++)
            {
                if(lines [i] == '_')
                {
                    return 'f';
                }                                                              
            }
            return 't';
        }

    }
}

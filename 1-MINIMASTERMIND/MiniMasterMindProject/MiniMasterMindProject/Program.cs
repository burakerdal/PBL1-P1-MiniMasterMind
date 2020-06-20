using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMasterMindProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //human makes first guess

            int pcscore, humanscore, round,game, pcfirst, pcmove, humanmove, pcsecond, humanfirst, humansecond, fa, fb, absfb;
            pcfirst = 0; pcsecond = 0; humanfirst = 0; humansecond = 0;

            pcscore = 0; humanscore = 0; round = 0;

            Console.WriteLine("Press Enter to Start");
            Console.ReadLine();


            while (round < 10)
            {
                pcmove = 0; humanmove = 0;
                game = 0;
                game = game + 1;
                round = round + 1;
                Console.WriteLine("");
                Console.WriteLine("Round {0}", round);
                Console.WriteLine("Game {0}", game);
                Console.Write("I'm thinking my number.");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);

                Console.WriteLine("");

                Random rnd = new Random();
                pcfirst = rnd.Next(1, 4);

                pcsecond = rnd.Next(1, 4);
                while (pcsecond == pcfirst)
                {
                    pcsecond = rnd.Next(1, 4);
                }

                Console.WriteLine("I got my number.");
                Console.WriteLine("");


                Console.Write("Enter your first digit: ");
                humanfirst = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your second digit: ");
                humansecond = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Your number is " + humanfirst + humansecond);
                humanmove = humanmove + 1;

                //feedback process start
                fb = 0;
                if (pcfirst == humanfirst)
                {
                    fb = fb + 1;
                    if (pcsecond == humansecond)
                    {
                        fb = fb + 1;
                    }
                }
                else if (pcsecond == humansecond)
                {
                    fb = fb + 1;
                }

                else if (pcsecond == humanfirst)
                {
                    fb = fb - 1;

                    if (pcfirst == humansecond)
                    {
                        fb = fb - 1;
                    }
                }
                else if (pcfirst == humansecond)
                {
                    fb = fb - 1;
                }

                //feedback process end
                if (fb > 0)
                {
                    Console.WriteLine("My feedback is +" + fb + " , -0");
                    Console.WriteLine("");
                }
                if (fb < 0)
                {
                    Console.WriteLine("My feedback is +0, " + fb);
                    Console.WriteLine("");
                }

                while (fb != 2)
                {
                    Console.Write("Enter your first digit: ");
                    humanfirst = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter your second digit: ");
                    humansecond = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Your number is " + humanfirst + humansecond);
                    humanmove = humanmove + 1;


                    //feedback process START
                    fb = 0;
                    if (pcfirst == humanfirst)
                    {
                        fb = fb + 1;
                        if (pcsecond == humansecond)
                        {
                            fb = fb + 1;
                        }
                    }
                    else if (pcsecond == humansecond)
                    {
                        fb = fb + 1;
                    }

                    else if (pcsecond == humanfirst)
                    {
                        fb = fb - 1;

                        if (pcfirst == humansecond)
                        {
                            fb = fb - 1;
                        }
                    }
                    else if (pcfirst == humansecond)
                    {
                        fb = fb - 1;
                    }

                    //feedback process END
                    if (fb > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("My feedback is +" + fb + " , -0");
                    }
                    else if (fb < 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("My feedback is +0 , " + fb);
                    }
                }

                if (fb == 2)
                {
                    Console.Write("Correct!!!");
                    pcscore = pcscore + humanmove;
                    Console.ReadLine();
                }


                //second game start with computer guess

                Console.WriteLine("");
                game = game + 1;
                Console.WriteLine("Game {0}", game);
                Console.WriteLine("My time to guess, Choose your numbers.");
                Console.WriteLine("When you are ready.");
                Console.ReadLine();


                pcfirst = rnd.Next(1, 4);
                pcsecond = rnd.Next(1, 4);
                while (pcsecond == pcfirst)
                {
                    pcsecond = rnd.Next(1, 4);
                }




                Console.WriteLine("My first guess is " + pcfirst + pcsecond);
                pcmove = pcmove + 1;


                Console.Write("Enter your feedback: ");
                fb = Convert.ToInt16(Console.ReadLine());
                absfb = Math.Abs(fb);

                if (absfb == 2)
                {
                    if (fb > 0)
                    {
                        //+2 feedback
                        Console.WriteLine("Correct!");
                        humanscore = humanscore + pcmove;
                    }
                    else
                    {
                        //-2 feedback
                        Console.WriteLine("My second guess is " + pcsecond + pcfirst);
                        pcmove = pcmove + 1;
                        Console.Write("Enter your feedback: ");

                        fb = Convert.ToInt16(Console.ReadLine());

                        if (fb == 2)
                        {
                            Console.WriteLine("Correct!");
                            humanscore = humanscore + pcmove;
                        }
                        else
                        {
                            Console.WriteLine("Yalancısın yalanın batsın!");
                            pcscore = pcscore + 5;
                        }
                    }


                }

                else
                {
                    if (fb > 0)
                    {
                        //+1 feedback
                        pcfirst = (6 - (pcfirst + pcsecond));
                        Console.WriteLine("My second guess is " + pcfirst + pcsecond);
                        pcmove = pcmove + 1;

                        Console.Write("Enter your feedback: ");
                        fb = Convert.ToInt16(Console.ReadLine());

                        if (fb > 0)
                        //+2 feedback 
                        {
                            Console.WriteLine("Correct!");
                            humanscore = humanscore + pcmove;
                        }
                        else
                        //-1 feedback
                        {
                            pcfirst = (6 - (pcfirst + pcsecond));
                            pcsecond = (6 - (pcfirst + pcsecond));

                            Console.WriteLine("My last guess is " + pcfirst + pcsecond);
                            pcmove = pcmove + 1;
                            // find the correct number at this point
                            Console.Write("Enter your feedback: ");

                            fb = Convert.ToInt16(Console.ReadLine());

                            if (fb == 2)
                            {
                                Console.WriteLine("Correct!");
                                humanscore = humanscore + pcmove;
                            }
                            else
                            {
                                Console.WriteLine("Yalancısın yalanın batsın!");
                                pcscore = pcscore + 5;
                            }
                        }

                    }
                    else
                    {
                        pcfirst = (6 - (pcfirst + pcsecond));
                        Console.WriteLine("My second guess is " + pcfirst + pcsecond);
                        pcmove = pcmove + 1;

                        Console.Write("Enter your feedback: ");
                        fb = Convert.ToInt16(Console.ReadLine());

                        if (fb > 0)
                        {
                            //+1 feedback 
                            pcsecond = (6 - (pcfirst + pcsecond));
                            Console.WriteLine("My last guess is " + pcfirst + pcsecond);

                            Console.Write("Enter your feedback: ");
                            fb = Convert.ToInt16(Console.ReadLine());
                            pcmove = pcmove + 1;

                            if (fb == 2)
                            {
                                Console.WriteLine("Correct!");
                                humanscore = humanscore + pcmove;
                            }
                            else
                            {
                                Console.WriteLine("Yalancısın yalanın batsın!");
                                pcscore = pcscore + 5;
                            }
                        }
                        else
                        //-2 feedback 
                        {
                            Console.WriteLine("My second guess is " + pcsecond + pcfirst);
                            pcmove = pcmove + 1;
                            Console.Write("Enter your feedback: ");

                            fb = Convert.ToInt16(Console.ReadLine());

                            if (fb == 2)
                            {
                                Console.WriteLine("Correct!");
                                humanscore = humanscore + pcmove;
                            }
                            else
                            {
                                Console.WriteLine("Yalancısın yalanın batsın!");
                                pcscore = pcscore + 5;
                            }

                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Pc Score: " + pcscore);
                Console.WriteLine("Human Score: " + humanscore);
                Console.ReadLine();

            }
            Console.WriteLine("");

            Console.WriteLine("Pc Score: " + pcscore);
            Console.WriteLine("Human Score: " + humanscore);

            if (pcscore > humanscore)
                Console.WriteLine("I WON. DEAL WITH IT ;)");
            else if (humanscore > pcscore)
            {
                Console.WriteLine("You won. Interesting");
            }
            else
                Console.WriteLine("Tie?");
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();




        }
    }
}

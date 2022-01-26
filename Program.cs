using System;
using System.Collections.Generic;
using System.Threading;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            float xchange = 0;
            float ychange = 0;
            bool run = true;
            List<float> xsnakecords = new List<float>();
            List<float> ysnakecords = new List<float>();
            List<float> snakecordscombined = new List<float>();

            ConsoleKeyInfo command;
            xsnakecords.Add(6);
            ysnakecords.Add(6);
            xsnakecords.Add(7);
            ysnakecords.Add(7);
            xsnakecords.Add(8);
            ysnakecords.Add(8);
            snakecordscombined.Add(66);
            snakecordscombined.Add(77);
            snakecordscombined.Add(88);


            float xdeltacord;
            float ydeltacord;

            float deltax;
            float deltay;
            int printcordx;
            int printcordy;
            int cordcount;
            int applex = 9;
            int appley = 5;
            string snakepart = "[]";
            bool print = true;
            bool spawned = true;
            bool extend = false;
            Random rnd = new Random();
            int points = 0;
            float snakecordcombined = 0;
            int firstitt = 0;
            bool goodcord = false;
            int applecordscombined = 0;
            void respawn()
            {
                firstitt = 0;
                print = true;
                Console.Clear();
                xsnakecords.Clear();
                ysnakecords.Clear();
                snakecordscombined.Clear();
                xsnakecords.Add(6);
                ysnakecords.Add(6);
                xsnakecords.Add(7);
                ysnakecords.Add(7);
                xsnakecords.Add(8);
                ysnakecords.Add(8);
                snakecordscombined.Add(66);
                snakecordscombined.Add(77);
                snakecordscombined.Add(88);

                for (int i = 0; i < 13; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("/");
                    Console.SetCursorPosition(44, i);
                    Console.Write("/");
                }
                for (int i = 0; i < 44; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("-");
                    Console.SetCursorPosition(i, 13);
                    Console.Write("-");
                }
            }
            void spawnapple()
            {
                
                if (!spawned)
                {
                    
                    do
                    {
                        goodcord = false;
                        applex = rnd.Next(1, 22);
                        appley = rnd.Next(1, 11);
                        applecordscombined = int.Parse(applex.ToString()+ appley.ToString());
                        for (int i = 0; i < snakecordscombined.Count; i++)
                        {
                            if (applecordscombined == snakecordscombined[i])
                            {
                                goodcord = true;
                            }
                        }
                    } while (goodcord);
                    goodcord = false;
                    /*
                    applex = rnd.Next(1, 22);
                    appley = rnd.Next(1, 11);
                    */
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(applex*2, appley);
                    Console.Write("[]");
                    Console.ForegroundColor = ConsoleColor.White;
                    spawned = true;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(applex * 2, appley);
                Console.Write("[]");
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < 13; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("/");
                Console.SetCursorPosition(44, i);
                Console.Write("/");
            }
            for (int i = 0; i < 44; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
                Console.SetCursorPosition(i, 13);
                Console.Write("-");
            }
            ;
            while (run)
            {   
                while (!(Console.KeyAvailable))
                {
                    
                    cordcount = xsnakecords.Count;
                    xdeltacord = xsnakecords[cordcount-1];
                    ydeltacord = ysnakecords[cordcount - 1];

                    deltax = xdeltacord;
                    deltay = ydeltacord;

                    deltax = deltax + xchange;
                    deltay = deltay + ychange;

                    if ((deltax == applex)&(deltay == appley))
                    {
                        spawned = false;
                        extend = true;
                    }

                    xsnakecords.Add(deltax);
                    ysnakecords.Add(deltay);
                    //snakecordcombined = int.Parse(deltax.ToString() + deltay.ToString());
                    for (int x = 0; x < snakecordscombined.Count - 1; x++)
                    {
                        if ((snakecordcombined == snakecordscombined[x]) & (cordcount>3))
                        {
                            run = false;
                            print = false;
                            Console.SetCursorPosition(0, 13);
                            Console.Write("You died! press R to restart and press any button to quit");
                        }
                    }
                    snakecordcombined = int.Parse(deltax.ToString() + deltay.ToString());

                    snakecordscombined.Add(snakecordcombined);
                    
                    if (spawned)
                    {
                        xsnakecords.RemoveAt(0);
                        ysnakecords.RemoveAt(0);
                        snakecordscombined.RemoveAt(0);
                        extend = !extend;
                    }
                    if (!spawned)
                    {
                        points = points + 10;
                    }
                    spawnapple();


                    for (int i = 0; i < xsnakecords.Count; i++)
                    {
                        printcordx = int.Parse(xsnakecords[i].ToString())*2;
                        printcordy = int.Parse(ysnakecords[i].ToString());
                        if ((printcordx < 1)||(printcordx > 43))
                        {
                            run = false;
                            print = false;
                            Console.SetCursorPosition(0, 13);
                            Console.Write("You died! press R to restart and press any button to quit");
                        }
                        if ((printcordy < 1)||(printcordy > 12))
                        {
                            run = false;
                            print = false;
                            Console.SetCursorPosition(0, 13);
                            Console.Write("You died! press R to restart and press any button to quit") ;
                        }
                        /*
                        for (int x = 0; x < snakecordscombined.Count-1; x++)
                        {
                            if ((snakecordcombined == snakecordscombined[i]) & (firstitt>10))
                            {
                                run = false;
                                print = false;
                                Console.SetCursorPosition(0, 13);
                                Console.Write("You died! press R to restart and press any button to quit");
                            }
                        }
                        */
                        if (print)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.SetCursorPosition(printcordx, printcordy);
                            Console.Write(snakepart);
                            Console.ForegroundColor = ConsoleColor.White;

                        }


                    }
                    Console.SetCursorPosition(0, 14);
                    Console.Write("Points: " + points);
                    Console.SetCursorPosition(0, 15);
                    Console.Write("Length: " + cordcount);
                    firstitt = firstitt + 1;


                    Thread.Sleep(150);
                    

                    printcordx = int.Parse(xsnakecords[0].ToString()) * 2;
                    printcordy = int.Parse(ysnakecords[0].ToString());
                    
                    if (print)
                    {
                        Console.SetCursorPosition(printcordx, printcordy);
                        Console.Write("  ");
                    }
                    
                    Console.SetCursorPosition(0, 14);
                    Console.Write("       ");
                    Console.SetCursorPosition(0, 14);
                    Console.Write("       ");

                }

                command = Console.ReadKey(true);

                if (command.Key == ConsoleKey.W)
                {
                    ychange = ychange - 1;
                    xchange = 0;

                }
                else if (command.Key == ConsoleKey.S)
                {
                    ychange = ychange + 1;

                    xchange = 0;
                }
                else if (command.Key == ConsoleKey.D)
                {
                    xchange = xchange + 1;
                    ychange = 0;

                }
                else if (command.Key == ConsoleKey.A)
                {
                    xchange = xchange - 1;
                    ychange = 0;

                }
                else if (command.Key == ConsoleKey.Escape)
                {
                    run = false;
                    Console.Clear();
                }
                else if (command.Key == ConsoleKey.R)
                {
                    run = true;
                    respawn();
                    xchange = 0;
                    ychange = 0;
                    spawnapple();
                }

            }
            Console.Clear();

        }
    }
}

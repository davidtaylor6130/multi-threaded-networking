using System;
using System.Threading;

namespace SimpleMultiThread
{

    class ThreadTest
    {
        static void Main()
        {
            /*Thread thread0 = new Thread(DoMulti);
            thread0.Start(1);

            Thread thread1 = new Thread(DoMulti);
            thread1.Start(2);

            Thread thread2 = new Thread(DoMulti);
            thread2.Start(3);

            Thread thread3 = new Thread(DoMulti);
            thread3.Start(4);

            Thread thread4 = new Thread(DoMulti);
            thread4.Start(5);*/

            Thread thread = new Thread(DoRepeate);
            thread.Start(1);

        }

        public static void DoRepeate(object obj)
        {
            int PassIn = int.Parse(string.Format("{0}", obj));

            if (PassIn < 50)
            {
                for (int i = 1 * PassIn; i <= 10 * PassIn; i++)
                {
                    Console.WriteLine("number: ;" + i);
                }

                Thread thread1 = new Thread(DoRepeate);
                thread1.Start(PassIn + 1);
                Thread thread2 = new Thread(DoRepeate);
                thread2.Start(PassIn + 1);
            }
        }

        public static void DoCount(object obj)
        {
            Console.WriteLine();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("thread 1 :" + i);
            }
        }

        public static void DoMulti(object obj)
        {
            int temp = int.Parse(string.Format("{0}", obj)) * 500;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj);
                Thread.Sleep(temp);
            }
        }
    }
}

using System;


namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(r.blabla);

            try
            {
                var account = new GiftCardAccount("asdawdaw", 1000);
                account.MakeWitdrawl(100, DateTime.Now, "awdawd");
                var account2 = new InterestEarningAccount("asdawdaw", 203030);
                var account3 = new LineOfCreditAccount("ugabuga", 100000);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message, e.ParamName, e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message, e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.ToString());
            }

        }
    }
}

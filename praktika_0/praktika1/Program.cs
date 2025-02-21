using System;

namespace praktika1
{
    class Program
    {

        static void Main(string[] args)
        {
            Human human = new(161, 50, "sss", "ddd", DateTime.Parse("12.12.12"));
            human.SetHeight(60);
        }
    }
}

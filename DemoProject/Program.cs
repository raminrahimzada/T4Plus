using System;

namespace DemoProject
{
    [AutoCtor]
    public partial class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User(Guid.NewGuid(), "Tükəzban", 35, 45.0);
            
        }
    }
}

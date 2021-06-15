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


    [AutoMap(typeof(User))]
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var user = new User(Guid.NewGuid(), "Tükəzban", 35, 45.0);

            UserDTO dto = user.Map();
        }
    }
}



/*
 *### All you have to do is just write custom generator attribute like that:<br/>

<img src="https://i.imgur.com/pdq8k6c.png"/>
 *
 */
using System;
namespace DemoProject
{
    partial class User
    {
        public User(System.Guid id,System.String name,System.Int32 age,System.Double weight)
        {
            this.Id=id;
            this.Name=name;
            this.Age=age;
            this.Weight=weight;
        }
    }
}
namespace DemoProject
{
    public static partial class Extensions
    {
        public static DemoProject.UserDTO Map(this DemoProject.User user)
        {
            if(user==null) return null;
            var result = new DemoProject.UserDTO();
            result.Id = result.Id;
            result.Name = result.Name;
            result.Age = result.Age;
            result.Weight = result.Weight;
            return result;
        }
    }
}

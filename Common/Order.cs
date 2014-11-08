using System;

namespace Common
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name {1}, Color {2}", Id, Name, Color);
        }
    }
}
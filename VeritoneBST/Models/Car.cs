namespace VeritoneBST.Models
{
    public class Car : IComparable
    {
        public int Year { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"Car {Model} - {Year}";
        }

        public int CompareTo(object? other)
        {
            var temp = other as Car;

            if (temp == null)
                return -1;

           if(this.Year < temp.Year)
                return -1;
           if(this.Year > temp.Year)
                return 1;

           return 0;
        }
    }
}

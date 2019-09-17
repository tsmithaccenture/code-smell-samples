using System.Collections.Generic;

namespace Mysterious.Name.Samples
{
    public class Customer
    {
        private List<Rental> _list;
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
            _list = new List<Rental>();
        }

        public void Add(Rental rental)
        {
            _list.Add(rental);
        }

        public string Statement()
        {
            var total = 0d;
            var points = 0;
            var enumerator = _list.GetEnumerator();
            var result = $"Rental Record for {Name}\n";

            while (enumerator.MoveNext())
            {
                var thisAmount = 0d;
                var each = enumerator.Current;

                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        }
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                        {
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        }
                        break;
                }

                points++;
                if (each.Movie.PriceCode == Movie.NEW_RELEASE && each.DaysRented > 1)
                {
                    points++;
                }

                result += $"\t{each.Movie.Title}\t{thisAmount:0.0}\n";
                total += thisAmount;
            }

            result += $"You owed {total:0.0}\n";
            result += $"You earned {points} frequent renter points\n";
            return result;
        }
    }
}
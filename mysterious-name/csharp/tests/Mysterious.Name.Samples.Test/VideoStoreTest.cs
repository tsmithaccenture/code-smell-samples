using FluentAssertions;
using Xunit;

namespace Mysterious.Name.Samples.Test
{
    public class VideoStoreTest
    {
        private readonly Customer _subject;

        public VideoStoreTest()
        {
            _subject = new Customer("Fred");
        }
        
        [Fact]
        public void StatementTest()
        {
            _subject.Add(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));

            var s = _subject.Statement();

            s.Should().Be("Rental Record for Fred\n\tThe Cell\t9.0\nYou owed 9.0\nYou earned 2 frequent renter points\n");
        }

        [Fact]
        public void StatementTest2()
        {
            _subject.Add(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));
            _subject.Add(new Rental(new Movie("The Tigger Movie", Movie.NEW_RELEASE), 3));

            var statement = _subject.Statement();
            
            statement.Should().Be("Rental Record for Fred\n\tThe Cell\t9.0\n\tThe Tigger Movie\t9.0\nYou owed 18.0\nYou earned 4 frequent renter points\n");
        }

        [Fact]
        public void StatementTest3()
        {
            _subject.Add(new Rental(new Movie("The Tigger Movie", Movie.CHILDRENS), 3));

            var statement = _subject.Statement();
            
            statement.Should().Be("Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points\n");
        }

        [Fact]
        public void StatementTest4()
        {
            _subject.Add(new Rental(new Movie("The Tigger Movie", Movie.CHILDRENS), 3));
            _subject.Add(new Rental(new Movie("Zootopia", Movie.CHILDRENS), 4));

            var statement = _subject.Statement();
            
            statement.Should().Be("Rental Record for Fred\n\tThe Tigger Movie\t1.5\n\tZootopia\t3.0\nYou owed 4.5\nYou earned 2 frequent renter points\n");
        }

        [Fact]
        public void GivenMultipleRegularRentalsWhenGetStatementThenStatementHasAllRentals()
        {
            _subject.Add(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            _subject.Add(new Rental(new Movie("8 1/2", Movie.REGULAR), 2));
            _subject.Add(new Rental(new Movie("Eraserhead", Movie.REGULAR), 3));

            var statement = _subject.Statement();
            
            statement.Should().Be("Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n");
        }
    }
}
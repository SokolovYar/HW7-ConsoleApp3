using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        internal class FootballClub : IEnumerator<FootballPlayer>
        {
            protected List<FootballPlayer> team;
            public string Name { get; set; }
            protected int _position = -1;

            public FootballPlayer Current { get { return team[_position]; } }

            object IEnumerator.Current { get; }

            public FootballClub(string name, List<FootballPlayer> team)
            {
                Name = name;
                this.team = team;
            }
            public FootballClub(string name, uint size = 0)  //uint - чтобы не писать try catch для отрицательного размера
            {
                Name = name;
                team = new List<FootballPlayer>((int)size);
            }

            public void PushPlayer(FootballPlayer NewPlayer)
            {
                team.Add(NewPlayer);
            }

            public void PopPlayer()
            {
                if (team.Count >= 1) team.RemoveAt(team.Count - 1);
            }

            public IEnumerator<FootballPlayer> GetEnumerator()
            {
                return team.GetEnumerator();
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_position < team.Count)
                {
                    _position++;
                    return true;
                }
                return false;

            }
            public void Reset()
            {
                _position = -1;
            }
        }

        internal class FootballPlayer 
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public double Age { get; set; }
            public int Scores { get; set; }

            public FootballPlayer()
            {
                Name = "NoName";
                Number = 0;
                Age = 0;
                Scores = 0;
            }

            public FootballPlayer(string name, uint number, uint age)
            {
                Name = name;
                Number = (int)number;
                Age = (int) age;
                Scores = 0;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Number: {Number}, Age: {Age}, Scores: {Scores}";
            }

            public void MakeGoal()
            {
                Scores += 1;
            }
        }


        static void Main(string[] args)
        {
            FootballClub Chernomorets = new FootballClub("Chrnomorets");

            Chernomorets.PushPlayer(new FootballPlayer("Zidan", 1, 45));
            Chernomorets.PushPlayer(new FootballPlayer("Shevchenko", 2, 47));
            Chernomorets.PushPlayer(new FootballPlayer("Messi", 3, 35));

            foreach (var player in Chernomorets)
                Console.WriteLine(player);
            Console.WriteLine();
        }
    }
}

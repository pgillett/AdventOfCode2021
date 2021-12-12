using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day12
    {
        public int SmallCavesOnce(string input) => new CavesSystem(input).SingleVisit();

        public int SmallCavesOneTwice(string input) => new CavesSystem(input).DoubleVisit();

        private class Cave
        {
            public bool Big;

            public Cave(string name)
            {
                Big = char.IsUpper(name[0]);
            }
        }
        
        private class CavesSystem
        {
            private Cave _start;
            private Cave _end;
            private Dictionary<string, Cave> _caves = new();
            private Dictionary<Cave, List<Cave>> _links = new();

            public CavesSystem(string input)
            {
                var lines = input.Split(Environment.NewLine);
                foreach (var line in lines)
                {
                    var split = line.Split('-');

                    var caveFrom = NewAdd(split[0]);
                    var caveTo = NewAdd(split[1]);

                    AddLink(caveFrom, caveTo);
                    AddLink(caveTo, caveFrom);
                }

                _start = _caves["start"];
                _end = _caves["end"];
            }
            
            private Cave NewAdd(string name)
            {
                if (_caves.ContainsKey(name)) return _caves[name];
                var cave = new Cave(name);
                _caves.Add(name, cave);
                return cave;
            }

            private void AddLink(Cave from, Cave to)
            {
                if (!_links.ContainsKey(from))
                    _links[from] = new List<Cave>();
                _links[from].Add(to);
            }

            public int SingleVisit() => Traverse(_start, new Stack<Cave>(), false);

            public int DoubleVisit() => Traverse(_start, new Stack<Cave>(), true);

            private int Traverse(Cave cave, Stack<Cave> visited, bool twoVisits)
            {
                if (cave == _end) return 1;

                if (!cave.Big)
                {
                    if (visited.Contains(cave))
                    {
                        if (cave == _start || !twoVisits) return 0;
                        if (visited
                            .GroupBy(c => c)
                            .Any(c => c.Count() > 1)) return 0;
                    }
                    visited.Push(cave);
                }

                var count = _links[cave].Aggregate(0, (current, link) => current + Traverse(link, visited, twoVisits));

                if (!cave.Big) visited.Pop();

                return count;
            }
        }
    }
}
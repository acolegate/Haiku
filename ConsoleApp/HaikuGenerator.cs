using System;

namespace Haiku
{
    public class HaikuGenerator
    {
        private static readonly string[] Line1Word4 = {
                                                          "believes",
                                                          "collides",
                                                          "comes home",
                                                          "dances",
                                                          "darkens",
                                                          "demeans",
                                                          "denies",
                                                          "destroys",
                                                          "enters there",
                                                          "explodes",
                                                          "gazes",
                                                          "goes away",
                                                          "goes down",
                                                          "goes up",
                                                          "guesses",
                                                          "hardens",
                                                          "is born",
                                                          "is dead",
                                                          "is true",
                                                          "lightens",
                                                          "listens",
                                                          "pleases",
                                                          "puzzles",
                                                          "reasons",
                                                          "rises",
                                                          "shimmers",
                                                          "shivers",
                                                          "softens",
                                                          "swims away",
                                                          "wanders",
                                                          "whispers",
                                                          "will fall",
                                                          "will turn",
                                                          "wonders"
                                                      };

        private static readonly string[] Line2Word1 = {
                                                          "beauteous",
                                                          "blossoming",
                                                          "cascading",
                                                          "collapsing",
                                                          "corroding",
                                                          "darkening",
                                                          "delicate",
                                                          "determined",
                                                          "devious",
                                                          "engulfing",
                                                          "enveloped",
                                                          "flowering",
                                                          "forbidden",
                                                          "generous",
                                                          "immaculate",
                                                          "lightening",
                                                          "luminous",
                                                          "repulsive",
                                                          "secretive",
                                                          "shadowy",
                                                          "summery",
                                                          "unfolding",
                                                          "unfolding",
                                                          "vibrating"
                                                      };

        private static readonly string[] Line2Word2 = {
                                                          "beauty",
                                                          "current",
                                                          "deep crag",
                                                          "evening",
                                                          "evil",
                                                          "father",
                                                          "friendship",
                                                          "goddess",
                                                          "heartache",
                                                          "husband",
                                                          "laughter",
                                                          "lotus",
                                                          "lover",
                                                          "mother",
                                                          "music",
                                                          "nightfall",
                                                          "petal",
                                                          "raindrop",
                                                          "river",
                                                          "shadow",
                                                          "snowfall",
                                                          "spirit",
                                                          "starfish",
                                                          "street light",
                                                          "summer",
                                                          "system",
                                                          "water",
                                                          "winter"
                                                      };

        private static readonly string[] Line2Word3 = {
                                                          "beats",
                                                          "chirps",
                                                          "chokes",
                                                          "cries",
                                                          "dies",
                                                          "dives",
                                                          "drops",
                                                          "eats",
                                                          "ends",
                                                          "flows",
                                                          "grunts",
                                                          "lives",
                                                          "pants",
                                                          "rocks",
                                                          "runs",
                                                          "shakes",
                                                          "sings",
                                                          "smears",
                                                          "soars",
                                                          "spreads",
                                                          "stares",
                                                          "stirs",
                                                          "wounds"
                                                      };

        private readonly Random _random;
        private readonly Dictionary _dictionary;

        public HaikuGenerator(Random random)
        {
            _random = random;
            _dictionary = new Dictionary(random);
        }

        public string Generate(int indent = 0)
        {
            string l1w1 = _dictionary.SentenceStart;
            string l1w2 = _dictionary.Adjective(6);
            string l1w3 = _dictionary.Noun(6);
            string l1w4 = Line1Word4[_random.Next(Line1Word4.GetUpperBound(0))];
            string l2w1 = Line2Word1[_random.Next(Line2Word1.GetUpperBound(0))];
            string l2w2 = Line2Word2[_random.Next(Line2Word2.GetUpperBound(0))];
            string l2w3 = Line2Word3[_random.Next(Line2Word3.GetUpperBound(0))];
            string l3w1 = _dictionary.LastSentenceStart;
            string l3w2 = _dictionary.Verb(6);
            string l3w3 = _dictionary.HaikuEnd;

            // sort out A/An

            if (l1w1 == "a")
            {
                l1w1 = l1w2.GetIndefiniteArticle();
            }

            if (l3w1 == "a")
            {
                l3w1 = l3w2.GetIndefiniteArticle();
            }


            string indentChars = new string(' ', indent);

            string haiku = string.Format("{0} {1} {2} {3}.\r\n", l1w1.ToTitleCase(), l1w2, l1w3, l1w4);
            haiku += string.Format("{0} {1} {2},\r\n", l2w1.ToTitleCase(), l2w2, l2w3);
            haiku += string.Format("{0} {1}, {2}.", l3w1.ToTitleCase(), l3w2, l3w3);

            if (indent > 0)
            {
                haiku = indentChars + haiku.Replace("\r\n", "\r\n" + indentChars);
            }

            return haiku;
        }
    }
}
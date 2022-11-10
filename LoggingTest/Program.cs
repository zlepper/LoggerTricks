
using System;
using LoggerLib;

namespace LoggingTest;

class Program
{
    public static void Main(string[] args)
    {
        var logger = new Logger();

        logger.Log("No args test log");

        var theAnswerToLifeTheUniverseAndEverything = 42;
        
        logger.Log("Single arg test", theAnswerToLifeTheUniverseAndEverything);

        logger.Log("Double arg test", theAnswerToLifeTheUniverseAndEverything, DateTime.Now.Year);

        var s1 = "foo";
        var s2 = "bar";
        
        logger.Log("Double string test", s1, s2);
    }
}
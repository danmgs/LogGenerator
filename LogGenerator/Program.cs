using log4net;
using log4net.Config;
using System;
using System.Configuration;
using System.Threading;

namespace LogGenerator
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            int icount = 0;

            do
            {
                int rLevel = RandomGen.GenerateRandomLevelNumber((int)LEVEL.ALL, (int)LEVEL.OFF);
                double rTimeEllapsed = RandomGen.GenerateRandomTimeEllapse(100);

                if (rLevel == (int)LEVEL.DEBUG)
                    log.DebugFormat("I am a DEBUG message. Operation process in {0}ms", rTimeEllapsed);
                else if (rLevel == (int)LEVEL.INFO)
                    log.InfoFormat("I am a INFO message. Operation process in {0}ms", rTimeEllapsed);
                else if (rLevel == (int)LEVEL.WARN)
                    log.WarnFormat("I am a WARN message. Operation process in {0}ms", rTimeEllapsed);
                else if (rLevel == (int)LEVEL.ERROR)
                    log.ErrorFormat("I am a ERROR message. Operation process in {0}ms", rTimeEllapsed);
                else if (rLevel == (int)LEVEL.FATAL)
                {
                    int iProba = Convert.ToInt32(ConfigurationManager.AppSettings["probability.to.generate.exception"]);
                    
                    if (icount % iProba == 0)
                        log.FatalFormat("I am a FATAL message with an exception: '{0}'. Operation process in {1}ms", new Exception("Operation Exception."), rTimeEllapsed);
                    else
                        log.FatalFormat("I am a FATAL message. Operation process in {0}ms", rTimeEllapsed);
                }

                icount ++;
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["sleep.duration"]));
            }
            while (true);

        }

    }
}

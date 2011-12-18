﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace HuntingDog
{
    public class MyLogger
    {

        static MyLogger()
        {
            //LogManager.ThrowExceptions = true;

          // Step 1. Create configuration object 
            LoggingConfiguration config = new LoggingConfiguration();

            FileTarget fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 
            fileTarget.FileName = "${basedir}/Logs/HuntingDogLog.txt";
            //fileTarget.FileName = @"c:\HuntingDogLog.txt";
            
            fileTarget.Layout = "${message}";


            LoggingRule rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;

            Logger logger = LogManager.GetLogger("foo");
            logger.Info("Program started"); 

        }

        public static Logger Logger
        {
            get
            {
               return LogManager.GetLogger("Example");

            }
        }

        public static void LogError(string msg,Exception ex)
        {
            Logger.ErrorException(msg,ex);
        }


        public static void LogMessage(string msg)
        {
            Logger.Info(msg);
        }



    }
}

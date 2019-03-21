using aaLogReader;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Monitor_APP.Interfaces;

namespace Monitor_APP
{
    public abstract class SMC_Logger : ISMC_Logger
    {
        private static ConcurrentQueue<LogRecord> SMC_Messages = new ConcurrentQueue<LogRecord>();

        public virtual void ReadMessage()
        {
            //TODO: has to be implemented yet
        }

        public virtual void CollectMessage()
        {
            // Read SMC Message
            aaLogReader.OptionsStruct testOptions = new aaLogReader.OptionsStruct();
            testOptions.LogDirectory = "\\\\localhost\\C$\\ProgramData\\ArchestrA\\LogFiles";

            aaLogReader.aaLogReader logReader = new aaLogReader.aaLogReader(testOptions);
            
            DateTime dtStartDate = new System.DateTime(2019, 3, 20, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime dtEndDate = new System.DateTime(2019, 3, 22, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Console.Write("Start time " + dtStartDate + "\n");
            Console.Write("End time " + dtEndDate + "\n");

            ulong MessageNumber_Start = 0;
            ulong MessageNumber_End = 0;

            try
            {
                List<LogRecord> records_start = logReader.GetRecordsByStartTimestampAndCount(dtStartDate, 1);
                List<LogRecord> records_end = logReader.GetRecordsByStartTimestampAndCount(dtEndDate, 1);

                if (records_start.Count == 0)
                {
                    Console.Write("No log rows found.!" + "\n");
                }
                else
                {
                    foreach (var LogRecord in records_start)
                    {
                        MessageNumber_Start = LogRecord.MessageNumber;
                    }
                }

                if (records_end.Count == 0)
                {
                    LogRecord LogLastRecord = new LogRecord();
                    LogLastRecord = logReader.GetLastRecord();
                    MessageNumber_End = LogLastRecord.MessageNumber;
                }
                else
                {
                    foreach (var LogRecord in records_end)
                    {
                        MessageNumber_End = LogRecord.MessageNumber;
                    }
                }
                
                int NumberMessageRecords;
                
                if (Convert.ToInt32(MessageNumber_End - MessageNumber_Start) <= 10000000)
                {
                    NumberMessageRecords = Convert.ToInt32(MessageNumber_End - MessageNumber_Start);
                }
                else
                {
                    NumberMessageRecords = 10000000;
                }

                List<LogRecord> records = logReader.GetRecordsByStartTimestampAndCount(dtStartDate, NumberMessageRecords);
                List<string> groupedMessages = new List<string>();

                //setting all the records in a concurrent queue FIFO style
                //if we want to expand the features, let's set the entire object.
                foreach (var LogRecord in records)
                {
                    SMC_Messages.Enqueue(LogRecord);
                }

                Console.WriteLine("Finished setting the logrecord in the queue.\n");
                Console.WriteLine("The size of the concurrent queue is " + SMC_Messages.Count.ToString());
                Console.WriteLine("END.\n");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



    
    }
}

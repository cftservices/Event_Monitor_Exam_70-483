using aaLogReader;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Monitor_APP
{
    public class SMC_Logger : IMessage
    {
        private static ConcurrentQueue<String> SMC_Messages;
        public string LogMessage { get; set; }
               
        public string ReadMessage()
        {
            // Read SMC Message
            aaLogReader.OptionsStruct testOptions = new aaLogReader.OptionsStruct();
            testOptions.LogDirectory = "\\\\localhost\\C$\\ProgramData\\ArchestrA\\LogFiles";

            aaLogReader.aaLogReader logReader = new aaLogReader.aaLogReader(testOptions);
            
            DateTime dtStartDate = new System.DateTime(2019, 3, 13, DateTime.Now.Hour - 12, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime dtEndDate = new System.DateTime(2019, 3, 13, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

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
                
                

                foreach (var LogRecord in records)
                {
                    //setting all the records in a concurrent queue FIFO style
                    SMC_Messages.Enqueue(LogRecord.Message.ToString());
                }

                Console.WriteLine("the size of the concurrent queue is " + SMC_Messages.Count.ToString());
                Console.ReadKey();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            
            
            return LogMessage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SingletonDLL
{
    public class SingletonLogger
    {
        private const string FILE_NAME = "log.txt";
        


        #region Singelton
        private static SingletonLogger _instance = null;
        private static object _padlock = new object();

        private SingletonLogger()
        {
            streamWriter = new StreamWriter(File.Create(FILE_NAME));
        }
        public static SingletonLogger Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {

                            _instance = new SingletonLogger();
                        }
                    }
                }
                return _instance;
            }
            
        }
        #endregion

        #region Instance
        private StreamWriter streamWriter = null;
        private object _streamSync = new object();
        public void LogMsg(string msg)
        {
            lock (_streamSync)
            {
                streamWriter.WriteLine("{0} - {1}", DateTime.Now, msg);
                Thread.Sleep(10);
            }
        }
        public void Close()
        {
            streamWriter.Close();
        }
        #endregion

    }
}

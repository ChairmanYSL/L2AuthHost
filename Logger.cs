using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AuthHost
{
    class Logger
    {
        private static Logger _instance;
        private readonly string _logFilePath;
        private bool _isEnabled = true; // 新增一个变量用于控制是否写入日志文件

        private Logger(string directory)
        {
            // 根据当前日期生成文件名
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string logFileName = $"{currentDate}-log.txt";

            // 如果目录不存在，则创建它
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // 设置日志文件的完整路径
            _logFilePath = Path.Combine(directory, logFileName);
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    // 初始化Logger的实例
                    _instance = new Logger(Application.StartupPath);
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            if(_isEnabled)
            {
                var stackTrace = new StackTrace(true);
                var frame = stackTrace.GetFrame(1); // 1 表示上一层的栈帧
                var line = frame.GetFileLineNumber();

                string formattedMessage = $"{DateTime.Now}  [Line: {line}]: {message}";
                File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
            }
        }

        public void SetEnabled(bool isEnabled) // 新增一个方法用于设置是否写入日志文件
        {
            _isEnabled = isEnabled;
        }
    }
}


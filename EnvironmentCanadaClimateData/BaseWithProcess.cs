using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAWKLORRY
{
    /// <summary>
    /// base class for classes which need to report process
    /// </summary>
    class BaseWithProcess
    {
        private int _processPercentage = 0;
        private string _processMessage = "";

        public int ProcessPercentage
        {
            get { return _processPercentage; }
        }

        public string ProcessMessage
        {
            get { return _processMessage; }
        }

        public event EventHandler ProgressChanged = null;

        protected void setProgress(int percentage, string msg)
        {
            _processPercentage = percentage;
            _processMessage = msg;

            if (ProgressChanged != null)
                ProgressChanged(this, new EventArgs());
        }
    }
}

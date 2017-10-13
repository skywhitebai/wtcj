using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTCJ
{
    public class JsonObject
    {
        public static int STATUS_SUCCESS=1;
        public static int STATUS_FAIL = -1;
        private int _status=1;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private String _message;

        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private String _erroMessage;

        public String ErroMessage
        {
            get { return _erroMessage; }
            set { _erroMessage = value; }
        }
        private object _data;

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
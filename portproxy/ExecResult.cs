using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace portproxy
{
    class ExecResult
    {
        public ExecResult()
        {
        }
        public ExecResult(int code,string output,string error):this()
        {
            this.code = code;
            this.output = output;
            this.error = error;
        }
        public int code { get; set; }
        public string output { get; set; }
        public string error { get; set; }
    }
}

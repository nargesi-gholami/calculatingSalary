using System;
using System.Collections.Generic;
using System.Text;

namespace calculateSalary
{
    class Content
    {
        private string _subject;
        private int _uniqueId;
        private Date _sendDate;
        private string _text;
        public int getId => _uniqueId;
        public Content(int uniqueId, string subject, Date date )
        {
            _uniqueId = uniqueId;
            _subject = subject;
            _sendDate = date;
        }
        public void setText(string text)
        {
            _text = text;
        }
    }
}

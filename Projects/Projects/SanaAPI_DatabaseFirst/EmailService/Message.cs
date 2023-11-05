using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public List<MailboxAddress> Cc { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        [Obsolete]
        public Message(IEnumerable<string> to, IEnumerable<string> cc, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(t => new MailboxAddress(t)));
            Cc = new List<MailboxAddress>();
            Cc.AddRange(cc.Select(c => new MailboxAddress(c)));
            Subject = subject;
            Content = content;
        }
    }
}

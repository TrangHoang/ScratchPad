﻿using System;
using System.Net.Mail;

namespace MailingServiceDemo.Model
{
    public class SentMessage : Entity
    {
        public Guid RequestId { get; set; }

        public MailMessage Message { get; set; }

        public DateTime SentAt { get; set; }
    }
}

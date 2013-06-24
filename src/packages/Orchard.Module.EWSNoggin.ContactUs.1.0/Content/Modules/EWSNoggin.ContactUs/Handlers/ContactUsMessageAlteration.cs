using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Messaging.Events;
using Orchard.ContentManagement;
using Orchard.Messaging.Models;

namespace EWSNoggin.ContactUs.Handlers
{
	public class ContactUsMessageAlteration : IMessageEventHandler
	{
		public void Sending(MessageContext context)
		{
			if ( context.Type == "ContactUs" ) {
				context.MailMessage.Subject = "Contact us form";
				context.MailMessage.Body = string.Format("Message from: {0} - {1}\n{2}", context.Properties["Name"], context.Properties["Email"], context.Properties["Message"]);
			}

		}

		public void Sent(MessageContext context) {
		}
	}
}
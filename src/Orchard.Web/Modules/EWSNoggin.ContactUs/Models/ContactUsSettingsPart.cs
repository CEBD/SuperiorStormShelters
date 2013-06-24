using Orchard.ContentManagement.Records;
using Orchard.ContentManagement;
using System.ComponentModel;

namespace EWSNoggin.ContactUs.Models
{
	public class ContactUsSettingsRecord : ContentPartRecord
	{
		public virtual string	RecipientUserName { get; set; }
	}
	
	public class ContactUsSettingsPart : ContentPart<ContactUsSettingsRecord>
	{
		[DisplayName("Recipient user name")]
		public string RecipientUserName
		{
			get { return Record.RecipientUserName; }
			set { Record.RecipientUserName = value; }
		}
	}
}

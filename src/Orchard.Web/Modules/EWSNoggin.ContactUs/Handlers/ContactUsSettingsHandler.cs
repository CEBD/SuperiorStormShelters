using JetBrains.Annotations;

using Orchard.Core.Common.Models;
using Orchard.Data;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;

using EWSNoggin.ContactUs.Drivers;
using EWSNoggin.ContactUs.Models;

namespace EWSNoggin.ContactUs.Handlers
{
	[UsedImplicitly]
	public class ContactUsSettingsHandler : ContentHandler
	{
		public ContactUsSettingsHandler(IRepository<ContactUsSettingsRecord> repository)
		{
			Filters.Add(new ActivatingFilter<ContactUsSettingsPart>("ContactUsSettings"));
			Filters.Add(StorageFilter.For(repository));
			
			Filters.Add(new TemplateFilterForRecord<ContactUsSettingsRecord>("ContactUsSettings", "Parts/ContactUsSettings"));
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Orchard.ContentManagement.Aspects;
using Orchard.Data;
using Orchard.Logging;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Services;

using EWSNoggin.ContactUs.Drivers;
using EWSNoggin.ContactUs.Models;

namespace EWSNoggin.ContactUs.Services
{
	[UsedImplicitly]
	public class ContactUsService : IContactUsService
	{
		private readonly IContentManager	 _contentManager;

		public ContactUsService(IContentManager contentManager)
		{
			_contentManager	= contentManager;
		}

		public ContactUsSettingsPart Get()
		{
			var page = _contentManager.Query<ContactUsSettingsPart, ContactUsSettingsRecord>()
										.List()
										.FirstOrDefault();

			if (page == null)
				page = _contentManager.New<ContactUsSettingsPart>("ContactUsSettings");

			return page;
		}
	}
}
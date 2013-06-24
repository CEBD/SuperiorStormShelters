using System;
using System.Web.Routing;
using JetBrains.Annotations;

using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
//using Orchard.Mvc.ViewModels;

using EWSNoggin.ContactUs.Models;

namespace EWSNoggin.ContactUs.Drivers
{
	[UsedImplicitly]
	public class ContactUsPageDriver : ContentPartDriver<ContactUsSettingsPart>
	{
		protected override DriverResult Editor(ContactUsSettingsPart settingsPart, IUpdateModel updater, dynamic shapeHelper)
		{
			updater.TryUpdateModel(settingsPart, Prefix, null, null);
			return Editor(settingsPart, shapeHelper);
		}
	}
}
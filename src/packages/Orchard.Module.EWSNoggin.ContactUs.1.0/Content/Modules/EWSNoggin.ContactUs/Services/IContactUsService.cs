using System.Collections.Generic;
using Orchard;
using Orchard.ContentManagement;

using EWSNoggin.ContactUs.Models;

namespace EWSNoggin.ContactUs.Services
{
	public interface IContactUsService : IDependency
	{
		ContactUsSettingsPart Get();
	}
}
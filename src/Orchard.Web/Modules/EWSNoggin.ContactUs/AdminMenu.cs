using Orchard.UI.Navigation;
using Orchard.Localization;

namespace EWSNoggin.ContactUs
{
	public class AdminMenu : INavigationProvider
	{
		public string MenuName { get { return "admin"; } }

		public Localizer T { get; set; }

		public void GetNavigation(NavigationBuilder builder)
		{
			builder.Add(T("Contact Us"), "3", BuildMenu);
		}

		private void BuildMenu(NavigationItemBuilder menu)
		{
			menu.Add(T("Manage Contact Us"), "1.0",
				item => item.Action("Index", "Admin", new { area = "EWSNoggin.ContactUs" }));
		}

	}
}

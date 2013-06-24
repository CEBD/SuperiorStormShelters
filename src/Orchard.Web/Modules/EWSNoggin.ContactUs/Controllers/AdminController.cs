using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

using Orchard;
using Orchard.Localization;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Settings;
using Orchard.UI.Notify;

using EWSNoggin.ContactUs.Drivers;
using EWSNoggin.ContactUs.Models;
using EWSNoggin.ContactUs.Services;
using EWSNoggin.ContactUs.ViewModels;
using Orchard.DisplayManagement;

namespace EWSNoggin.ContactUs.Controllers
{
	public class AdminController : Controller, IUpdateModel
	{
		private IContactUsService _contactUsService;
		private IOrchardServices Services { get; set; }
		private dynamic Shape { get; set; }

		public virtual ISite CurrentSite { get; set; }
		public virtual IUser CurrentUser { get; set; }
		public Localizer T { get; set; }


		public AdminController(IOrchardServices orchardServices, IContactUsService contactUsService, IShapeFactory shapeFactory)
		{
			Services = orchardServices;
			_contactUsService = contactUsService;
			Shape = shapeFactory;
		}

		[HttpGet]
		public ActionResult Index()
		{
			if (!Services.Authorizer.Authorize(Permissions.ManageContactUs, T("Not allowed to edit contact us")))
				return new HttpUnauthorizedResult();

			ContactUsSettingsPart contactSettings = _contactUsService.Get();

			var editor = createSettingsEditor(contactSettings);
			var model = Services.ContentManager.BuildEditor(contactSettings);
			model.Content.Add(editor);


			return View((object)model);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Index(ContactUsSettingsRecord ContactUsSettings)
		{
			var contactSettings = _contactUsService.Get();
			if (contactSettings.Id == 0)
			{
				Services.ContentManager.Create(contactSettings);
			}

			var editor = createSettingsEditor(contactSettings);
			var model = Services.ContentManager.UpdateEditor(contactSettings, this);
			model.Content.Add(editor);

			if (!ModelState.IsValid)
			{
				return View((object)model);
			}

			Services.Notifier.Information(T("Contact us settings updated. Make sure this user has a valid email address set."));

			return View((object)model);
		}

		private dynamic createSettingsEditor(ContactUsSettingsPart settings)
		{
			var editor = Shape.EditorTemplate(TemplateName: "Parts/ContactUsSettings", Model: settings, Prefix: null);
			editor.Metadata.Position = "2";
			return editor;
		}

		bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties)
		{
			return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
		}

		void IUpdateModel.AddModelError(string key, LocalizedString errorMessage)
		{
			ModelState.AddModelError(key, errorMessage.ToString());
		}
	}
}
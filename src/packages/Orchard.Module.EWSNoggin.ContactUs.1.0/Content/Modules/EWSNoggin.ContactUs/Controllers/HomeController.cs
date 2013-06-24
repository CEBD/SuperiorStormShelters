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

// externally referenced module for spam protection
using Orchard.Comments.Models;
using Orchard.Comments.Services;

using EWSNoggin.ContactUs.Drivers;
using EWSNoggin.ContactUs.Models;
using EWSNoggin.ContactUs.Services;
using EWSNoggin.ContactUs.ViewModels;
using Orchard.Themes;
using Orchard.Messaging.Services;
using System.Collections.Generic;

namespace EWSNoggin.ContactUs.Controllers
{
	[Themed]
	public class HomeController : Controller
	{
		private readonly IContactUsService _contactUsService;
		private readonly ICommentValidator _commentValidator;
		private readonly IMembershipService _membershipService;
		private readonly IMessageManager _messageManager;

		public HomeController(IOrchardServices orchardServices, IContactUsService contactUsService, ICommentValidator commentValidator, IMessageManager messageManager, IMembershipService membershipService)
		{
			Services	 = orchardServices;
			_contactUsService = contactUsService;
			_commentValidator = commentValidator;
			_membershipService = membershipService;
			_messageManager = messageManager;
		}

		public IOrchardServices Services { get; set; }
		public virtual ISite CurrentSite { get; set; }
		public virtual IUser CurrentUser { get; set; }
		public Localizer T { get; set; }

		[HttpGet]
		public ActionResult Index()
		{
			//var page = _contactUsService.Get();
			//var model = Services.ContentManager.BuildDisplay(page);
			return View(new ContactUsFormViewModel());
		}

		[HttpPost]
		public ActionResult Index(ContactUsFormViewModel form)
		{
			if (!ModelState.IsValid)
			{
				return View(form);
			}


			if (validateContactMessage(form))
			{
				var settings = _contactUsService.Get();
				var recipient = _membershipService.GetUser(settings.RecipientUserName);

				if (recipient == null || String.IsNullOrEmpty(recipient.Email))
				{
					Services.Notifier.Warning(T("Site error: Couldn't send message. Site owner needs to set valid recipient user with an email address."));
					return View(form);
				}

				_messageManager.Send(recipient.ContentItem.Record, "ContactUs", "Email",
										new Dictionary<String, String> {
											{ "Name", form.Name },
											{ "Email", form.Email },
											{ "Message", form.Message }
										});

				Services.Notifier.Information(T("Thank you for your message."));
			}
			else
			{
				// Message stopped because it looked like spam
				Services.Notifier.Information(T("Sorry we could not send your message."));
			}

			return View("Sent", form);
		}

		private bool validateContactMessage(ContactUsFormViewModel form)
		{
			var comment = new CommentPart() { Record = new CommentPartRecord {
														Author		= form.Name,
														Email		= form.Email,
														CommentText	= form.Message,
														SiteName	= "",
													} };
			return _commentValidator.ValidateComment(comment);
		}
	}
}

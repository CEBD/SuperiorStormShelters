using System;
using System.Collections.Generic;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Common.ViewModels;
using Orchard.Core.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace EWSNoggin.ContactUs.ViewModels
{
	public class ContactUsFormViewModel
	{
		[Required(ErrorMessage = "Please fill in your name.")]
		[StringLength(100, ErrorMessage="That name is too long.")]
		public String Name { get; set; }

		[Required(ErrorMessage = "Please fill in your email address.")]
		[StringLength(100, ErrorMessage = "That email is too long.")]
		[RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}$", ErrorMessage = "Please check your email address.")]
		public String Email { get; set; }

		[Required(ErrorMessage = "Please fill in the message.")]
		[StringLength(1000, ErrorMessage = "Your message is too long.")]
		public String Message { get; set; }
	} 
}

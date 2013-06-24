using System.Collections.Generic;
using System.Linq;
using Orchard.Security.Permissions;
using Orchard.Environment.Extensions.Models;

namespace EWSNoggin.ContactUs
{
	public class Permissions : IPermissionProvider
	{
		public static readonly Permission ManageContactUs = new Permission {
																Description = "Manage contact us",
																Name = "ManageContactUs"
															};

		public Feature Feature { get; set; }

		public IEnumerable<Permission> GetPermissions()
		{
			return new Permission[] {
						ManageContactUs,
					};
		}

		public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
		{
			return new[] {
						new PermissionStereotype {
							Name		= "Administrator",
							Permissions	= new[] { ManageContactUs }
						},
					};
		}
	}
}
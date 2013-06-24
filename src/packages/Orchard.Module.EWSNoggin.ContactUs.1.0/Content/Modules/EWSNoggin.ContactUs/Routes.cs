using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace EWSNoggin.ContactUs
{
	public class Routes : IRouteProvider
	{
		public void GetRoutes(ICollection<RouteDescriptor> routes)
		{
			foreach (var routeDescriptor in GetRoutes())
				routes.Add(routeDescriptor);
		}

		public IEnumerable<RouteDescriptor> GetRoutes()
		{
			return new[] {
					 new RouteDescriptor {
							 Priority	= 10,
							 Route		= new Route(
												"Contact",
												new RouteValueDictionary(new {
														area		= "EWSNoggin.ContactUs",
														controller	= "Home",
														action		= "Index",
													}),
												null,
												new RouteValueDictionary(new {
														area		= "EWSNoggin.ContactUs",
													}),
												new MvcRouteHandler())
						},
					 new RouteDescriptor {
							 Priority	= 10,
							 Route		= new Route(
												"ContactUs",
												new RouteValueDictionary(new {
														area		= "EWSNoggin.ContactUs",
														controller	= "Home",
														action		= "Index",
													}),
												null,
												new RouteValueDictionary(new {
														area		= "EWSNoggin.ContactUs",
													}),
												new MvcRouteHandler())
						},
				};
		}
	}
}
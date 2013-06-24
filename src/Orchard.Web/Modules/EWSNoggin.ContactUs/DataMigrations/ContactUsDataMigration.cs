using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data.Migration.Schema;
using Orchard.Data.Migration;
using System.Data;

namespace EWSNoggin.ContactUs.DataMigrations
{
	public class ContactUsDataMigration : DataMigrationImpl
	{
		public int Create()
		{
			// Creating table WeatherRecord
			SchemaBuilder.CreateTable("ContactUsSettingsRecord", table => table
				.ContentPartRecord()
				.Column("RecipientUserName", DbType.String)
			);

			return 1;
		}
	}
}
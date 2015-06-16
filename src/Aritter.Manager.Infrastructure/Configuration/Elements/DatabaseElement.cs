using System.Configuration;

namespace Aritter.Manager.Infrastructure.Configuration.Elements
{
	public class DatabaseElement : ConfigurationElement
	{
		#region Properties

		[ConfigurationProperty("defaultSchema", DefaultValue = "dbo", IsRequired = false), StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 20)]
		public string DefaultSchema
		{
			get { return (string)this["defaultSchema"]; }
			set { this["defaultSchema"] = value; }
		}

		#endregion Properties
	}
}
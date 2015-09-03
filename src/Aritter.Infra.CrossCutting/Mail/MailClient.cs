﻿using Aritter.Infra.CrossCutting.Configuration;
using System.Net;
using System.Net.Mail;

namespace Aritter.Infra.CrossCutting.Mail
{
	public class MailClient : SmtpClient
	{
		public MailClient()
		{
			LoadClientConfig();
		}

		private void LoadClientConfig()
		{
			var mailConfig = ApplicationSettings.Mail;

			Host = mailConfig.Host;
			EnableSsl = mailConfig.EnableSsl;
			Port = mailConfig.Port;
			UseDefaultCredentials = mailConfig.UseDefaultCredentials;

			Credentials = new NetworkCredential(mailConfig.UserName, mailConfig.Password);
		}
	}
}
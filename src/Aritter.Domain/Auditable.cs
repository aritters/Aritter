﻿using System;

namespace Aritter.Domain
{
	public class Auditable : Entity, IAuditable
	{
		#region Constructor

		public Auditable()
		{
			Guid = Guid.NewGuid();
		}

		#endregion

		#region Properties

		public Guid Guid { get; private set; }

		#endregion Properties
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.Model
{
	public class Comment
	{
		public virtual int Id { get; set; }

		public virtual string Body { get; set; }

		public virtual string Email { get; set; }

		public virtual string Url { get; set; }

		public virtual DateTimeOffset CreatedAt { get; set; }

		public virtual bool IsSpam { get; set; }

		public virtual Post Post { get; set; }
	}
}

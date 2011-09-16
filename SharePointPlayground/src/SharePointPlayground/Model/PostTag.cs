using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.Model
{
	public class PostTag
	{
		public virtual int Id { get; set; }

		public virtual string Title { get; set; }

		public virtual IList<Post> Posts { get; set; }
	}
}

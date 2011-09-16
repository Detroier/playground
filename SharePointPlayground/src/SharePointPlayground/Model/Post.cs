using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPlayground.Model
{
	public class Post
	{
		public Post()
		{
			Comments = new List<Comment>();
			Tags = new List<PostTag>();
			CreatedAt = DateTimeOffset.UtcNow;
			LastEditedAt = DateTimeOffset.UtcNow;
			IsPublished = false;
			IsDeleted = false;
		}

		public virtual int Id { get; set; }

		public virtual string Title { get; set; }

		public virtual string Slug { get; set; }

		public virtual string Body { get; set; }

		public virtual bool AllowComments { get; set; }

		public virtual bool IsPublished { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual DateTimeOffset CreatedAt { get; set; }

		public virtual DateTimeOffset PublishedAt { get; set; }

		public virtual DateTimeOffset LastEditedAt { get; set; }

		public virtual IList<Comment> Comments { get; set; }

		public virtual IList<PostTag> Tags { get; set; }
	}
}

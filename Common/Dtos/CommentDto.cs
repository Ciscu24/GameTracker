using Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class CommentDto
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool Recommended { get; set; }

        public Visibility Visibility { get; set; }

        public long GameId { get; set; }

        public virtual GameDto Game { get; set; }
    }
}

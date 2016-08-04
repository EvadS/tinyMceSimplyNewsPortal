using SimplyNewsPortal.Additional;
using SimplyNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyNewsPortal.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public Pager Pager { get; set; }
    }
}
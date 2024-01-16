using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ArticleViewModel
    {

       
            public Article Article { get; set; }
            public List<Commentaire> Comments { get; set; }
        
    }
}

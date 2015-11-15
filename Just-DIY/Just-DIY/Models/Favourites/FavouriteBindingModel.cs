using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Just_DIY.Models.Favourites
{
    public class FavouriteBindingModel
    {
        public int UserId
        {
            get; set;
        }
        
        public int ProjectId
        {
            get; set;
        }
    }
}
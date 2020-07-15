using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ECommerce.Web.Models.EditorTemplates
{
    public class DropDownListItem
    {
        public DropDownListItem()
        {
            ItemList = new List<SelectListItem>();
        }

        public int ItemId { get; set; }

        public List<SelectListItem> ItemList { get; set; }
    }
}

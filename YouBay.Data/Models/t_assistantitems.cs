using System;
using System.Collections.Generic;

namespace YouBay.Data.Models
{
    public partial class t_assistantitems
    {
        public long assistantItemsId { get; set; }
        public string affirmativeAnswer { get; set; }
        public string affirmativeAnswerQuery { get; set; }
        public string negativeAnswer { get; set; }
        public string negativeAnswerQuery { get; set; }
        public Nullable<int> questionDisplayPriority { get; set; }
        public string questionText { get; set; }
        public Nullable<long> subcategory_subcategoryId { get; set; }
        public virtual t_subcategory t_subcategory { get; set; }
    }
}

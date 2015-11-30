using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class AssistantItems
    {
        public long assistantItemsId { get; set; }
        public string affirmativeAnswer { get; set; }
        public string affirmativeAnswerQuery { get; set; }
        public string negativeAnswer { get; set; }
        public string negativeAnswerQuery { get; set; }
        public Nullable<int> questionDisplayPriority { get; set; }
        public string questionText { get; set; }
        public Nullable<long> subcategory_subcategoryId { get; set; }
        public virtual Subcategory subcategory { get; set; }
    }
}

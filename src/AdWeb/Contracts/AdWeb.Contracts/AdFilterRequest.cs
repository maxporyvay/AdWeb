using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Contracts
{
    /// <summary>
    /// Модель фильтра объявлений.
    /// </summary>
    public class AdFilterRequest
    {
        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Заголовок объявления.
        /// </summary>
        public string AdTitle { get; set; }
    }
}

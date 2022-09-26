using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Contracts
{
    /// <summary>
    /// Модель представления объявления.
    /// </summary>
    public class AdWebDto
    {
        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок объявления.
        /// </summary>
        public string AdTitle { get; set; }

    }
}
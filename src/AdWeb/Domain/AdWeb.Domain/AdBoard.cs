using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Domain
{
    /// <summary>
    /// Доска объявлений.
    /// </summary>
    public class AdBoard
    {
        /// <summary>
        /// Идентификатор доски объявлений.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid AdId { get; set; }
        /// <summary>
        /// Объявление.
        /// </summary>
        public Ad Ad { get; set; }
    }
}

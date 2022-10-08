using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Contracts.AdBoard
{
    /// <summary>
    /// Модель представления доски объявлений.
    /// </summary>
    public class AdBoardDto
    {
        /// <summary>
        /// Идентификатор доски объявлений.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок объявления.
        /// </summary>
        public string AdTitle { get; set; }
    }
}
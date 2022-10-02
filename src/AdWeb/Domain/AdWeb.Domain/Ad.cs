﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Domain
{
    /// <summary>
    /// Объявление.
    /// </summary>
    public class Ad
    {
        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок объявления.
        /// </summary>
        public string AdTitle { get; set; }
        /// <summary>
        /// Описание объявления.
        /// </summary>
        public string AdDescription { get; set; }
        /// <summary>
        /// Время публикации объявления.
        /// </summary>
        public DateTime PublishTime { get; set; }
        /// <summary>
        /// Доски, где содержится данное объявление.
        /// </summary>
        public ICollection<AdBoard> AdBoards { get; set; }
    }
}

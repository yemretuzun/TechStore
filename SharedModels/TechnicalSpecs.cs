using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels
{
    public class TechnicalSpecs : BaseModel
    {
        public TechnicalSpecs()
        {
            
        }

        /// <summary>
        /// Teknik özellikleride gösterilen isim.
        /// <example>
        /// İşlemci
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Özelliğin değeri
        /// <example>
        /// Intel® Core™  i7-10875H (16M Cache)
        /// </example>
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Özelliğin default değeri
        /// <example>
        /// -
        /// </example>
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Özelliğin hangi kategoriye ait olduğunu belirtir
        /// </summary>
        /// <example>
        /// 5fda7fde227fc7339e9f2c93
        /// // (Laptop)
        /// </example>
        public string CategoryId { get; set; }
    }
}

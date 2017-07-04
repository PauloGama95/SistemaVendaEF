using AprendendoEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.Base
{
    [Serializable]
    public abstract class BaseEntidade : IBaseEntidade
    {
        public int Id { get; set; }
    }
}

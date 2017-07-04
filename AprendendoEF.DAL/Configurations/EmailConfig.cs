using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEF.DAL.Configurations
{
    public class EmailConfig : EntityTypeConfiguration<Email>
    {
        public EmailConfig()
        {
            ToTable("Email");
        }
    }
}

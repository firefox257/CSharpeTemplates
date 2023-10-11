using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Configuration
{
    public class ConfigWrapperMapper: AutoMapper.Mapper, Configuration.IMapper
    {
        public ConfigWrapperMapper(MapperConfiguration cfg): base(cfg)
        {
           
        }
    }
}

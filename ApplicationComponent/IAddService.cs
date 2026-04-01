using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationComponent
{
    public interface IAddService<TDTO, TModel>
    {

        Task AddAsync(TDTO dto);

    }
}

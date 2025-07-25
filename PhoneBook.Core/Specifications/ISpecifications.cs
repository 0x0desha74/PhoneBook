﻿using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        Expression<Func<T,bool>> Criteria { get; set; }
        List<Expression<Func<T,object>>> Includes { get; set; }
    }
}

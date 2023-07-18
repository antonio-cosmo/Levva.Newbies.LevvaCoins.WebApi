﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Application.UseCases.Categories.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public interface ICreateCategory : IRequestHandler<CreateCategoryInput, CategoryOutput>
{
}
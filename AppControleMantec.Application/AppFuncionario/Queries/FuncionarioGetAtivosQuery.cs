﻿using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppFuncionario.Queries
{
    public class FuncionarioGetAtivosQuery : IRequest<IEnumerable<FuncionarioDTO>>
    {
    }
}

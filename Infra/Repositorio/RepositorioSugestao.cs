using Domain.ISugestao;
using Entities.Entidades;
using Infra.Repositorio.Genericos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorio
{
    public class RepositorioSugestao : RepositorioGenerico<Sugestao>, InterfaceSugestao
    {
    }
}

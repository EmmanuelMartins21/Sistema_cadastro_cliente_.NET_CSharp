using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.DB
{
    //Helper para acesso a dados
    public static class Db
    {
        public static string Conexao
        {
            get
            {
                return @"Data Source=DESKTOP-1OB9IHH\SQLEXPRESS;Initial Catalog=EmpresaDB;Integrated Security=True";
            }
        }

    }
}

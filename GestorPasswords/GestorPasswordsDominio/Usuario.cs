﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class Usuario
    {
        public List<Categoria> listaCategorias;

        public Usuario()
        {
            listaCategorias = new List<Categoria>();
        }

        public bool NumeroTarjetaCreditoExistente(string numero)
        {
            foreach (Categoria unaCategoria in this.listaCategorias)
            {
                if (unaCategoria.NumeroDeTarjetaExistenteEnLaCategoria(numero))
                {
                    return true;
                }
            }
            return false;
        }
    }

   
}

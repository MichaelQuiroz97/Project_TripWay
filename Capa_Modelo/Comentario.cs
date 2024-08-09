using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Comentario
    {
        public int Id { get; set; }
        public string ComentarioTexto { get; set; }
        public string CedulaUsuario { get; set; } 
        public Usuario Usuario { get; set; } 

        public Comentario(int id, string comentarioTexto, string usuarioCedula)
        {
            Id = id;
            ComentarioTexto = comentarioTexto;
            UsuarioCedula = usuarioCedula;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WEB_agendaLanlink.Models.Enum;

namespace WEB_agendaLanlink.Models
{
        [DataContract]
        public class BaseModel
        {
            public int Id { get;  set; }
        }
        public class Pessoa : BaseModel
        {
            public string nome { get;  set; }
            public string cpf { get;  set; }
            public int telefone { get;  set; }
            public int celular { get;  set; }
            public string email { get;  set; }
            public string site { get;  set; }
            public tipoContato tipoContato { get;  set; }
            public int enderecoId { get;  set; }
            public virtual Endereco Endereco { get;  set; }

            public Pessoa()
            {
            }
            public Pessoa(int id, string nome, string cpf, string email, int celular, int telefone , string _site )
            {
                this.Id = id;
                this.nome = nome;
                this.cpf = cpf;
                this.email = email;
                this.celular = celular;
                this.telefone = telefone;
                this.site = _site;
            }
        }

        public class Endereco : BaseModel
        {
            public int numero { get;  set; }
            public int cep { get;  set; }
            public string bairro { get;  set; }
            public string cidade { get;  set; }
            public string estado { get;  set; }
            public string logradouro { get;  set; }
            public string complemento { get;  set; }
            public tipoEndereco tipoEndereco { get;  set; }          
            public Endereco()
            {
            }
            public Endereco( int id, int numero, int cep, string logradouro, string estado, string municipio)
            {
                this.Id = id;
                this.numero = numero;
                this.cep = cep;
                this.logradouro = logradouro;
                this.estado = estado;
                this.cidade = municipio;
            }
        }
}

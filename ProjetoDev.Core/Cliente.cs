namespace ProjetoDev.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    [Table("Cliente")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(1024)]
        public string OutrasInformacoes { get; set; }

        public int EmpresaId { get; set; }

        public int PipeLineId { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public Cliente CadastrarCliente(int pipelineClienteId)
        {
            //organização
            var url = $"https://api.pipedrive.com/v1/persons/{pipelineClienteId}?api_token=d8d2a00812cc811a940723a62fa28835a253901b";
            var clienteJson = Util.GetDados(url).Result;
            //DesSerializa 
            var jsonSerializer = new JavaScriptSerializer();
            dynamic obj = jsonSerializer.Deserialize<dynamic>(clienteJson);

            var cliente = new Cliente()
            {
                EmpresaId = obj["data"]["org_id"]["value"],
                PipeLineId = obj["data"]["id"],
                Nome = obj["data"]["name"],
                Telefone = obj["data"]["phone"][0]["value"],
                Email = obj["data"]["email"][0]["value"],
                OutrasInformacoes = obj["data"]["15113600d066921ff8f99cc022a2084946df529c"],
            };
            
            return cliente;
        }
    }
}

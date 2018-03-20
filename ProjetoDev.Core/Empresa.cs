namespace ProjetoDev.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    [Table("Empresa")]
    public partial class Empresa
    {
        public int EmpresaId { get; set; }
        public int PipeLineId { get; set; }

        [StringLength(255)]
        public string RazaoSocial { get; set; }

        [StringLength(255)]
        public string NomeFantasia { get; set; }

        [StringLength(1024)]
        public string ModeloNegocio { get; set; }

        [StringLength(255)]
        public string Endereco { get; set; }

        public Empresa CadastrarEmpresa(int pipelineEmpresaId)
        {
            //organização
            var url = $"https://api.pipedrive.com/v1/organizations/{pipelineEmpresaId}?api_token=d8d2a00812cc811a940723a62fa28835a253901b";
            var empresaJson = Util.GetDados(url).Result;
            //DesSerializa 
            var jsonSerializer = new JavaScriptSerializer();
            dynamic obj = jsonSerializer.Deserialize<dynamic>(empresaJson);

            var empresa = new Empresa()
            {
                PipeLineId = obj["data"]["id"],
                RazaoSocial = obj["data"]["name"],
                NomeFantasia = obj["data"]["name"],
                Endereco = obj["data"]["address"]
               // ModeloNegocio = obj["data"]["address"],
            };

            return empresa;
        }

    }


}

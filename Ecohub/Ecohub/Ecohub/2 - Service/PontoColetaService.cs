using Ecohub._1___Controllers.Models.Entrada;
using Ecohub._1___Controllers.Models.Retorno;
using Ecohub._3___Repository.Interfaces;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;
using Ecohub.Service.Interfaces;

namespace Ecohub.Service
{
    public class PontoColetaService : IPontoColetaService
    {
        private readonly IPontoColetaRepository _pontoColetaRepository;
        private readonly IMaterialPontoDeColetaRepository _materialPontoDeColetaRepository;
        private readonly IMaterialService _materialService;

        public PontoColetaService(IPontoColetaRepository pontoColetaRepository,
                                  IMaterialPontoDeColetaRepository materialPontoDeColetaRepository,
                                  IMaterialService materialService)
        {
            _materialPontoDeColetaRepository = materialPontoDeColetaRepository ?? throw new ArgumentException();
            _pontoColetaRepository = pontoColetaRepository ?? throw new ArgumentException();
            _materialService = materialService ?? throw new ArgumentException();
        }

        public void Add(PontoColetaViewModel pontoColeta)
        {
            byte[] ímagemBase64 = Convert.FromBase64String(pontoColeta.Imagem);

            var pontoColetaNovo = new PontoDeColetaEntidade(
               pontoColeta.Nome,
               pontoColeta.Email,
               pontoColeta.Numero,
               pontoColeta.Cidade,
               pontoColeta.Estado,
               pontoColeta.PontoReferencia,
               pontoColeta.CEP,
               ímagemBase64,
               pontoColeta.UsuarioId
               );

            var idAdicionado = _pontoColetaRepository.Add(pontoColetaNovo);

            for( int i = 0; i < pontoColeta.IdMateriais.Count; i++ )
            {
                _materialPontoDeColetaRepository.Add(new MaterialPontoDeColetaEntidade()
                {
                    PontoDeColetaId = idAdicionado,
                    MaterialId = pontoColeta.IdMateriais[i]
                });
            }

        }

        public async void Delete(string pontoColetaId)
        {
            var pontoColetaDelete = await _pontoColetaRepository.Get(pontoColetaId);

            // DELETAR MATERIAIS
            var materiais = _materialPontoDeColetaRepository.GetAllById(pontoColetaId);
            for( int i = 0; i < materiais.Count; i++ )
            {
                _materialPontoDeColetaRepository.Delete(materiais[i]);
            }

            _pontoColetaRepository.Delete(pontoColetaDelete);
        }

        public async Task<PontoDeColetaResponse> Get(string pontoColetaId)
        {
           var ponto = await _pontoColetaRepository.Get(pontoColetaId);
            if (ponto is null)
            {
                return new PontoDeColetaResponse();
            }

           var materiaisPonto = _materialPontoDeColetaRepository.GetAllById(pontoColetaId);
           var materiais = new List<MaterialPontoColetaResponse>();
           
            for(int i = 0; i < materiaisPonto.Count; i++ )
            {
                var material = await _materialService.Buscar(materiaisPonto[i].MaterialId);

                if(material != null)
                {
                    var response = new MaterialPontoColetaResponse()
                    {
                        Id = material.Id,
                        Nome = material.Nome
                    };

                    materiais.Add(response);
                }

            }

            var pontoBuscado = new PontoDeColetaResponse()
            {
                Id = ponto.Id,
                CEP = ponto.CEP,
                Cidade = ponto.Cidade,
                Email = ponto.Email,
                Estado = ponto.Estado,
                Imagem = ponto.Imagem,
                Nome = ponto.Nome,
                Numero = ponto.Numero,
                PontoReferencia = ponto.PontoReferencia,
                UsuarioId = ponto.UsuarioId,
                Materiais = materiais
            };


           return pontoBuscado;
        }

        public async Task<List<PontoDeColetaResponse>> GetAll()
        {
            var pontos = await _pontoColetaRepository.GetAll();
            var pontosBuscados = new List<PontoDeColetaResponse>();

            pontos.ForEach(async ponto =>
            {
                var materiaisPonto = _materialPontoDeColetaRepository.GetAllById(ponto.Id);
                var materiais = new List<MaterialPontoColetaResponse>();

                for(int i = 0; i < materiaisPonto.Count; i++)
                {
                    var material = await _materialService.Buscar(materiaisPonto[i].MaterialId);
                    if (material != null)
                    {
                        var response = new MaterialPontoColetaResponse()
                        {
                            Id = material.Id,
                            Nome = material.Nome
                        };

                        materiais.Add(response);
                    }
                }

                var pontoBuscado = new PontoDeColetaResponse()
                {
                    Id = ponto.Id,
                    CEP = ponto.CEP,
                    Cidade = ponto.Cidade,
                    Email = ponto.Email,
                    Estado = ponto.Estado,
                    Imagem = ponto.Imagem,
                    Nome = ponto.Nome,
                    Numero = ponto.Numero,
                    PontoReferencia = ponto.PontoReferencia,
                    UsuarioId = ponto.UsuarioId,
                    Materiais = materiais
                };

                pontosBuscados.Add(pontoBuscado);

            });


            return pontosBuscados;
        }

        public async void Update(PontoColetaViewModel pontoColeta, string pontoColetaId)
        {

            var pontoColetaAtt = new PontoDeColetaEntidade(
                pontoColetaId,
                pontoColeta.Nome,
                pontoColeta.Email,
                pontoColeta.Numero,
                pontoColeta.Cidade,
                pontoColeta.Estado,
                pontoColeta.PontoReferencia,
                pontoColeta.CEP,
                pontoColeta.Imagem,
                pontoColeta.UsuarioId
                );

            //TO DO :: DELETE MATERIAIS NÃO MAIS UTILIZADOS

            // ADICIONAR
            for(int i = 0; i < pontoColeta.IdMateriais.Count; i++)
            {
                var material = _materialPontoDeColetaRepository.GetOneById(pontoColetaId, pontoColeta.IdMateriais[i]);

                if(material == null)
                {
                    _materialPontoDeColetaRepository.Add(new MaterialPontoDeColetaEntidade()
                    {
                        MaterialId = pontoColeta.IdMateriais[i],
                        PontoDeColetaId = pontoColetaId
                    });
                }
            }



            _pontoColetaRepository.Update(pontoColetaAtt);
            
        }
    }
}

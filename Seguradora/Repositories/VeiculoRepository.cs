using Seguradora.Data;
using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly SeguradoraContext _context;

        public VeiculoRepository(SeguradoraContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> InserirOuAtualizar(Veiculo Veiculo)
        {
            try
            {
                Veiculo obj = _context.Veiculo.FirstOrDefault(x => x.IdVeiculo == Veiculo.IdVeiculo);

                if (obj == null)
                {
                    await _context.Veiculo.AddAsync(Veiculo);

                    _context.SaveChanges();

                    return Veiculo;
                }
                else
                {
                    obj = await AtualizarVeiculo(Veiculo);

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> ObterPorId(int IdVeiculo)
        {
            try
            {
                return _context.Veiculo.FirstOrDefault(x => x.IdVeiculo == IdVeiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirVeiculo(int IdVeiculo)
        {
            try
            {
                Veiculo obj = _context.Veiculo.FirstOrDefault(x => x.IdVeiculo == IdVeiculo);

                _context.Veiculo.Remove(obj);

                _context.SaveChanges();

                obj = _context.Veiculo.FirstOrDefault(x => x.IdVeiculo == IdVeiculo);

                if (obj == null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> AtualizarVeiculo(Veiculo Veiculo)
        {
            try
            {
                Veiculo obj = _context.Veiculo.FirstOrDefault(x => x.IdVeiculo == Veiculo.IdVeiculo);

                if (obj == null)
                {
                    return obj;
                }
                else
                {
                    obj = new Veiculo()
                    {
                        IdVeiculo = Veiculo.IdVeiculo,
                        Ano = Veiculo.Ano,
                        Marca = Veiculo.Marca,
                        Modelo = Veiculo.Modelo,
                        Placa = Veiculo.Placa,
                        ValorFipe = Veiculo.ValorFipe
                    };

                    _context.Veiculo.Update(obj);

                    _context.SaveChanges();

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
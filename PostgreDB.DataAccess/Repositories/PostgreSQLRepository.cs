using Microsoft.EntityFrameworkCore;
using Npgsql;
using PostgreDB.DataAccess.Infrastructures;
using PostgreDB.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PostgreDB.Model.DomainModels;

namespace PostgreDB.DataAccess.Repositories
{
    public interface IPostgreSQLRepository
    {
        Task<string> ConvertAdToBs(ConvertAdToBsReqDto dto);
        Task<List<DateMaps>> FiscalYear(string fiscalYear);
        Task TriggerTest(GLIndexDto dto, CancellationToken cancellationToken);
        Task TriggerUpdateTest(GLIndexUpdateDto dto, CancellationToken cancellationToken);
    }

    public class PostgreSQLRepository : IPostgreSQLRepository
    {
        private readonly PostgreDBContext _dBContext;

        public PostgreSQLRepository(IDBFactory dBFactory)
        {
            _dBContext = dBFactory.GetDBContext();
        }
        public async Task<string> ConvertAdToBs(ConvertAdToBsReqDto dto)
        {
            try
            {
                string sql = "SELECT demo_webapi1.\"FN_AdToBs\"(@engDate::date, @format)";
                using (var connection = new NpgsqlConnection(_dBContext.Database.GetConnectionString()))
                {
                    connection.Open();
                    var result = await connection.QueryFirstOrDefaultAsync<string>(sql, new { engDate = dto.EngDate, format = dto.Format });
                    return result ?? "";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return string.Empty;
        }
        public async Task<List<DateMaps>> FiscalYear(string fiscalYear)
        {
            try
            {
                string sql = "SELECT * FROM demo_webapi1.\"FN_DateMap\"(@pFiscalYear)";
                using (var connection = new NpgsqlConnection(_dBContext.Database.GetConnectionString()))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<DateMaps>(sql, new { pFiscalYear = fiscalYear });
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task TriggerTest(GLIndexDto dto, CancellationToken cancellationToken)
        {
            using(var transaction = await _dBContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, cancellationToken))
            {
                try
                {
                    GLIndex gLIndex = new GLIndex
                    {
                        Amount = dto.Amount,
                        Status = dto.Status,
                        IsTrigger = dto.IsTrigger,
                        GLIndexPosts = new List<GLIndexPost>()
                    };
                    dto.GLIndexPostDtos.ForEach(items =>
                    {
                        gLIndex.GLIndexPosts.Add(new GLIndexPost
                        {
                            GLIndexId = gLIndex.Id,
                            Description = items.Description,
                        });
                    });
                    await _dBContext.GLIndexs.AddAsync(gLIndex, cancellationToken);
                    await _dBContext.SaveChangesAsync(cancellationToken);
                    await _dBContext.Database.CommitTransactionAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    await _dBContext.Database.RollbackTransactionAsync(cancellationToken);
                    throw;
                }
                

            }
        }
        public async Task TriggerUpdateTest(GLIndexUpdateDto dto, CancellationToken cancellationToken)
        {
            using (var transaction = await _dBContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, cancellationToken))
            {
                try
                {
                    var glIndexEntity = await _dBContext.GLIndexs.Where(w => w.Id == dto.Id).FirstOrDefaultAsync(cancellationToken);
                    if (glIndexEntity != null) 
                    {
                        glIndexEntity.IsTrigger = dto.IsTrigger;
                        glIndexEntity.Status = dto.Status;
                        glIndexEntity.Amount = dto.Amount;
                        _dBContext.GLIndexs.Update(glIndexEntity);

                        var oldGLIndexPost = await _dBContext.GLIndexPost.AsNoTracking().Where(w => w.GLIndexId == glIndexEntity.Id).ToListAsync(cancellationToken);

                        _dBContext.RemoveRange(oldGLIndexPost);

                        List<GLIndexPost> gLIndexPosts = new List<GLIndexPost>();

                        dto.GLIndexPostDtos.ForEach(item =>
                        {
                            gLIndexPosts.Add(new GLIndexPost
                            {
                                GLIndexId = glIndexEntity.Id,
                                Description = item.Description
                            });
                        });

                        await _dBContext.GLIndexPost.AddRangeAsync(gLIndexPosts, cancellationToken);
                        await _dBContext.SaveChangesAsync(cancellationToken);
                        await _dBContext.Database.CommitTransactionAsync(cancellationToken);

                    }
                }
                catch (Exception ex)
                {
                    await _dBContext.Database.RollbackTransactionAsync(cancellationToken);
                    throw;
                }


            }
        }
    }
}

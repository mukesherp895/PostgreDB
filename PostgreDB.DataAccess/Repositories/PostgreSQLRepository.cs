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
    }
}

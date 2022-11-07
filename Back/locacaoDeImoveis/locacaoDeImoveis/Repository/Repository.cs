using locacaoDeImoveis.DTO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace locacaoDeImoveis.Controllers
{
  public class Repository
  {
    #region Variaveis
    static string connString = "STRING_DE_CONEXAO_BANCO_DE_DADOS_MYSQL";
    private MySqlConnection mySqlConn;
    private MySqlDataAdapter mAdapter;
    private DataSet dtSet;
    #endregion

    public List<imoveisDTO> QuerySelectIAllmoveis()
    {
      var retorno = ConnectMySqlServerSelect(query: "SELECT * FROM IMOVEIS", table: "IMOVEIS");
      string imoveisJson = JsonConvert.SerializeObject(retorno);
      var imoveisList = JsonConvert.DeserializeObject<List<imoveisDTO>>(imoveisJson);

      return imoveisList;
    }

    public imoveisDTO QuerySelectIOneImovel(int id)
    {
      try
      {
        var retorno = ConnectMySqlServerSelect(query: @$"SELECT * FROM IMOVEIS 
                                                                WHERE imovel_id = {id}", table: "IMOVEIS");
        string imoveisJson = JsonConvert.SerializeObject(retorno);
        var imoveisList = JsonConvert.DeserializeObject<List<imoveisDTO>>(imoveisJson).FirstOrDefault();

        return imoveisList;
      }
      catch (System.Exception ex)
      {
        return new imoveisDTO() { description = ex.Message.ToString() };
      }
    }

    public int QueryDeleteOneImovel(int id)
    {
      try
      {
        var retorno = ConnectMySqlExecuteQuery(query: @$"DELETE FROM IMOVEIS 
                                                                WHERE imovel_id = {id}");

        return retorno;
      }
      catch (System.Exception)
      {
        return 0;
      }
    }

    public int QueryInsertImovel(imoveisDTO imovel)
    {
      try
      {
        var listDeImoveis = QuerySelectIAllmoveis();
        imovel.imovel_id = listDeImoveis.Select(x => x.imovel_id).Max() + 1;
        if (imovel.imovel_id < 1 || imovel.imovel_id == null)
        {
          imovel.imovel_id = 1;
        }

        var retorno = ConnectMySqlExecuteQuery(query: $@"INSERT INTO IMOVEIS 
                                                                   (
                                                                   imovel_id,
                                                                   titulo_imovel,
                                                                   descricao_imovel,
                                                                   endereco_imovel,
                                                                   valor_imovel,
                                                                   cep_imovel,
                                                                   status,
                                                                   priority
                                                                   )
                                                                   VALUES 
                                                                   (
                                                                   {imovel.imovel_id},
                                                                   '{imovel.titulo_imovel}',
                                                                   '{imovel.descricao_imovel}',
                                                                   '{imovel.endereco_imovel}',
                                                                   '{imovel.valor_imovel}',
                                                                   '{imovel.cep_imovel}',
                                                                   1,
                                                                   2
                                                                   );
                                                                   ");

        return retorno;
      }
      catch (System.Exception)
      {
        return 0;
      }
    }

    public int QueryUpdatetImovel(imoveisDTO imovel)
    {
      try
      {
        var date = System.DateTime.Now.Date.ToString().Split(' ');
        var retorno = ConnectMySqlExecuteQuery(query: $@"UPDATE IMOVEIS SET
                                                                   titulo_imovel = '{imovel.titulo_imovel}',
                                                                   descricao_imovel = '{imovel.descricao_imovel}',
                                                                   endereco_imovel = '{imovel.endereco_imovel}',
                                                                   valor_imovel = '{imovel.valor_imovel}',
                                                                   cep_imovel = '{imovel.cep_imovel}',
                                                                   data_de_edicao = STR_TO_DATE('{date[0].ToString().Replace('/', ' ')}', '%d %m %Y')
                                                                   WHERE imovel_id = {imovel.imovel_id}
                                                                   ");

        return retorno;
      }
      catch (System.Exception)
      {
        return 0;
      }
    }

    private DataTable ConnectMySqlServerSelect(string query, string table)
    {
      try
      {
        dtSet = new DataSet();
        mySqlConn = new MySqlConnection(connString);
        mySqlConn.Open();

        if (mySqlConn.State == ConnectionState.Open)
        {

          mAdapter = new MySqlDataAdapter(query, mySqlConn);
          mAdapter.Fill(dtSet, table);

          return dtSet.Tables[table];
        }
        return null;
      }
      catch (System.Exception)
      {
        return null;
      }
    }

    private int ConnectMySqlExecuteQuery(string query)
    {
      try
      {
        dtSet = new DataSet();
        mySqlConn = new MySqlConnection(connString);
        mySqlConn.Open();

        var conn = mySqlConn.CreateCommand();
        conn.CommandText = query;
        var result = conn.ExecuteNonQuery();

        mySqlConn.Close();

        return result;
      }
      catch (System.Exception)
      {
        return 0;
      }
    }
  }
}

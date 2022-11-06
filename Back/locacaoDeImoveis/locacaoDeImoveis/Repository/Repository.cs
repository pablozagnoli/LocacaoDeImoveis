using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using locacaoDeImoveis.DTO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace locacaoDeImoveis.Controllers
{
  public class Repository
  {

    #region Variaveis
    static string connString = "Server=localhost;Database=locacaoDeImoveis;Uid=root;Pwd=PERNAlonGA2#";
    private MySqlConnection mConn;
    private MySqlDataAdapter mAdapter;
    private DataSet mDataSet;
    #endregion

    public string QuerySelectIAllmoveis()
    {
      var retorno = ConnectMySqlServerSelect(query: "SELECT * FROM IMOVEIS", table: "IMOVEIS");

      string JSONString = JsonConvert.SerializeObject(retorno);

      var JSONString2 = JsonConvert.DeserializeObject<List<imoveisDTO>>(JSONString);

      return JSONString;
    }

    public int QueryInsertImovel(imoveisDTO imovel)
    {
      var listDeImoveis = JsonConvert.DeserializeObject<List<imoveisDTO>>(QuerySelectIAllmoveis());
      imovel.imovel_id = listDeImoveis.Select(x => x.imovel_id).Max() + 1;

      var retorno = ConnectMySqlServerInsert(query: $@"INSERT INTO IMOVEIS 
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

    public int QueryUpdatetImovel(imoveisDTO imovel)
    {
      var date = System.DateTime.Now.Date.ToString().Split(' ');
      var retorno = ConnectMySqlServerInsert(query: $@"UPDATE IMOVEIS SET
                                                                   titulo_imovel = '{imovel.titulo_imovel}',
                                                                   descricao_imovel = '{imovel.descricao_imovel}',
                                                                   endereco_imovel = '{imovel.endereco_imovel}',
                                                                   valor_imovel = '{imovel.valor_imovel}',
                                                                   cep_imovel = '{imovel.cep_imovel}',
                                                                   status, = 1
                                                                   priority = 2,
                                                                   data_de_edicao = {System.DateTime.Now}
                                                                   WHERE imovel_id = {imovel.imovel_id},
                                                                   ");

      return retorno;
    }

    private DataTable ConnectMySqlServerSelect(string query, string table)
    {
      mDataSet = new DataSet();
      mConn = new MySqlConnection(connString);
      mConn.Open();

      if (mConn.State == ConnectionState.Open)
      {

        mAdapter = new MySqlDataAdapter(query, mConn);
        mAdapter.Fill(mDataSet, table);

        return mDataSet.Tables[table];
      }
      return null;
    }

    private int ConnectMySqlServerInsert(string query)
    {
      mDataSet = new DataSet();
      mConn = new MySqlConnection(connString);
      mConn.Open();

      var comm = mConn.CreateCommand();
      comm.CommandText = query;
      var result = comm.ExecuteNonQuery();
      
      mConn.Close();

      return result;
    }
  }
}

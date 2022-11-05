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
    static string connString = "Server=localhost;Database=locacaoDeImoveis;Uid=root;Pwd=PERNAlonGA2#";
    private MySqlConnection mConn;
    private MySqlDataAdapter mAdapter;
    private DataSet mDataSet;

    public string QuerySelectIAllmoveis()
    {

      var retorno = ConnectMySqlServer(query: "SELECT * FROM IMOVEIS", table: "IMOVEIS");

      string JSONString = JsonConvert.SerializeObject(retorno);

      var JSONString2 = JsonConvert.DeserializeObject<List<imoveisDTO>>(JSONString);

      return JSONString;

    }

    private DataTable ConnectMySqlServer(string query, string table)
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
  }
}

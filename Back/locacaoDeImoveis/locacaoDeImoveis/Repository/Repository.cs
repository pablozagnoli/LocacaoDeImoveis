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

    public MySqlDataReader conectdb()
    {
      //Aqui você substitui pelos seus dados

      var connection = new MySqlConnection(connString);
      var command = connection.CreateCommand();

      try
      {
        connection.Open();
        command.CommandText = "SELECT * FROM IMOVEIS";
        return command.ExecuteReader();
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
    }

    public string conectdbMySqlAsync()
    {

      mDataSet = new DataSet();
      mConn = new MySqlConnection(connString);
      mConn.Open();


      if (mConn.State == ConnectionState.Open)
      {

        mAdapter = new MySqlDataAdapter("SELECT * FROM IMOVEIS", mConn);
        mAdapter.Fill(mDataSet, "IMOVEIS");

        var retorno = mDataSet.Tables["IMOVEIS"];

        var serializado = retorno.AsEnumerable();


        string JSONString = JsonConvert.SerializeObject(retorno);

        var JSONString2 = JsonConvert.DeserializeObject<List<imoveisDTO>>(JSONString);

        return JSONString;
      }

      return null;
    }
  }
}

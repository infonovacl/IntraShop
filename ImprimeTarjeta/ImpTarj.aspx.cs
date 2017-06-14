using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Odbc;
using System.Data;

public partial class ImpTarj : System.Web.UI.Page
{
    //Conexion a BD
    string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString_FamilyShop"].ConnectionString;

    //Variables de Titular
    string CodResultTit = string.Empty;
    string MsjResultTit = string.Empty;
    string ApellidosTit = string.Empty;
    string NombresTit = string.Empty;
    string UltVersTit = string.Empty;
    string RutsdvTit = string.Empty;
    string NombreTit = string.Empty;
    string Sucursal = string.Empty;
    string RutTit = string.Empty;
    string dvTit = string.Empty;
    string Rut = string.Empty;

    //Variables de Adicional
    string CodResultAdic = string.Empty;
    string MsjResultAdic = string.Empty;
    string ApellidosAdic = string.Empty;
    string UltVersAdic = string.Empty;
    string NombresAdic = string.Empty;
    string NombreAdic = string.Empty;
    string RutsdvAdic = string.Empty;
    string RutAdic = string.Empty;
    string parent = string.Empty;
    string FecIng = string.Empty;
    string dvAdic = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        Rut = Request.QueryString["Rut"];
        Sucursal = Request.QueryString["Sucursal"];

        //Traemos datos de Titular
        using (OdbcConnection conn = new OdbcConnection(strConnString))
        {
            OdbcCommand cmd = new OdbcCommand("{ CALL procw_tarjeta_titular(?) } ", conn);

            try
            {
                var ds = new DataSet();
                var adapter = new OdbcDataAdapter(cmd);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUT", Rut);
                conn.Open();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    DataSet dsa = new DataSet();
                    DataTable dt = new DataTable();

                    CodResultTit = row[0].ToString();
                    MsjResultTit = row[1].ToString();
                    RutsdvTit = row[2].ToString();
                    dvTit = row[3].ToString();
                    RutTit = RutsdvTit + "-" + dvTit;
                    NombresTit = row[4].ToString().Trim();
                    ApellidosTit = row[5].ToString().Trim();
                    NombreTit = NombresTit + " " + ApellidosTit;
                    UltVersTit = row[6].ToString();

                    if (CodResultTit == "0")
                    {
                        this.Label1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                        this.Label5.Text = NombreTit;
                        this.Label6.Text = UltVersTit;
                        this.Label7.Text = RutTit;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + MsjResultTit + "');", true);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        //Traemos datos de Adcicional
        using (OdbcConnection conn = new OdbcConnection(strConnString))
        {
            OdbcCommand cmd = new OdbcCommand("{ CALL procw_tarjeta_adicional(?) } ", conn);

            try
            {
                var ds = new DataSet();
                var adapter = new OdbcDataAdapter(cmd);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUT", Rut);
                conn.Open();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    DataSet dsa = new DataSet();
                    DataTable dt = new DataTable();

                    CodResultAdic = row[0].ToString();
                    MsjResultAdic = row[1].ToString();
                    RutsdvAdic = row[2].ToString();
                    dvAdic = row[3].ToString();
                    RutAdic = RutsdvAdic + "-" + dvAdic;
                    NombresAdic = row[4].ToString().Trim();
                    ApellidosAdic = row[5].ToString().Trim();
                    NombreAdic = NombresAdic + " " + ApellidosAdic;
                    parent = row[6].ToString();
                    FecIng = row[7].ToString();
                    UltVersAdic = row[8].ToString();

                    if (CodResultAdic == "0")
                    {
                        dsa.Tables.Add(dt);
                        dt.Columns.Add("RutAdic", typeof(string));
                        dt.Columns.Add("NombreAdic", typeof(string));
                        dt.Columns.Add("Parent", typeof(string));
                        dt.Columns.Add("FecIng", typeof(string));
                        dt.Columns.Add("UltVers", typeof(string));
                        dt.Rows.Add(RutAdic, NombreAdic, parent, FecIng.Replace("0:00:00", ""), UltVersAdic);

                        GridView.DataSource = dsa.Tables[0].DefaultView;
                        GridView.DataBind();
                        GridView.HeaderRow.Cells[0].Text = "Cedula Adicional";
                        GridView.HeaderRow.Cells[1].Text = "Nombre";
                        GridView.HeaderRow.Cells[2].Text = "Parentesco";
                        GridView.HeaderRow.Cells[3].Text = "Fecha de Ingreso";
                        GridView.HeaderRow.Cells[4].Text = "Version Tarjeta";
                        GridView.Visible = true;

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + MsjResultAdic + "');", true);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (TipoTarjeta.SelectedValue == "1")
        {
            using (OdbcConnection conn = new OdbcConnection(strConnString))
            {
                try
                {
                    string x = "execute procedure procw_imprime_tarjeta  ('" + RutsdvTit + "','" + "0" + "','" + Sucursal + "','" + dvTit + "','" + "" + "','" + UltVersTit + "')";
                    OdbcDataAdapter obdcadapter = new OdbcDataAdapter(x, conn);
                    DataSet datset = new DataSet();
                    conn.Open();
                    obdcadapter.Fill(datset);

                    DataRow row = datset.Tables[0].Rows[0];

                    string CodResult = row[0].ToString();
                    string MsjResult = row[1].ToString();
                    string numtarj = row[2].ToString();
                    string expira = row[3].ToString();

                    if (CodResult == "0")
                    {
                        Titular TitCs = new Titular();
                        string strXmlTit = TitCs.TitularXml(Convert.ToInt32(RutsdvTit), dvTit, NombresTit, ApellidosTit, expira, numtarj, UltVersTit);

                        if (strXmlTit != "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Tarjeta generada con exito');", true);
                            this.TextBox1.Text = strXmlTit;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + MsjResult + "');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
                }
            }
        }
        else
        {
            using (OdbcConnection conn = new OdbcConnection(strConnString))
            {
                try
                {
                    string x = "execute procedure procw_imprime_tarjeta  ('" + RutsdvTit + "','" + RutsdvAdic + "','" + Sucursal + "','" + dvTit + "','" + dvAdic + "','" + UltVersTit + "')";
                    OdbcDataAdapter obdcadapter = new OdbcDataAdapter(x, conn);
                    DataSet datset = new DataSet();
                    conn.Open();
                    obdcadapter.Fill(datset);
                    DataRow row = datset.Tables[0].Rows[0];
                    string CodResult = row[0].ToString();
                    string MsjResult = row[1].ToString();
                    string numtarj = row[2].ToString();
                    string expira = row[3].ToString();

                    if (CodResult == "0")
                    {
                        Adicional AdicCs = new Adicional();
                        string strXmlAdic = AdicCs.AdicXml(Convert.ToInt32(RutsdvTit), dvTit, Convert.ToInt32(RutsdvAdic), dvAdic, NombresAdic, ApellidosAdic, expira, numtarj, UltVersAdic);

                        if (strXmlAdic != "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Tarjeta generada con exito');", true);
                            this.TextBox1.Text = strXmlAdic;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + MsjResult + "');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
                }
            }
        }
    }
}


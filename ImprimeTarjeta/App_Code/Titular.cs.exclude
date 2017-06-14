using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Titular
{
    public String TitularXml(Int32 rutTit, String dvTit, String nombres, String apellidos, String expiracion, String numeroTarj, String version)
    {
        string mesexp = expiracion.Substring(0, 2);
        string añoexp = expiracion.Substring(2, 2);
        string nomCorto = nombres + " " + apellidos;
        int maxNombre = nomCorto.Length;

        if (maxNombre < 55)
        {
            nomCorto = nomCorto + "                                                       ";
        }

        nomCorto = nomCorto.Substring(0, 55);

        string strXml = "<DATA_TAR>" +
                "<LINEAS> " +
                    "<TOTAL> 4 </TOTAL> " +
                        "<LINEA idl = '1' datos = '" + numeroTarj + "' align = 'IZQ' cara = 'A' font = 'ARIAL' fontsize = '14' negrita = 'S' cursiva = 'N' subrayado = 'N' posx = '08' posy = '25' /> " +
                        "<LINEA idl = '2' datos = 'Valida hasta " + mesexp + "/" + añoexp + "' align = 'IZQ' cara = 'A' font = 'ARIAL' fontsize = '11' negrita = 'S' cursiva = 'N' subrayado = 'N' posx = '08' posy = '30' /> " +
                        "<LINEA idl = '3' datos = '" + nombres + "' align = 'IZQ' cara = 'A' font = 'ARIAL' fontsize = '11' negrita = 'S' cursiva = 'N' subrayado = 'N' posx = '08' posy = '40' /> " +
                        "<LINEA idl = '4' datos = '" + apellidos + "' align = 'IZQ' cara = 'A' font = 'ARIAL' fontsize = '11' negrita = 'S' cursiva = 'N' subrayado = 'N' posx = '08' posy = '46' /> " +
                "</LINEAS> " +
                "<TRACKS> " +
                    "<TOTAL> 2 </TOTAL> " +
                        "<TRACK idt = '1' numero = '1' datos = 'CLICK" + nomCorto + "'/> " +
                        "<TRACK idt = '2' numero = '2' datos = '" + "000000000" + Convert.ToString(rutTit) + "0" + "000000000" + "0" + version + expiracion + "001" + "'/> " +
                "</TRACKS> " +
            "</DATA_TAR>";
        return strXml;
    }
}
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenciones_Autentia.aspx.vb" Inherits="Mantencion_Autentia" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/EstilosShop.css" rel="stylesheet" />
    <link href="Firma/demoButtons.css" rel="stylesheet" />
    <title>Mantención Datos Cliente - Tarjetas</title>    
     <object id='Autentia' classid='CLSID:592B9D7E-51C9-401F-A03C-4DE61FF7008D' name="Autentia" ></object>
	<script type='text/javascript'>
	    function LLamaTarjeta() {	      
           window.open('/Mantenciones/Mantenciones_FirmaDoc.aspx', 'Tarjetas', 'top=90,left=220,width=700,height=610', titlebar = 'NO', scrollbars = 'NO', resizable = 'NO', toolbar = 'NO');
	       window.focus();
	       Cierra();
	   }
	   function Cierra() {
	       setTimeout(function () {
	           self.close();
	       }, 900);
	   }
	    function TParams() {
	        this.Rut = '';
	        this.DV = '';
	        this.RutaSave = '';
	        this.Lugar = '';
	    }
	    function Iniciar() {
	        var Params = new TParams;
	        var Ret = 1; // antes Ret = 0
            
           // alert(document.getElementById("ruttitular").value)
	        // window.document.form1.ruttitular.value; //"14244170-5"

            Params.pRut = document.getElementById("ruttitular").value;  

	        Params.Erc = "";
	        Params.ErcDesc = "";
	        erc = 200;          
	          //Ret = document.form1.Retorno.value;
	        if (Ret == 1) {
	            if (Params.pRut != 0) {
	                alert("Por favor active Sensor de Huella ...");
	               // document.form1.Descripcion.value = "";
	               // document.getElementById("descripcion").innerText = "Error en Validacion de Huella";
	               // document.form1.Descripcion.value = "Error en Validacion de Huella";
	                erc = Autentia.Transaccion("verificadatos", Params); ;
                    //alert(erc)
	                if (erc == null) {
	                   // document.form1.ErcRes.value = "-1";
	                    document.getElementById("ErcRes").value = "-1";
	                   // document.form1.ErcDet.value = "-1";
	                    document.getElementById("ErcDes").value = "-1";
	                    //document.form1.Descripcion.value = "";
	                    document.getElementById("Descripcion").value = "";
	                   // document.form1.Descripcion.value = "Error en Validacion de Huella";
	                    document.getElementById("Descripcion").value = "Error en Validacion de Huella";
	                   // document.form1.Mensaje.value = "Error en Validacion de Huella";
	                    document.getElementById("Mensaje").value = "Error en Validacion de Huella";
                       // document.form1.Retorno.value = "-1";
	                    document.getElementById("ButtonAut").click();
	                }
	                else {
	                    if (erc == 0) {
	                        if (Params.Erc != 0 || Params.Erc == null) // hay algun error
	                        {
	                            document.form1.Descripcion.value = Params.ErcDesc;
	                        }
	                        else {
	                            alert("Validación Completada Exitosamente")	              	                         
	                            LLamaTarjeta();	                          
	                            //document.form1.Descripcion.value = "Huella Aceptada";	
	                        }
	                    }
	                    else {
	                        if (erc == 3) {
	                            document.form1.Descripcion.value = "Sensor de Huellas No Accesable";
	                            //alert(erc);   
	                        }
	                        else {
	                            if (erc == 1) {
	                                document.form1.Descripcion.value = "Huella ha sido Rechazada";
	                            }
	                            else {
	                                if (erc == 2) {
	                                    document.form1.Descripcion.value = "Base de Huellas No Accesable";
	                                }
	                                else {
	                                    if (erc == 4) {
	                                        document.form1.Descripcion.value = "Time Out en Sensor de Huellas";
	                                    }
	                                    else {
	                                        if (erc == 5) {
	                                            document.form1.Descripcion.value = "Operacion Abandonada";
	                                        }
	                                        else {
	                                            if (erc == 6) {
	                                                document.form1.Descripcion.value = "Version Incompatible";
	                                            }
	                                            else {
	                                                if (erc == 7) {
	                                                    document.form1.Descripcion.value = "Sensor No Registrado";
	                                                }
	                                                else {
	                                                    document.form1.Descripcion.value = "Error en Ejecucion " & Params.ErcDesc;
	                                                }
	                                            }
	                                        }
	                                    }
	                                }
	                            }
	                        }
	                    }
	                    document.form1.ErcDet.value = Params.Erc;
	                    document.form1.ErcRes.value = erc;
	                    document.form1.Retorno.value = erc;
	                    document.form1.Mensaje.value = Params.ErcDesc;
	                    window.document.getElementById("ButtonAut").click();
	                }
	            }
	            else {
	                document.form1.ErcRes.value = '-1';
	                document.form1.ErcDet.value = "-1";
	                document.form1.Retorno.value = '-1';
	                document.form1.Descripcion.value = "Error en Rut de Cliente ...";
	                document.form1.Mensaje.value = "Error en Rut de Cliente ..."
	                window.document.getElementById("ButtonAut").click();
	            }
	        }
	        else {
	            document.form1.Descripcion.value = "Error en Rut de Cliente ..."
	            return false;
	        }
	    }
</script> 
    <style type="text/css">
        .auto-style12
        {
            width: 475px;
        }
    </style>
</head>
<body style="width: 410px; height: 214px;">
    <form id="form1" runat="server">
    <div class="auto-style12">       
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
                <asp:Label ID="Label78" runat="server" CssClass="etiquetas_titulo" Text="VALIDACION IDENTIDAD CLIENTE "></asp:Label>
                <br />              
                <br />
                <asp:TextBox ID="ruttitular" runat="server" AutoCompleteType="Disabled" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" Height="16px" Style="font-size: smaller; font-family: 'Comic Sans MS'; text-align: right" TabIndex="1" Width="152px"></asp:TextBox>
                <br />                
                <input id="Retorno" runat="server" name="Retorno" style="width: 24px; color: white; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" visible="true" />
                <input id="ErcRes" runat="server" name="ErcRes" style="width: 24px; color: white; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" visible="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Descripcion" runat="server" name="Descripcion" style="color: olive; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 88px;" visible="true" />
                <input id="ErcDet" runat="server" name="ErcDet" style="width: 24px; color: white; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" visible="true" />               
                <asp:Label ID="LBL_DatosClienteError" runat="server" CssClass="etiquetasmensajeerror"></asp:Label>             
                <br />
                <asp:TextBox ID="LabelMSJ" runat="server" BackColor="Transparent" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Size="Small" ForeColor="Black" Height="16px" ReadOnly="True" Style="font-weight: bold; color: red; font-style: normal; background-color: #ffffff; text-align: left; font-variant: normal; text-transform: uppercase;" TabIndex="2" Width="704px"></asp:TextBox>
                <br />
                <asp:TextBox ID="Mensaje" runat="server" BackColor="Transparent" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Size="Small" ForeColor="Black" Height="16px" ReadOnly="True" Style="font-weight: bold; text-transform: uppercase; color: red; font-style: normal; background-color: #ffffff; text-align: left; font-variant: normal" TabIndex="2" Width="824px"></asp:TextBox>
                <br />
                <table class="style12">
                    <tr>
                        <td style="text-align: center">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="ButtonAut" runat="server" CssClass="botones" Text="VALIDA HUELLA"  Width="214px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BTN_Cerrar" runat="server" CssClass="botones_ancho" Text="CERRAR" Width="110px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                    </tr>
                </table>
    </div>
    </form>
    </body>
</html>

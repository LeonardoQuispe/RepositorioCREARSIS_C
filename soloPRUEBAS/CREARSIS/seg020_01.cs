using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//REFERENCIAS
using DATOS.ADM;
using DevComponents.DotNetBar;

namespace CREARSIS
{
    /// <summary>
    /// FORMULARIO PERSONALIZA MENU A USUARIO
    /// </summary>
    public partial class seg020_01 : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region VARIABLES

        public dynamic vg_frm_pad;
        DataTable tab_ads052;
        DataTable tab_ads004;
        string va_cod_usr = "";

        #endregion

        #region INSTANCIAS

        c_seg020 o_ads052 = new c_seg020();
        c_seg001 o_ads005 = new c_seg001();

        #endregion

        #region EVENTOS

        public seg020_01()
        {
            InitializeComponent();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            vg_frm_pad.Enabled = true;
            vg_frm_pad.Activate();
            Close();
        }

        private void seg020_01_FormClosing(object sender, FormClosingEventArgs e)
        {
            vg_frm_pad.Enabled = true;
            vg_frm_pad.Activate();
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                graba_menu();

                if (vg_frm_pad.IsMdiContainer == true)
                {
                    vg_frm_pad.Activate();
                    this.Close();
                }
                else
                {
                    vg_frm_pad.vg_frm_pad.Activate();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region METODOS

        public void obtiene_menu(string cod_usr, string ide_frm, MenuStrip men_usr)
        {
            //(tabla.Rows[0][0].ToString());
            va_cod_usr = cod_usr;
            tb_sel_usr.Text = cod_usr;
            lb_nom_ven.Text = ide_frm;
            tab_ads004 = o_ads005._05(tb_sel_usr.Text);
            lb_sel_usr.Text = tab_ads004.Rows[0]["va_nom_usr"].ToString();

            //// Recrea todas las opciones del menu en el arbol
            foreach (ToolStripMenuItem Raiz in men_usr.Items)
            {

                //Valida que no se quite el boton de atras
                if (Raiz.Text=="&Atras")
                {
                    break;
                }

                //adiciona la opcion del menu al arbol
                Tv_men_usr.Nodes.Add(Raiz.Name, Raiz.Text);

                //verifica que la opcion no este restringida
                tab_ads052 = o_ads052._05(cod_usr, lb_nom_ven.Text, Raiz.Name);

                //si existe = Restringido
                if (tab_ads052.Rows.Count != 0)
                {
                    Tv_men_usr.Nodes[Raiz.Name].Checked = false;
                }
                else
                {
                    //si no existe = Tiene permiso
                    Tv_men_usr.Nodes[Raiz.Name].Checked = true;
                }

                fu_bus_hi1(Raiz);
            }
        }

        private void fu_bus_hi1(ToolStripMenuItem itm_hi1)
        {
            foreach (ToolStripMenuItem hijo1 in itm_hi1.DropDownItems)
            {
                Tv_men_usr.Nodes[itm_hi1.Name].Nodes.Add(hijo1.Name, hijo1.Text);

                //verifica que la opcion no este restringida
                tab_ads052 = o_ads052._05(va_cod_usr, lb_nom_ven.Text, hijo1.Name);

                //si existe = permiso restringido
                if (tab_ads052.Rows.Count != 0)
                {
                    Tv_men_usr.Nodes[itm_hi1.Name].Nodes[hijo1.Name].Checked = false;

                }
                else
                {
                    //si no existe = Tiene permiso
                    Tv_men_usr.Nodes[itm_hi1.Name].Nodes[hijo1.Name].Checked = true;
                }

                if (hijo1.DropDownItems.Count > 0)
                {
                    fu_bus_hi2(itm_hi1, hijo1);
                }

            }
        }

        private void fu_bus_hi2(ToolStripMenuItem padre, ToolStripMenuItem itm_hi2)
        {

            foreach (ToolStripMenuItem hijo2 in itm_hi2.DropDownItems)
            {
                Tv_men_usr.Nodes[padre.Name].Nodes[itm_hi2.Name].Nodes.Add(hijo2.Name, hijo2.Text);

                //verifica que la opcion no este restringida
                tab_ads052 = o_ads052._05(va_cod_usr, lb_nom_ven.Text, hijo2.Name);

                //si existe = permiso restringido
                if (tab_ads052.Rows.Count != 0)
                {
                    Tv_men_usr.Nodes[padre.Name].Nodes[itm_hi2.Name].Nodes[hijo2.Name].Checked = false;
                }
                else
                {
                    //si no existe = Tiene permiso
                    Tv_men_usr.Nodes[padre.Name].Nodes[itm_hi2.Name].Nodes[hijo2.Name].Checked = true;
                }

            }
        }

        public void graba_menu()
        {

            foreach (TreeNode N_raiz in Tv_men_usr.Nodes)
            {
                //## PERMITIDO
                if (Tv_men_usr.Nodes[N_raiz.Name].Checked == true)
                {

                    //si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads052._06(va_cod_usr, lb_nom_ven.Text, N_raiz.Name);

                    //'habilita en el menu
                    //men_usr.Items(N_raiz.Name).Enabled = True

                    //## DENEGADO
                }
                else
                {

                    //si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)

                    //pregunta a la BD si existe
                    tab_ads052 = o_ads052._05(va_cod_usr, lb_nom_ven.Text, N_raiz.Name);

                    //si NO tiene registro, entonces lo quita de las restrinciones en la BD
                    if (tab_ads052.Rows.Count == 0)
                    {
                        o_ads052._02(va_cod_usr, lb_nom_ven.Text, N_raiz.Name);
                    }

                    //'deshabilita en el menu
                    //men_usr.Items(N_raiz.Name).Enabled = False

                }

                fu_gra_hi1(N_raiz);

            }

            if (vg_frm_pad.IsMdiContainer == true)
            {
                vg_frm_pad.fu_ver_mnu(va_cod_usr, vg_frm_pad);
            }
            else
            {
                vg_frm_pad.MdiParent.fu_ver_mnu(va_cod_usr, vg_frm_pad);
            }
        }

        private void fu_gra_hi1(TreeNode itm_hi1)
        {
            foreach (TreeNode N_hijo1 in itm_hi1.Nodes)
            {
                //## PERMITIDO
                if (itm_hi1.Nodes[N_hijo1.Name].Checked == true)
                {

                    //si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads052._06(va_cod_usr, lb_nom_ven.Text, N_hijo1.Name);

                    //## DENEGADO
                }
                else
                {

                    //si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)

                    //pregunta a la BD si existe
                    tab_ads052 = o_ads052._05(va_cod_usr, lb_nom_ven.Text, N_hijo1.Name);

                    //si NO tiene registro, entonces lo quita de las restrinciones en la BD
                    if (tab_ads052.Rows.Count == 0)
                    {
                        o_ads052._02(va_cod_usr, lb_nom_ven.Text, N_hijo1.Name);
                    }


                }

                fu_gra_hi2(N_hijo1);
            }
        }

        private void fu_gra_hi2(TreeNode itm_hi2) //padre As TreeNode, itm_hi2 As TreeNode)
        {
            foreach (TreeNode N_hijo2 in itm_hi2.Nodes)
            {
                //## PERMITIDO
                if (itm_hi2.Nodes[N_hijo2.Name].Checked == true)
                {

                    //si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads052._06(va_cod_usr, lb_nom_ven.Text, N_hijo2.Name);

                    //## DENEGADO
                }
                else
                {

                    //si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)

                    //pregunta a la BD si existe
                    tab_ads052 = o_ads052._05(va_cod_usr, lb_nom_ven.Text, N_hijo2.Name);

                    //si NO tiene registro, entonces lo quita de las restrinciones en la BD
                    if (tab_ads052.Rows.Count == 0)
                    {
                        o_ads052._02(va_cod_usr, lb_nom_ven.Text, N_hijo2.Name);
                    }

                    //'deshabilita en el menu
                    //men_usr.Items(N_hijo2.Name).Enabled = False

                }

                // fu_gra_hi2(N_hijo2)

            }

        }
        #endregion

    }
}
